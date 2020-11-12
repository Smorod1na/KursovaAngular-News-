import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { Router } from '@angular/router';
// import { EventEmitter } from 'protractor';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Models/api.responce';
import { SignInModel } from '../Models/sign-in.model';
import { SignUpModel } from '../Models/sign-up..model';
import jwt_decode from "jwt-decode";

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient,
    private router: Router) { }

  baseUrl = "/api/Acount"
  changeMenuLogin = new EventEmitter<boolean>();

  SignUp(model:SignUpModel):Observable<ApiResponse>{
    return this.http.post<ApiResponse>(this.baseUrl+"/register",model)
  }
  SignIn(model:SignInModel):Observable<ApiResponse>{
    return this.http.post<ApiResponse>(this.baseUrl+"/login",model)
  }

  LogOut(){
    localStorage.removeItem('token');
    localStorage.removeItem('role');

    this.changeMenuLogin.emit(false);
    this.router.navigate(['/'])
  }

  isAdmin() {
    let decode = jwt_decode(localStorage.getItem('token'))
    if (decode.roles == "Admin")
      return true;
    else
      return false;
  }
  isLoggedIn() {
    let token = localStorage.getItem('token');
    if (token !=null)
      return true;
    else
      return false;
  }
  isUserLoggedIn() {
    let decode = jwt_decode(localStorage.getItem('token'))
    if (decode.roles == "User")
      return true;
    else
      return false;
  }
  isManagerLoggedIn() {
    let decode = jwt_decode(localStorage.getItem('token'))
    if (decode.roles == "Manager")
      return true;
    else
      return false;
  }
}
