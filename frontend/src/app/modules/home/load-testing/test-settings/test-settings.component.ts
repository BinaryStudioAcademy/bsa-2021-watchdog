import { Test } from '@shared/models/test/test';
import { TestMethod } from '@shared/models/test/enums/test-method';
import { tap } from 'rxjs/operators';
import { Member } from '@shared/models/member/member';
import { ProjectService } from '@core/services/project.service';
import { Project } from '@shared/models/projects/project';
import { regexs } from '@shared/constants/regexs';
import { FormControl, FormGroup, Validators, AbstractControl } from '@angular/forms';
import { ToastNotificationService } from '@core/services/toast-notification.service';
import { BaseComponent } from '@core/components/base/base.component';
import { AuthenticationService } from '@core/services/authentication.service';
import { Component, OnInit, ViewChild } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { protocolOptions, typeOptions, methodOptions } from './test-settings.constant';
import { InputTextarea } from 'primeng/inputtextarea';
import { TestRequest } from '@shared/models/test/test-request';
import { KeyValuePair } from '@shared/models/key-value-pair';
import { toKeyValuePairs, toObject } from '@core/utils/kvp.utils';
import { TestService } from '@core/services/test.service';

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
    @ViewChild(InputTextarea) textarea: InputTextarea;
    constructor(
        private authService: AuthenticationService,
        private activatedRoute: ActivatedRoute,
        private toastNotifications: ToastNotificationService,
        private projectService: ProjectService,
        private testService: TestService,
        private router: Router
    ) { super(); }

    async ngOnInit(): Promise<void> {
        this.initFormGroups();
        this.authService.getMember()
            .pipe(
                this.untilThis,
                tap(member => {
                    this.member = member;
                })
            )
            .subscribe(() => {
                this.initProjects().subscribe();
            }, error => {
                this.toastNotifications.error(error);
            });

        this.activatedRoute.params
            .pipe(this.untilThis)
            .subscribe(params => {
                if (params.id) {
                    this.header = 'Edit test';
                    this.initEditMode(+params.id);
                } else {
                    this.header = 'Add a new test';
                }
            }, error => {
                this.toastNotifications.error(error);
            });
    }
    initEditMode(id: number) {
        this.testId = id;
        this.testService.getTestById(id)
            .subscribe(test => {
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
                    x.id
                ));
            }, () => {
                this.isNotFound = true;
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
                    this.validateTime
                ]
            ),
            projectId: new FormControl(
                null
            )
        });

        this.requestGroups = [this.generateRequestGroup()];
    }
    generateRequestGroup(
        protocol = protocolOptions[0],
        host = '',
        path = '',
        method = methodOptions[0],
        body = '{\n  "json": "body"\n}',
        headers = [{}],
        parameters = [{}],
        id = undefined
    ): FormGroup {
        return new FormGroup({
            protocol: new FormControl(
                protocol,
                [
                    Validators.required,
                ]
            ),
            host: new FormControl(
                host,
                [
                    Validators.required,
                ]
            ),
            path: new FormControl(path),
            method: new FormControl(
                method,
                [
                    Validators.required,
                ]
            ),
            headers: new FormControl(headers),
            parameters: new FormControl(parameters),
            body: new FormControl(
                body,
                [
                    this.validateJson
                ]
            ),
            id: new FormControl(id),
            collapsed: new FormControl(false)
        });
    }

    validateJson = (control: AbstractControl) => {
        if (control.value === '') {
            return null;
        }
        try {
            JSON.parse(control.value);
        } catch (error) {
            return { invalidJson: error.message };
        }
        return null;
    };

    initProjects() {
        return this.projectService.getProjectsByOrganizationId(this.member.organizationId)
            .pipe(tap(projects => {
                this.projects = projects;
            }));
    }

    get name() { return this.settingsGroup.controls.name; }
    get type() { return this.settingsGroup.controls.type; }
    get clients() { return this.settingsGroup.controls.clients; }
    get duration() { return this.settingsGroup.controls.duration; }

    validateTime = (control: AbstractControl) => {
        const radix = 10;
        const [minutes, seconds] = (control.value as string).split(':').map(x => parseInt(x, radix));
        if (minutes > 59 || seconds > 59) {
            return { invalidTime: true };
        }
        return null;
    };

    addRequest() {
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

    getUrl(form: FormGroup) {
        const protocol = form.controls.protocol.value.label;
        const host = form.controls.host.value;
        const path = !form.controls.path.value ? '' : `/${form.controls.path.value}`;
        const params = form.controls.parameters.value as KeyValuePair[];
        const paramsString = params[0]?.key ? `?${params.filter(x => x.key).map(x => `${x.key}=${x.value ?? ''}`).join('&')}` : '';
        return `${protocol}://${host === '' ? 'example.com' : host}${path}${paramsString}`;
    }

    handle(e: KeyboardEvent) {
        if (e.key === 'Tab') {
            e.preventDefault();
            const textarea = e.target as HTMLTextAreaElement;
            const start = textarea.selectionStart;
            const end = textarea.selectionEnd;

            textarea.value = `${textarea.value.substring(0, start)}  ${textarea.value.substring(end)}`;

            textarea.selectionStart = start + 2;
            textarea.selectionEnd = start + 2;
        } else if (e.key === '"') {
            e.preventDefault();
            const textarea = e.target as HTMLTextAreaElement;
            const start = textarea.selectionStart;
            const end = textarea.selectionEnd;

            textarea.value = `${textarea.value.substring(0, start)}""${textarea.value.substring(end)}`;

            textarea.selectionStart = start + 1;
            textarea.selectionEnd = start + 1;
        } else if (e.key === '{') {
            e.preventDefault();
            const textarea = e.target as HTMLTextAreaElement;
            const start = textarea.selectionStart;
            const end = textarea.selectionEnd;

            textarea.value = `${textarea.value.substring(0, start)}{}${textarea.value.substring(end)}`;

            textarea.selectionStart = start + 1;
            textarea.selectionEnd = start + 1;
        } else if (e.key === '[') {
            e.preventDefault();
            const textarea = e.target as HTMLTextAreaElement;
            const start = textarea.selectionStart;
            const end = textarea.selectionEnd;

            textarea.value = `${textarea.value.substring(0, start)}[]${textarea.value.substring(end)}`;

            textarea.selectionStart = start + 1;
            textarea.selectionEnd = start + 1;
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
        this.textarea.resize();
    }

    pretty(e: Event) {
        const textarea = e.target as HTMLTextAreaElement;
        try {
            textarea.value = JSON.stringify(JSON.parse(textarea.value), null, 2);
        } catch {
            this.textarea.resize();
        }
        this.textarea.resize();
    }

    formValid() {
        return this.settingsGroup.valid && this.requestGroups.every(x => x.valid);
    }

    save() {
        const test: Test = this.getTest();
        if (this.testId) {
            test.id = this.testId;
            this.testService.updateTest(test).subscribe(() => {
                this.toastNotifications.success('Test updated');
            }, error => {
                this.toastNotifications.error(error);
            });
        } else {
            this.testService.createTest(test).subscribe(t => {
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
            .map(x => ({
                host: x.host,
                path: x.path === '' ? undefined : x.path,
                method: x.method.value,
                protocol: x.protocol.value,
                body: x.method.value !== TestMethod.Get && x.method.value !== TestMethod.Delete
                    ? JSON.stringify(JSON.parse(x.body))
                    : undefined,
                headers: JSON.stringify(toObject(x.headers)),
                parameters: JSON.stringify(toObject(x.parameters)),
                id: x.id
            } as TestRequest));
        const test: Test = {
            ...this.settingsGroup.value,
            organizationId: this.member.organizationId,
            requests,
            duration: `00:${this.settingsGroup.value.duration}`
        };
        return test;
    }
}
