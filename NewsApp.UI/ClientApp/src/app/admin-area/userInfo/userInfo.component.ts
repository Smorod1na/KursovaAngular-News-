import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { NotifierService } from 'angular-notifier';
import { UserModel } from 'src/app/Models/User.model';
import { UserService } from 'src/app/Services/User.service';

@Component({
  selector: 'app-userInfo',
  templateUrl: './userInfo.component.html',
  styleUrls: ['./userInfo.component.css']
})
export class UserInfoComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private userService: UserService,
    private notifier:NotifierService,
    private router:Router
  ) { 
    this.userService.setUserInfo(this.model)
  }
  fullname: string
  model: UserModel
  isChangeRole: boolean = false

  changeRole() {
    this.isChangeRole = !this.isChangeRole
  }
  deleteUser(){
    this.userService.deleteUser(this.model).subscribe(data=>{
      if (data.status === 200) {
        this.notifier.notify('success', "user is deleted!");
        this.router.navigate(['/admin-panel'])
      }
      else {
        for (var i = 0; i < data.errors.length; i++) {
          console.log( data.errors[i])
          this.notifier.notify('error', data.errors[i]);
        }
      }
    })
  }
  saveChangeRole(role: string) {
    this.userService.changeUserRole(this.model, role).subscribe(data => {
      if (data.status === 200) {
        this.notifier.notify('success', "role is changed!");
        this.router.navigate(['/admin-panel'])

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
    
    this.route.params.subscribe((params: Params) => {

      this.userService.getAllUser().subscribe(data => {
        this.model = data.filter(x => x.fullName == params["fullname"])[0]
      })


    })
  }

}
