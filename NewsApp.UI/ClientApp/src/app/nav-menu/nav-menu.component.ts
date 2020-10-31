import { Component } from '@angular/core';
import { AuthService } from '../Services/auth.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  isLogin: boolean = false;
  isAdmin: boolean = false;

  constructor(private authservice: AuthService) { }

ngOnInit(){
  let token=localStorage.getItem('token')
  if (token != null) {
    this.isLogin = true;
    this.isAdmin = this.authservice.isAdmin();
  }
  else {
    this.isLogin = false;
    
  }
  this.authservice.changeMenuLogin.subscribe(
    (data) => {
      this.isAdmin = this.authservice.isAdmin();
      this.isLogin = data;
    }
  )
}

logOut() {
  this.authservice.LogOut();
}




  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
}
