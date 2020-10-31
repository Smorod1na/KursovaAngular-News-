import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotifierService } from 'angular-notifier';
import { SignInModel } from '../Models/sign-in.model';
import { AuthService } from '../Services/auth.service';

import jwt_decode from "jwt-decode";

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {

  constructor(private authService: AuthService,
    private router: Router,
    private notifier: NotifierService
  ) { }

model=new SignInModel();


login(){
  this.notifier.hideAll();

  if(!this.model.isValid){
    this.notifier.notify('error', 'please enter all field for login')
  }
  else if(!this.model.isEmail()){
    this.notifier.notify('error', 'please enter correct email')
  }
  else{
    this.authService.SignIn(this.model).subscribe(
      data=>{
        if(data.status===200){
          console.log(data.status)
        window.localStorage.setItem('token',data.token);
        let decode=jwt_decode(data.token);
        localStorage.setItem('role',decode.roles)
        this.authService.changeMenuLogin.emit(true)
        if (decode.roles === "Admin") {
          this.router.navigate(['/admin-panel']);
        }
        else if (decode.roles === "User") {
          this.router.navigate(['/user-panel']);
        }
        else if (decode.roles === "Manager") {
          this.router.navigate(['/manager-panel']);
        }
      }
      else{
        for (var i = 0; i < data.errors.length; i++) {
          this.notifier.notify('error', data.errors[i]);
        }
      }
      setTimeout(() => {
      }, 1000);
      }
     
    )
  }
}









  ngOnInit() {
  }

}
