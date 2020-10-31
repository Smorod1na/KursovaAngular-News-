import { Component, OnInit } from '@angular/core';
import { NewsModel } from '../Models/News.model';
import { NewsService } from '../Services/News.service';

@Component({
  selector: 'app-manager-area',
  templateUrl: './manager-area.component.html',
  styleUrls: ['./manager-area.component.css']
})
export class ManagerAreaComponent implements OnInit {

  constructor(private newsService:NewsService) { }
  newsModel:NewsModel[];

  ngOnInit() {
    this.newsService.getAllNews().subscribe(data=>{
      console.log(data)
      this.newsModel=data
    })
  }

}
