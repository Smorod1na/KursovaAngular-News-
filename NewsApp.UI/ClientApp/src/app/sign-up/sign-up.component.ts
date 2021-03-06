import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NotifierService } from 'angular-notifier';
import { SignUpModel } from '../Models/sign-up..model';
import { AuthService } from '../Services/auth.service';
@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {

  constructor(
    private notifier:NotifierService,
    private authService:AuthService,
    private router:Router) { }


    model=new SignUpModel();
    confirmPassword:string

    register(){
      this.notifier.hideAll();
      if (!this.model.isEmail()) {
        this.notifier.notify('error', "Please, enter correct email!");
      }
      else if (this.model.Password != this.confirmPassword){  
        this.notifier.notify('error', "password don`t match");
      }
      else if(this.model.isValid()) {
        this.authService.SignUp(this.model).subscribe(
          data => {
            if (data.status === 200) {
              this.notifier.notify('success', "You seccess registered in system!");
              this.router.navigate(['/sign-in'])
         
            }
            else {
              for (var i = 0; i < data.errors.length; i++) {
                this.notifier.notify('error', data.errors[i]);
              }
            }
    
            // setTimeout(() => {
            //   this.spinner.hide()
            // }, 2000);
    
          }
        )
      }
      else {
        this.notifier.notify('error', "Please, enter all fieald for register!");
      }
    }



  ngOnInit(
    ) {
  }

}
