import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { NewsModel } from 'src/app/Models/News.model';
import { NewsService } from 'src/app/Services/News.service';

@Component({
  selector: 'app-User-itemNews',
  templateUrl: './User-itemNews.component.html',
  styleUrls: ['./User-itemNews.component.css']
})
export class UserItemNewsComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private newsService: NewsService
  ) { }
  title: string
  model: NewsModel
  value: boolean = true
    comment:string=""
addComment(){

}


  changeValue(value: string) {
    if (value == "description")
      this.value = true
    else
      this.value = false
  }

  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.title = params["title"]
    })

    this.newsService.getAllNews().subscribe(data => {
      this.model = data.filter(x => x.title == this.title)[0]
    })

  }

}
