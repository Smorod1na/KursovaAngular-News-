import { Component, OnInit } from '@angular/core';
import { UserModel } from '../Models/User.model';
import { AuthService } from '../Services/auth.service';
import { UserService } from '../Services/User.service';

@Component({
  selector: 'app-admin-area',
  templateUrl: './admin-area.component.html',
  styleUrls: ['./admin-area.component.css']
})
export class AdminAreaComponent implements OnInit {

  constructor(
    private userService: UserService,
    private authservice:AuthService
  ) { }
  isCollapsed = false;
  theme = true
  allUsers:UserModel[]=[]
  ngOnInit() {
    this.userService.getAllUser().subscribe(data=>{
      this.allUsers=data
    })
  }
  logOut() {
    this.authservice.LogOut();
  }

}
