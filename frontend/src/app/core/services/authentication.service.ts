import { Injectable } from '@angular/core';
import firebase from 'firebase/app';
import { AngularFireAuth } from '@angular/fire/auth';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { filter, mergeMap, switchMap, tap } from 'rxjs/operators';
import { from, of } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '@shared/models/user/user';
import { NewUser } from '@shared/models/user/newUser';
import { UserService } from './user.service';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {
    private user: User;
    private readonly tokenHelper: JwtHelperService;

    private token: string | null;
    private rememberUser: boolean;

    constructor(
        private angularFireAuth: AngularFireAuth,
        private userService: UserService,
        private router: Router
    ) {
        this.tokenHelper = new JwtHelperService();
    }

    isAuthenticated() {
        return Boolean(this.getUser());
    }

    getUser() {
        if (!this.user) {
            this.user = JSON.parse(localStorage.getItem('user'));
        }
        return this.user;
    }

    setUser(user: User) {
        this.user = user;
        localStorage.setItem('user', JSON.stringify(this.user));
    }

    removeUser() {
        this.user = null;
        localStorage.removeItem('user');
    }

    getJwToken() {
        let currentToken = this.token;
        if (!currentToken && this.rememberUser) {
            currentToken = localStorage.getItem('jwt');
        }
        return !currentToken || this.tokenHelper.isTokenExpired(currentToken)
            ? this.refreshJwToken()
            : of(currentToken);
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

    refreshJwToken() {
        return this.angularFireAuth.authState
            .pipe(
                filter(firebaseUser => Boolean(firebaseUser)),
                mergeMap(firebaseUser => from(firebaseUser.getIdToken(true))),
                tap(token => localStorage.setItem('jwt', token))
            );
    }

    signOnWithEmailAndPassword(newUser: NewUser, password: string, route: string[]) {
        return from(this.angularFireAuth
            .createUserWithEmailAndPassword(newUser.email, password))
            .pipe(
                map(userCredential => ({
                    ...newUser,
                    uid: userCredential.user.uid,
                    registeredAt: new Date().toISOString() // to back-end
                })),
                switchMap(user => this.userService.createUser(user)),
                tap(user => this.setUser(user)),
                switchMap(() => this.login(route))
            );
    }

    signInWithEmailAndPassword(email: string, password: string, route: string[]) {
        return from(this.angularFireAuth
            .signInWithEmailAndPassword(email, password))
            .pipe(
                switchMap(userCredential => this.userService.getUser(userCredential.user.uid)),
                tap(user => this.setUser(user)),
                switchMap(() => this.login(route))
            );
    }

    signInWithGitHub(route: string[]) {
        const provider = new firebase.auth.GithubAuthProvider();
        provider.addScope('user');

        return from(this.angularFireAuth
            .signInWithPopup(provider))
            .pipe(
                switchMap(userCredential => {
                    if (userCredential.additionalUserInfo.isNewUser) {
                        const newUser = this.pullNewUserFromGitHub(userCredential);
                        return this.userService.createUser(newUser);
                    }
                    return this.userService.getUser(userCredential.user.uid);
                }),
                tap(user => this.setUser(user)),
                switchMap(() => this.login(route))
            );
    }

    signInWithGoogle(route: string[]) {
        const provider = new firebase.auth.GoogleAuthProvider();
        provider.addScope('https://www.googleapis.com/auth/userinfo.email');

        return from(this.angularFireAuth
            .signInWithPopup(provider))
            .pipe(
                switchMap(userCredential => {
                    if (userCredential.additionalUserInfo.isNewUser) {
                        const newUser = this.pullNewUserFromGoogle(userCredential);
                        return this.userService.createUser(newUser);
                    }
                    return this.userService.getUser(userCredential.user.uid);
                }),
                tap(user => this.setUser(user)),
                switchMap(() => this.login(route))
            );
    }

    signInWithFacebook(route: string[]) {
        const provider = new firebase.auth.FacebookAuthProvider();

        return from(this.angularFireAuth
            .signInWithPopup(provider))
            .pipe(
                switchMap(() => this.login(route))
            );
    }

    pullNewUserFromGitHub(credential: firebase.auth.UserCredential) {
        const user = {
            uid: credential.user.uid,
            email: credential.user.email,
            avatarUrl: credential.user.photoURL,
            registeredAt: new Date().toISOString()
        } as NewUser;

        const name: string = credential.additionalUserInfo.profile['name'];
        if (name != null) {
            [user.firstName, user.lastName = ''] = name.split(' ');
        }

        return user;
    }

    pullNewUserFromGoogle(credential: firebase.auth.UserCredential) {
        const user = {
            uid: credential.user.uid,
            email: credential.user.email,
            firstName: credential.additionalUserInfo.profile['given_name'],
            lastName: credential.additionalUserInfo.profile['family_name'],
            avatarUrl: credential.user.photoURL,
            registeredAt: new Date().toISOString()
        } as NewUser;

        return user;
    }

    login(route?: string[]) {
        this.rememberUser = localStorage.getItem('rememberUser') === 'true';
        return this.angularFireAuth.authState
            .pipe(
                switchMap(firebaseUser => from(firebaseUser.getIdToken())),
                tap(token => {
                    this.setJwToken(token);
                    this.router.navigate(route);
                })
            )
    }

    logout() {
        this.removeJwToken();
        this.removeUser();
        this.angularFireAuth.signOut()
            .catch(error => {
                console.warn(error);
            });
    }

    updatePassword(newPassword: string) {
        this.angularFireAuth.currentUser
            .then(user => {
                user.updatePassword(newPassword)
                    .then(() => { })
                    .catch((error) => {
                        console.warn(error);
                    });
            })
    }

}
