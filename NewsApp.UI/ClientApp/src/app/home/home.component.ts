import { Component } from '@angular/core';
import { NewsModel } from '../Models/News.model';
import { NewsService } from '../Services/News.service';
import { UserService } from '../Services/User.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {
  constructor(private newsService: NewsService,
  ) { }
newsModel:NewsModel[]=[]


  ngOnInit() {
    this.newsService.getAllNews().subscribe(data => {
      this.newsModel = data
    })
    

  }
}
