import { Component, OnInit } from '@angular/core';
import { NewsModel } from 'src/app/Models/News.model';
import { NewsService } from 'src/app/Services/News.service';
import jwt_decode from "jwt-decode";

@Component({
  selector: 'app-managerNews-list',
  templateUrl: './managerNews-list.component.html',
  styleUrls: ['./managerNews-list.component.css']
})
export class ManagerNewsListComponent implements OnInit {

  constructor(private newsService: NewsService) { }
  Id: string

  newsModel: NewsModel[] = []

  ngOnInit() {
    let decode = jwt_decode(localStorage.getItem('token'))
    this.Id = decode.id
    this.newsService.getManagerNews(this.Id).subscribe(data => {
      console.log(data)
      this.newsModel = data
    })
  }

}
