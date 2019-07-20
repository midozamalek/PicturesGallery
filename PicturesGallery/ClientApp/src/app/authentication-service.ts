import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { UserModel } from './login/user-model';
 
@Injectable()
export class AuthenticationService {

  baseUrl: string;
   
  constructor(private http: HttpClient, @Inject('BASE_URL') _baseUrl: string) { this.baseUrl = _baseUrl; }

  login(username: string, password: string) {
    let user = new UserModel();
    user.userName = username;
    user.password = password; 
      localStorage.setItem('currentUser', JSON.stringify(user));        
    return user;       
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
  }

  IsAuthinticated() {
    return localStorage.getItem("currentUser") != null;
  }
}
