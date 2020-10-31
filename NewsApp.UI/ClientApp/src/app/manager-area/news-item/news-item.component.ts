import { Component, Input, OnInit } from '@angular/core';
import { NewsModel } from 'src/app/Models/News.model';

@Component({
  selector: 'app-news-item',
  templateUrl: './news-item.component.html',
  styleUrls: ['./news-item.component.css']
})
export class NewsItemComponent implements OnInit {
@Input() currentNews:NewsModel
@Input() index:number
  constructor() { }

  ngOnInit() {
  }

}
