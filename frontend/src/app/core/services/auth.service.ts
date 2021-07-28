import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  login(email: string, password: string) {
  }

  logout() {
  }

  isAuthorized(): boolean {
    return true;
  }
}
