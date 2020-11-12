import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/Models/User.model';
import { UserService } from 'src/app/Services/User.service';
import jwt_decode from "jwt-decode";
import { NotifierService } from 'angular-notifier';
import { Router } from '@angular/router';

@Component({
  selector: 'app-editManagerProfile',
  templateUrl: './editManagerProfile.component.html',
  styleUrls: ['./editManagerProfile.component.css']
})
export class EditManagerProfileComponent implements OnInit {

  constructor(
    private userService:UserService,
    private notifier:NotifierService,
    private router:Router
  ) { }
userModel:UserModel
Id:string
edit() {
  this.userService.editUser(this.userModel, this.Id).subscribe(data=>{
    if (data.status === 200) {
      this.userService.setUserInfo(this.userModel)
      this.notifier.notify('success', "You profile is changed!");
      this.router.navigate(['/manager-panel'])

    }
    else {
      for (var i = 0; i < data.errors.length; i++) {
        console.log( data.errors[i])
        this.notifier.notify('error', data.errors[i]);
      }
  }
  })
}
  ngOnInit() {
    let decode = jwt_decode(localStorage.getItem('token'))
    this.Id = decode.id
    this.userService.getcurrentUser(this.Id).subscribe(data => {
      this.userModel = data

    })
  }

}
