import { SpinnerService } from '@core/services/spinner.service';
import { Test } from '@shared/models/test/test';
import { TestMethod } from '@shared/models/test/enums/test-method';
import { tap } from 'rxjs/operators';
import { Member } from '@shared/models/member/member';
import { ProjectService } from '@core/services/project.service';
import { Project } from '@shared/models/projects/project';
import { regexs } from '@shared/constants/regexs';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { BaseComponent } from '@core/components/base/base.component';
import { AuthenticationService } from '@core/services/authentication.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { protocolOptions, typeOptions, methodOptions, contentTypes } from './test-settings.constant';
import { InputTextarea } from 'primeng/inputtextarea';
import { TestRequest } from '@shared/models/test/test-request';
import { KeyValuePair } from '@shared/models/key-value-pair';
import { toKeyValuePairs, toObject } from '@core/utils/kvp.utils';
import { TestService } from '@core/services/test.service';
import * as CustomValidators from './test-settings.validators';
import { getUrl, hasBody, toPretty, jsonToXml, xmlToJson } from './test-settings.utils';

@Component({
    selector: 'app-test-settings',
    templateUrl: './test-settings.component.html',
    styleUrls: ['./test-settings.component.sass']
})
export class TestSettingsComponent extends BaseComponent implements OnInit {
    header: string;
    member: Member;
    settingsGroup: FormGroup;
    requestGroups: FormGroup[];
    testTypeOptions = typeOptions;
    testProtocolOptions = protocolOptions;
    testMethodOptions = methodOptions;
    projects: Project[];
    isNotFound = false;
    testId: number;
    contentTypes = contentTypes;
    loading: boolean;
    @ViewChild(InputTextarea) textarea: InputTextarea;
    getUrl = getUrl;
    hasBody = hasBody;
    constructor(
        private authService: AuthenticationService,
        private activatedRoute: ActivatedRoute,
        private toastNotifications: ToastNotificationService,
        private projectService: ProjectService,
        private testService: TestService,
        private router: Router,
        private spinner: SpinnerService
    ) { super(); }

    async ngOnInit(): Promise<void> {
        this.loading = true;
        this.spinner.show(true);
        this.initFormGroups();
        this.authService.getMember()
            .pipe(
                this.untilThis,
                tap(member => {
                    this.member = member;
                })
            )
            .subscribe(() => {
                this.initProjects().subscribe(() => {
                    this.activatedRoute.params
                        .pipe(this.untilThis)
                        .subscribe(params => {
                            if (params.id) {
                                this.header = 'Edit test';
                                this.initEditMode(+params.id);
                            } else {
                                this.header = 'Add a new test';
                                this.spinner.hide();
                                this.loading = false;
                            }
                        }, error => {
                            this.loading = false;
                            this.spinner.hide();
                            this.toastNotifications.error(error);
                        });
                });
            }, error => {
                this.toastNotifications.error(error);
            });
    }
    initEditMode(id: number) {
        this.testId = id;
        this.testService.getTestById(id)
            .subscribe(test => {
                if (test.organizationId !== this.member.organizationId) {
                    this.isNotFound = true;
                    this.loading = false;
                    this.spinner.hide();
                } else {
                    this.settingsGroup.controls.name.setValue(test.name);
                    this.settingsGroup.controls.type.setValue(test.type);
                    this.settingsGroup.controls.clients.setValue(test.clients);
                    this.settingsGroup.controls.duration.setValue(test.duration.substring(3));
                    this.settingsGroup.controls.projectId.setValue(test.projectId);
                    this.requestGroups = test.requests.map(x => this.generateRequestGroup(
                        protocolOptions.find(p => p.value === x.protocol),
                        x.host,
                        x.path,
                        methodOptions.find(m => m.value === x.method),
                        x.body,
                        toKeyValuePairs(JSON.parse(x.headers)),
                        toKeyValuePairs(JSON.parse(x.parameters)),
                        x.id,
                        JSON.parse(x.headers).contentType
                    ));
                    this.loading = false;
                    this.spinner.hide();
                }
            }, () => {
                this.isNotFound = true;
                this.loading = false;
                this.spinner.hide();
            });
    }

