import { Component, EventEmitter, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Categorie } from 'src/app/Models/Categori.model';
import { NewsModel } from 'src/app/Models/News.model';
import { CategoriService } from 'src/app/Services/Categori.service';
import { NewsService } from 'src/app/Services/News.service';
import jwt_decode from "jwt-decode";
import { NotifierService } from 'angular-notifier';
import { Router } from '@angular/router';

@Component({
  selector: 'app-addNews',
  templateUrl: './addNews.component.html',
  styleUrls: ['./addNews.component.css']
})
export class AddNewsComponent implements OnInit {

  categorieModel: Categorie[];
  test: string = ""
  newsModel = new NewsModel();
  // refreshCategori:EventEmitter<Categorie[]>

  constructor(private categoriService: CategoriService,
    private newsService: NewsService,
    private notifier: NotifierService,
    private router: Router
  ) { }

  setCategori(event) {
    this.test = event.target.value
  }
  add() {
    let cat = this.categorieModel.filter(x => x.name == this.test)[0]
    this.newsModel.categoriId = cat.name;
    let decode = jwt_decode(localStorage.getItem('token'))
    this.newsModel.managerId = decode.id
    let l = this.newsService.addNews(this.newsModel).subscribe(data => {
      if (data.status === 200) {
        this.notifier.notify('success', "You news is added!");
        this.router.navigate(['/manager-panel'])

      }
      else {
        for (var i = 0; i < data.errors.length; i++) {
          this.notifier.notify('error', data.errors[i]);
        }
      }
    });
  }

  ngOnInit() {
    this.categoriService.getAllCategorie().subscribe(data => {
      console.log(data)
      this.categorieModel = data;
      // this.refreshCategori.emit(this.categorieModel.slice()
      // )
    });
  }

}
