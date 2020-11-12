import { Component, EventEmitter, Input, OnInit } from '@angular/core';
import { NewsModel } from 'src/app/Models/News.model';

@Component({
  selector: 'app-managerNews-item',
  templateUrl: './managerNews-item.component.html',
  styleUrls: ['./managerNews-item.component.css']
})
export class ManagerNewsItemComponent implements OnInit {
newsEmiter=new EventEmitter<NewsModel>();
  constructor() { }
@Input() currentNews:NewsModel
  ngOnInit() {
    if(this.currentNews.image=="")
    {
      this.currentNews.image="https://previews.123rf.com/images/alexmas/alexmas1412/alexmas141200004/34251857-workers-unload-the-car-with-boxes-3d-image-white-background-.jpg"
    this.newsEmiter.emit(this.currentNews);
    }
  }

}
