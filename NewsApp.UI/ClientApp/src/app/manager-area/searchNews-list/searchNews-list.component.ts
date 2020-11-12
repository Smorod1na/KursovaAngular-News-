import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { NewsModel } from 'src/app/Models/News.model';
import { NewsService } from 'src/app/Services/News.service';

@Component({
  selector: 'app-searchNews-list',
  templateUrl: './searchNews-list.component.html',
  styleUrls: ['./searchNews-list.component.css']
})
export class SearchNewsListComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private newsService: NewsService
  ) { }
  newsModel: NewsModel[] = []
  searchText: string
  ngOnInit() {
    this.route.params.subscribe((params: Params) => {
      this.searchText = params["text"]
    })
    this.newsService.getAllNews().subscribe(data => {
      this.newsModel = data.filter(x => x.title.toLowerCase()
      .includes(this.searchText.toLowerCase()))
    })
  }

}
