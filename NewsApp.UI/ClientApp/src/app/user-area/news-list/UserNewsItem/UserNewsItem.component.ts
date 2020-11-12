import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { NewsModel } from 'src/app/Models/News.model';

@Component({
  selector: 'app-UserNewsItem',
  templateUrl: './UserNewsItem.component.html',
  styleUrls: ['./UserNewsItem.component.css']
})
export class UserNewsItemComponent implements OnInit {
  @Input() currentNews: NewsModel
  constructor() { }
  refreshList = new EventEmitter<NewsModel>()

  ngOnInit() {
    this.refreshList.emit(this.currentNews)

  }

}