    initFormGroups() {
        this.settingsGroup = new FormGroup({
            name: new FormControl(
                '',
                [
                    Validators.required,
                    Validators.minLength(3),
                    Validators.maxLength(50),
                    Validators.pattern(regexs.testName)
                ]
            ),
            type: new FormControl(
                typeOptions[0].value,
                [
                    Validators.required,
                ]
            ),
            clients: new FormControl(
                250,
                [
                    Validators.required,
                    Validators.min(1),
                    Validators.max(10000)
                ]
            ),
            duration: new FormControl(
                '00:20',
                [
                    Validators.required,
                    CustomValidators.time
                ]
            ),
            projectId: new FormControl(
                null
            )
        });

        this.requestGroups = [this.generateRequestGroup()];
    }

    initProjects() {
        return this.projectService.getProjectsByOrganizationId(this.member.organizationId)
            .pipe(tap(projects => {
                this.projects = projects;
            }));
    }

    generateRequestGroup(
        protocol = protocolOptions[0],
        host = '',
        path = '',
        method = methodOptions[0],
        body = '{\n  "some": "body"\n}',
        headers = [{}],
        parameters = [{}],
        id = undefined,
        contentType = 'application/json'
    ): FormGroup {
        return new FormGroup({
            protocol: new FormControl(protocol, [Validators.required]),
            host: new FormControl(host, [Validators.required]),
            path: new FormControl(path),
            method: new FormControl(method, [Validators.required]),
            headers: new FormControl(headers),
            parameters: new FormControl(parameters),
            body: new FormControl(body, [CustomValidators.json]),
            id: new FormControl(id),
            collapsed: new FormControl(false),
            contentType: new FormControl(contentType)
        });
    }

    get name() { return this.settingsGroup.controls.name; }
    get type() { return this.settingsGroup.controls.type; }
    get clients() { return this.settingsGroup.controls.clients; }
    get duration() { return this.settingsGroup.controls.duration; }

    addRequest() {
        this.requestGroups.forEach(g => g.controls.collapsed.setValue(true));
        this.requestGroups = this.requestGroups.concat(this.generateRequestGroup());
    }

    deleteRequest(form: FormGroup) {
        this.requestGroups = this.requestGroups.filter(x => x !== form);
    }

    addHeader(form: FormGroup) {
        const headers = form.controls.headers.value;
        form.controls.headers.setValue(headers.concat({}));
    }

    deleteHeader(form: FormGroup, kvp: KeyValuePair) {
        const headers = form.controls.headers.value;
        form.controls.headers.setValue(headers.filter(x => x !== kvp));
    }

    addParameter(form: FormGroup) {
        const parameters = form.controls.parameters.value;
        form.controls.parameters.setValue(parameters.concat({}));
    }

    deleteParameter(form: FormGroup, kvp: KeyValuePair) {
        const parameters = form.controls.parameters.value;
        form.controls.parameters.setValue(parameters.filter(x => x !== kvp));
    }

    handle(e: KeyboardEvent, form: FormGroup) {
        if (form.controls.contentType.value === 'application/json') {
            this.handleJson(e);
        } else if (form.controls.contentType.value === 'application/xml') {
            this.handleXml(e);
        } else {
            this.handleCommon(e);
        }
        this.textarea.resize();
    }
    handleCommon(e: KeyboardEvent) {
        if (e.key === 'Tab') {
            this.editTextArea(e, '  ', 2);
        }
    }
    handleXml(e: KeyboardEvent) {
        if (e.key === 'Tab') {
            this.editTextArea(e, '  ', 2);
        } else if (e.key === '<') {
            this.editTextArea(e, '<>', 1);
        }
    }

