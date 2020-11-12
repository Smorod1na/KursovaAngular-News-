import { Component, OnInit } from '@angular/core';
import { UserModel } from 'src/app/Models/User.model';
import { UserService } from 'src/app/Services/User.service';
import jwt_decode from "jwt-decode";

@Component({
  selector: 'app-managerProfile',
  templateUrl: './managerProfile.component.html',
  styleUrls: ['./managerProfile.component.css']
})
export class ManagerProfileComponent implements OnInit {

  constructor(
    private userService:UserService
  ) { 
    this.userService.refreshUser.subscribe(data=>{
      this.userModel=data
    })
  }
  userModel: UserModel
Id:string
  ngOnInit() {
    let decode = jwt_decode(localStorage.getItem('token'))
    this.Id = decode.id
    this.userService.getcurrentUser(this.Id).subscribe(data => {
      this.userModel = data
      
    })
  }

}
