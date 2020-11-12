import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/Models/User.model';
import jwt_decode from "jwt-decode";
import { UserService } from 'src/app/Services/User.service';

@Component({
  selector: 'app-editUserProfile',
  templateUrl: './editUserProfile.component.html',
  styleUrls: ['./editUserProfile.component.css']
})
export class EditUserProfileComponent implements OnInit {

  constructor(
    private userService: UserService
  ) { }
  userModel: UserModel
  Id: string

  edit() {
    this.userService.editUser(this.userModel, this.Id).subscribe(data=>{
      this.userService.setUserInfo(this.userModel)
    },error=>{
      console.log(error)
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
