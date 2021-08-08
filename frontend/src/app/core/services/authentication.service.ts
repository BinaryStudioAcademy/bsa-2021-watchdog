import { Injectable } from '@angular/core';
import firebase from 'firebase/app';
import { AngularFireAuth } from '@angular/fire/auth';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { filter, mergeMap, tap } from 'rxjs/operators';
import { from, of } from 'rxjs';
import { User } from '@core/models/user';
import { UserService } from './user.service';
import { BaseComponent } from '@core/components/base/base.component';
import { HttpResponse } from '@angular/common/http';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService extends BaseComponent {
    private firebaseUser: firebase.User;
    private user: User;
    private readonly tokenHelper: JwtHelperService;

    private token: string | null;
    private rememberUser: boolean;

    constructor(
        private angularFireAuth: AngularFireAuth,
        private userService: UserService,
        private router: Router
    ) {
        super();
        this.tokenHelper = new JwtHelperService();
    }

    getFirebaseUser() {
        if (!this.firebaseUser) {
            this.firebaseUser = JSON.parse(localStorage.getItem('firebaseUser'));
        }
        return this.firebaseUser;
    }

    setFirebaseUser(user: firebase.User) {
        this.firebaseUser = user;
        localStorage.setItem('firebaseUser', JSON.stringify(this.firebaseUser));
    }

    isAuthenticated() {
        return Boolean(this.getFirebaseUser());
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

    signOnWithEmailAndPassword(userInfo: User, password: string, route: string[]) {
        return this.angularFireAuth
            .createUserWithEmailAndPassword(userInfo.email, password)
            .then(userCredential => {
                userInfo.uid = userCredential.user.uid;
                userInfo.avatarUrl = "";
                userInfo.registeredAt = new Date().toISOString();

                this.pushUserInfoToApi(userInfo)
                    .pipe(this.untilThis)
                    .subscribe(() => {
                        this.setUser(userInfo);
                        this.login(userCredential.user, route);
                    });
            })
            .catch(error => {
                console.warn(error);
            });
    }

    signInWithEmailAndPassword(email: string, password: string, route: string[]) {
        return this.angularFireAuth
            .signInWithEmailAndPassword(email, password)
            .then(userCredential => {
                this.pullUserInfoFromApi(userCredential.user.uid)
                    .pipe(this.untilThis)
                    .subscribe((response: HttpResponse<User>) => {
                        this.setUser(response.body);
                        this.login(userCredential.user, route);
                    });
            })
            .catch(error => {
                console.warn(error);
            });
    }

    signInWithGitHub(route: string[]) {
        const provider = new firebase.auth.GithubAuthProvider();
        provider.addScope('user');

        return this.angularFireAuth
            .signInWithPopup(provider)
            .then(userCredential => {
                if (userCredential.additionalUserInfo.isNewUser) {
                    const userInfo = this.pullUserInfoFromGitHub(userCredential);
                    this.pushUserInfoToApi(userInfo)
                        .pipe(this.untilThis)
                        .subscribe(() => {
                            this.setUser(userInfo);
                            this.login(userCredential.user, route);
                        });
                }
                else {
                    this.pullUserInfoFromApi(userCredential.user.uid)
                        .pipe(this.untilThis)
                        .subscribe((response: HttpResponse<User>) => {
                            this.setUser(response.body);
                            this.login(userCredential.user, route);
                        });
                }
            })
            .catch(error => {
                console.warn(error);
            });
    }

    signInWithGoogle(route: string[]) {
        const provider = new firebase.auth.GoogleAuthProvider();
        provider.addScope('https://www.googleapis.com/auth/userinfo.email');

        return this.angularFireAuth
            .signInWithPopup(provider)
            .then(userCredential => {
                if (userCredential.additionalUserInfo.isNewUser) {
                    const userInfo = this.pullUserInfoFromGoogle(userCredential);
                    this.pushUserInfoToApi(userInfo)
                        .pipe(this.untilThis)
                        .subscribe(() => {
                            this.setUser(userInfo);
                            this.login(userCredential.user, route);
                        });
                }
                else {
                    this.pullUserInfoFromApi(userCredential.user.uid)
                        .pipe(this.untilThis)
                        .subscribe((response: HttpResponse<User>) => {
                            this.setUser(response.body);
                            this.login(userCredential.user, route);
                        });
                }
            })
            .catch(error => {
                console.warn(error);
            });
    }

    signInWithFacebook(route: string[]) {
        const provider = new firebase.auth.FacebookAuthProvider();
        return this.angularFireAuth
            .signInWithPopup(provider)
            .then(userCredential => {
                this.login(userCredential.user, route);
                // TODO: implement setUser()
            })
            .catch(error => {
                console.warn(error);
            });
    }

    pushUserInfoToApi(user: User) {
        return this.userService.createUser(user);
    }

    pullUserInfoFromApi(uid: string) {
        return this.userService.getUser(uid);
    }

    pullUserInfoFromGitHub(credential: firebase.auth.UserCredential) {
        const user = {
            uid: credential.user.uid,
            email: credential.user.email,
            avatarUrl: credential.user.photoURL,
            registeredAt: new Date().toISOString()
        } as User;

        const name: string = credential.additionalUserInfo.profile['name'];
        if (name != null) {
            [user.firstName, user.lastName = ''] = name.split(' ');
        }

        return user;
    }

    pullUserInfoFromGoogle(credential: firebase.auth.UserCredential) {
        const user = {
            uid: credential.user.uid,
            email: credential.user.email,
            firstName: credential.additionalUserInfo.profile['given_name'],
            lastName: credential.additionalUserInfo.profile['family_name'],
            avatarUrl: credential.user.photoURL,
            registeredAt: new Date().toISOString()
        } as User;

        return user;
    }

    login(firebaseUser: firebase.User, route?: string[]) {
        this.rememberUser = localStorage.getItem('rememberUser') === 'true';
        this.setFirebaseUser(firebaseUser);
        firebaseUser.getIdToken()
            .then(token => {
                this.setJwToken(token);
                this.router.navigate(route);
            });
    }

    logout() {
        this.removeJwToken();
        this.angularFireAuth.signOut()
            .then(() => { })
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
