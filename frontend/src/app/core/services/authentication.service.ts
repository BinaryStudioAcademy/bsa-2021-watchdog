import { MemberService } from '@core/services/member.service';
import { Member } from '@shared/models/member/member';
import { Injectable } from '@angular/core';
import firebase from 'firebase/app';
import { AngularFireAuth } from '@angular/fire/auth';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { filter, mergeMap, switchMap, tap, map } from 'rxjs/operators';
import { from, of, Observable, Subject, merge } from 'rxjs';
import { User } from '@shared/models/user/user';
import { NewUser } from '@shared/models/user/newUser';
import { FullRegistrationDto } from '@modules/registration/DTO/full-registration-dto';
import { PartialRegistrationDto } from '@modules/registration/DTO/partial-registration-dto';
import { Organization } from '@shared/models/organization/organization';
import { UserService } from './user.service';
import { RegistrationService } from './registration.service';
import { OrganizationService } from './organization.service';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {
    private static user: User;
    private static member: Member;
    private readonly tokenHelper: JwtHelperService;

    private token: string | null;
    private rememberUser: boolean;

    constructor(
        private angularFireAuth: AngularFireAuth,
        private userService: UserService,
        private registrationService: RegistrationService,
        private organizationService: OrganizationService,
        private memberService: MemberService,
        private router: Router
    ) {
        this.tokenHelper = new JwtHelperService();
    }

    isUserSignByEmailAndPassword() {
        return localStorage.getItem('isSignByEmailAndPassword') === 'true';
    }

    isAuthenticated(): boolean {
        return Boolean(this.getUser()) && Boolean(this.getUser().registeredAt);
    }

    getUser() {
        if (!AuthenticationService.user) {
            AuthenticationService.user = JSON.parse(localStorage.getItem('user'));
        }
        return AuthenticationService.user;
    }

    getUserId(): number {
        return this.getUser()?.id;
    }

    private static organizationSource: Subject<Organization> = new Subject<Organization>();

    getOrganization(): Observable<Organization> {
        return merge(
            this.organizationService.getCurrentOrganization(this.getUser().id),
            AuthenticationService.organizationSource.asObservable()
        );
    }

    setOrganization(organization: Organization) {
        this.organizationService.setCurrentOrganization(organization);
        this.memberService.clearMember();
        this.memberService.getCurrentMember(organization.id, this.getUser().id)
            .subscribe(() => AuthenticationService.organizationSource.next(organization));
    }

    private static memberSource: Subject<Member> = new Subject<Member>();

    getMember(): Observable<Member> {
        return this.getOrganization()
            .pipe(switchMap(org => merge(
                this.memberService.getCurrentMember(org.id, this.getUser().id),
                AuthenticationService.memberSource.asObservable()
            )));
    }

    setUser(user: User) {
        AuthenticationService.user = user;
        localStorage.setItem('user', JSON.stringify(AuthenticationService.user));
    }

    removeUser() {
        AuthenticationService.user = null;
        localStorage.removeItem('user');
    }

    removeIsSignByEmailAndPassword() {
        localStorage.removeItem('isSignByEmailAndPassword');
    }

    getJwToken() {
        if (!this.token) {
            this.token = localStorage.getItem('jwt');
        }
        if (this.token && !this.tokenHelper.isTokenExpired(this.token)) {
            return of(this.token);
        }
        return this.refreshJwToken();
    }

    setJwToken(token: string) {
        this.token = token;
        if (this.rememberUser) {
            localStorage.setItem('jwt', this.token);
        }
    }

    removeJwToken() {
        this.token = null;
        localStorage.removeItem('jwt');
    }

    refreshJwToken(forceRefresh = false) {
        return this.angularFireAuth.authState
            .pipe(
                filter(firebaseUser => Boolean(firebaseUser)),
                mergeMap(firebaseUser => from(firebaseUser.getIdToken(forceRefresh))),
                tap(token => {
                    localStorage.setItem('jwt', token);
                    this.token = token;
                })
            );
    }

    finishPartialRegistration(regDto: PartialRegistrationDto, route: string[]) {
        return this.registrationService.performPartialRegistration(regDto)
            .pipe(
                tap(user => {
                    localStorage.setItem('isSignByEmailAndPassword', 'false');
                    this.setUser(user);
                }),
                switchMap(() => this.login(route))
            );
    }

    signOnWithEmailAndPassword(regDto: FullRegistrationDto, password: string, route: string[]) {
        this.logout();
        return from(this.angularFireAuth
            .createUserWithEmailAndPassword(regDto.user.email, password))
            .pipe(
                map(userCredential => {
                    const dto = regDto;
                    dto.user.uid = userCredential.user.uid;
                    return dto;
                }),
                switchMap(dto => this.registrationService.performFullRegistration(dto)),
                tap(user => {
                    localStorage.setItem('isSignByEmailAndPassword', 'true');
                    this.setUser(user);
                }),
                switchMap(() => this.login(route))
            );
    }

    signInWithEmailAndPassword(email: string, password: string, route: string[]) {
        this.logout();
        return from(this.angularFireAuth
            .signInWithEmailAndPassword(email, password))
            .pipe(
                switchMap(userCredential => this.userService.getUser(userCredential.user.uid)),
                tap(user => {
                    localStorage.setItem('isSignByEmailAndPassword', 'true');
                    return this.setUser(user);
                }),
                switchMap(() => this.login(route))
            );
    }

    signInWithGitHub(route: string[]) {
        this.logout();
        const provider = new firebase.auth.GithubAuthProvider();
        provider.addScope('user');

        return from(this.angularFireAuth
            .signInWithPopup(provider))
            .pipe(
                switchMap(userCredential =>
                    this.userService.getUser(userCredential.user.uid)
                        .pipe(
                            switchMap(user => (user ? of(user)
                                : this.userService.createUser(this.pullNewUserFromGitHub(userCredential))))
                        )),
                tap(user => {
                    localStorage.setItem('isSignByEmailAndPassword', 'false');
                    this.setUser(user);
                }),
                switchMap(() => this.login(route))
            );
    }

    signInWithGoogle(route: string[]) {
        this.logout();
        const provider = new firebase.auth.GoogleAuthProvider();
        provider.addScope('https://www.googleapis.com/auth/userinfo.email');

        return from(this.angularFireAuth
            .signInWithPopup(provider))
            .pipe(
                switchMap(userCredential =>
                    this.userService.getUser(userCredential.user.uid)
                        .pipe(
                            switchMap(user => (user ? of(user)
                                : this.userService.createUser(this.pullNewUserFromGoogle(userCredential))))
                        )),
                tap(user => {
                    localStorage.setItem('isSignByEmailAndPassword', 'false');
                    return this.setUser(user);
                }),
                switchMap(() => this.login(route))
            );
    }

    signInWithFacebook(route: string[]) {
        this.logout();
        const provider = new firebase.auth.FacebookAuthProvider();

        return from(this.angularFireAuth
            .signInWithPopup(provider))
            .pipe(
                switchMap(userCredential =>
                    this.userService.getUser(userCredential.user.uid)
                        .pipe(
                            switchMap(user => (user ? of(user)
                                : this.userService.createUser(this.pullNewUserFromFacebook(userCredential))))
                        )),
                tap(user => {
                    localStorage.setItem('isSignByEmailAndPassword', 'false');
                    return this.setUser(user);
                }),
                switchMap(() => this.login(route))
            );
    }

    pullNewUserFromGitHub(credential: firebase.auth.UserCredential) {
        const user = {
            uid: credential.user.uid,
            email: credential.user.email,
            avatarUrl: credential.user.photoURL,
        } as NewUser;

        const { name } = credential.additionalUserInfo.profile as { name: string };
        if (name != null) {
            [user.firstName, user.lastName = ''] = name.split(' ');
        }
        return user;
    }

    pullNewUserFromGoogle(credential: firebase.auth.UserCredential) {
        const user = {
            uid: credential.user.uid,
            email: credential.user.email,
            firstName: (credential.additionalUserInfo.profile as { given_name: string }).given_name,
            lastName: (credential.additionalUserInfo.profile as { family_name: string }).family_name,
            avatarUrl: credential.user.photoURL
        } as NewUser;

        return user;
    }

    pullNewUserFromFacebook(credential: firebase.auth.UserCredential) {
        const user = {
            uid: credential.user.uid,
            email: credential.user.email,
            firstName: (credential.additionalUserInfo.profile as { first_name: string }).first_name,
            lastName: (credential.additionalUserInfo.profile as { last_name: string }).last_name,
            avatarUrl: credential.user.photoURL
        } as NewUser;

        return user;
    }

    login(route?: string[]) {
        this.rememberUser = localStorage.getItem('rememberUser') === 'true';
        return from(this.angularFireAuth.currentUser)
            .pipe(
                filter(firebaseUser => Boolean(firebaseUser)),
                switchMap(firebaseUser => from(firebaseUser.getIdToken())),
                tap(token => {
                    this.setJwToken(token);
                    this.router.navigate(route);
                })
            );
    }

    logout() {
        this.removeJwToken();
        this.removeUser();
        this.organizationService.clearOrganization();
        this.memberService.clearMember();
        this.removeIsSignByEmailAndPassword();
        this.angularFireAuth.signOut()
            .catch(error => {
                console.warn(error);
            });
    }

    updatePassword(newPassword: string) {
        this.angularFireAuth.currentUser
            .then(user => {
                user.updatePassword(newPassword)
                    .catch((error) => {
                        console.warn(error);
                    });
            });
    }
}
