import { Component, EventEmitter, OnInit } from '@angular/core';
import { NewsModel } from 'src/app/Models/News.model';
import { NewsService } from 'src/app/Services/News.service';

@Component({
  selector: 'app-news-list',
  templateUrl: './news-list.component.html',
  styleUrls: ['./news-list.component.css']
})
export class NewsListComponent implements OnInit {


  constructor(private newsService: NewsService
  ) {
    this.newsService.refreshString.subscribe(data => {
      this.filter = data
      this.newsService.getPagNews(1,this.filter).subscribe(data=>{
        this.modelForm = data.news
        this.countButtons=data.countButton
        this.refreshList.emit(this.modelForm)
      })
    })
  }
  newsModel: NewsModel[] = [];
  refreshList = new EventEmitter<NewsModel[]>()
  modelForm: NewsModel[] = []
  countButtons: number 
  currentNumber: number = 1
  filter:string="null"
  counter(i: number) {
    return new Array(i);
  }
  setPrevNext(value: boolean) {
    if (value) {
      if (this.currentNumber > 1) {
        this.currentNumber--;
        this.newsService.getPagNews(this.currentNumber,this.filter).subscribe(data => {
          this.modelForm = data.news
        })
        this.refreshList.emit(this.modelForm.slice())
      }
    }
    else {
      if (this.currentNumber < this.countButtons) {
        this.currentNumber++;
        this.newsService.getPagNews(this.currentNumber,this.filter).subscribe(data => {
          this.modelForm = data.news
        })

        this.refreshList.emit(this.modelForm.slice())
      }
    }
  }
  setmodelForm(value: number) {
    
    this.currentNumber = value
    this.newsService.getPagNews(value,this.filter).subscribe(data => {
      this.modelForm = data.news
    })

    this.refreshList.emit(this.modelForm.slice())
  }
  ngOnInit() {

    this.newsService.getPagNews(1,this.filter).subscribe(data => {
      this.modelForm = data.news
      this.countButtons=data.countButton
    })
  }

}