    private handleJson(e: KeyboardEvent) {
        if (e.key === 'Tab') {
            this.editTextArea(e, '  ', 2);
        } else if (e.key === '"') {
            this.editTextArea(e, '""', 1);
        } else if (e.key === '{') {
            this.editTextArea(e, '{}', 1);
        } else if (e.key === '[') {
            this.editTextArea(e, '[]', 1);
        } else if (e.key === 'Enter') {
            e.preventDefault();
            const textarea = e.target as HTMLTextAreaElement;
            const start = textarea.selectionStart;
            const end = textarea.selectionEnd;

            const previous = textarea.value.substring(0, start);
            const lastEnter = previous.lastIndexOf('\n');
            const lastLine = lastEnter === -1 ? previous : previous.substring(lastEnter + 1);
            const firstNonSpace = lastLine.search(/\S/);
            const whiteSpaces = lastLine.substring(0, firstNonSpace === -1 ? lastLine.length : firstNonSpace);
            textarea.value = `${textarea.value.substring(0, start)}\n${whiteSpaces}${textarea.value.substring(end)}`;

            textarea.selectionStart = start + whiteSpaces.length + 1;
            textarea.selectionEnd = start + whiteSpaces.length + 1;
        }
    }

    private editTextArea(e: KeyboardEvent, text: string, selection: number) {
        e.preventDefault();
        const textarea = e.target as HTMLTextAreaElement;
        const start = textarea.selectionStart;
        const end = textarea.selectionEnd;

        textarea.value = `${textarea.value.substring(0, start)}${text}${textarea.value.substring(end)}`;

        textarea.selectionStart = start + selection;
        textarea.selectionEnd = start + selection;
    }

    changedMethod(method: TestMethod, form: FormGroup) {
        const { headers } = form.controls;
        if (hasBody(method)) {
            if (!headers.value.find(x => x.key === 'content-type')) {
                headers.setValue([{ key: 'content-type', value: form.controls.contentType.value }].concat(headers.value));
            }
        } else {
            headers.setValue(headers.value.filter(x => x.key !== 'content-type'));
        }
    }

    contentTypeChanged(value: string, form: FormGroup) {
        if (form.controls.contentType.value === 'application/json' && value === 'application/xml') {
            form.controls.body.setValue(jsonToXml(form.controls.body.value));
        } else if (form.controls.contentType.value === 'application/xml' && value === 'application/json') {
            form.controls.body.setValue(xmlToJson(form.controls.body.value));
        }
        form.controls.contentType.setValue(value);
        form.controls.body.setValue(toPretty(form.controls.body.value, form.controls.contentType.value));
        this.textarea.resize();
        if (form.controls.contentType.value === 'application/json') {
            form.controls.body.setValidators([CustomValidators.json]);
        } else if (form.controls.contentType.value === 'application/xml') {
            form.controls.body.setValidators([CustomValidators.xml]);
        } else {
            form.controls.body.setValidators([]);
        }
        form.controls.body.updateValueAndValidity();
    }

    pretty(e: Event, form: FormGroup) {
        const textarea = e.target as HTMLTextAreaElement;
        textarea.value = toPretty(textarea.value, form.controls.contentType.value);
        this.textarea.resize();
    }

    formValid() {
        return this.settingsGroup.valid && this.requestGroups.every(x => x.valid);
    }

    save(start: boolean) {
        const test: Test = this.getTest();
        if (this.testId) {
            test.id = this.testId;
            this.testService.updateTest(test, start).subscribe(() => {
                this.toastNotifications.success('Test updated');
            }, error => {
                this.toastNotifications.error(error);
            });
        } else {
            this.testService.createTest(test, start).subscribe(t => {
                this.toastNotifications.success('Test created');
                this.router.navigateByUrl(`home/tests/edit/${t.id}`);
            }, error => {
                this.toastNotifications.error(error);
            });
        }
    }

    private getTest() {
        const requests = this.requestGroups
            .map(x => x.value)
            .map(x => {
                let body: string;
                if (this.hasBody(x.method.value)) {
                    if (x.contentType.value === 'application/json') {
                        body = JSON.stringify(JSON.parse(x.body));
                    } else {
                        body = x.body;
                    }
                }

                return {
                    host: x.host,
                    path: x.path === '' ? undefined : x.path,
                    method: x.method.value,
                    protocol: x.protocol.value,
                    body,
                    headers: JSON.stringify(toObject(x.headers)),
                    parameters: JSON.stringify(toObject(x.parameters)),
                    id: x.id
                } as TestRequest;
            });
        const test: Test = {
            ...this.settingsGroup.value,
            organizationId: this.member.organizationId,
            requests,
            duration: `00:${this.settingsGroup.value.duration}`
        };
        return test;
    }
}
