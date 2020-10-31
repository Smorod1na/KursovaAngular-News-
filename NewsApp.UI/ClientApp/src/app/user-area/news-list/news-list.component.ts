import { Component, OnInit } from '@angular/core';
import { NewsModel } from 'src/app/Models/News.model';
import { NewsService } from 'src/app/Services/News.service';

@Component({
  selector: 'app-news-list',
  templateUrl: './news-list.component.html',
  styleUrls: ['./news-list.component.css']
})
export class NewsListComponent implements OnInit {

  
  constructor(private newsService: NewsService
    ) { }
    newsModel: NewsModel[] = []

    
  ngOnInit() {  this.newsService.getAllNews().subscribe(data => {
    console.log(data)
    this.newsModel = data
  })
  }

}
