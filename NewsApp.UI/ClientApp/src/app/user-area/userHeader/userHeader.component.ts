import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/Services/auth.service';
import { NewsService } from 'src/app/Services/News.service';

@Component({
  selector: 'app-userHeader',
  templateUrl: './userHeader.component.html',
  styleUrls: ['./userHeader.component.css']
})
export class UserHeaderComponent implements OnInit {

  constructor(private authservice:AuthService,
    private newsService:NewsService) { }
  isExpanded = false;
  searchtext:string

  testclick(fullname: string) {
    this.newsService.setNews(fullname)
  }

  ngOnInit() {
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
