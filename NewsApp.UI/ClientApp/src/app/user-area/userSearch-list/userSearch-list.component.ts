import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { NewsModel } from 'src/app/Models/News.model';
import { NewsService } from 'src/app/Services/News.service';

@Component({
  selector: 'app-userSearch-list',
  templateUrl: './userSearch-list.component.html',
  styleUrls: ['./userSearch-list.component.css']
})
export class UserSearchListComponent implements OnInit {

  constructor(private route: ActivatedRoute,
    private newsService: NewsService,
    ) { }
  newsModel: NewsModel[] = []
  text: string
  ngOnInit() {
    this.route.params.subscribe((paramas: Params) => {
      this.text = paramas['text']
    })
    this.newsService.getAllNews().subscribe(data => {
      this.newsModel = data.filter(x => x.title.toLowerCase()
        .includes(this.text.toLowerCase()))
    })
  }

}
