import { Component, EventEmitter, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Categorie } from 'src/app/Models/Categori.model';
import { NewsModel } from 'src/app/Models/News.model';
import { CategoriService } from 'src/app/Services/Categori.service';
import { NewsService } from 'src/app/Services/News.service';
import jwt_decode from "jwt-decode";
import { NotifierService } from 'angular-notifier';
import { Router } from '@angular/router';
import { UserService } from 'src/app/Services/User.service';

@Component({
  selector: 'app-addNews',
  templateUrl: './addNews.component.html',
  styleUrls: ['./addNews.component.css']
})
export class AddNewsComponent implements OnInit {

  categorieModel: Categorie[];
  test: string = ""
  newsModel = new NewsModel();
  Id:string
  // refreshCategori:EventEmitter<Categorie[]>

  constructor(private categoriService: CategoriService,
    private newsService: NewsService,
    private notifier: NotifierService,
    private router: Router,
    private userService:UserService
  ) { }

  setCategori(event) {
    this.test = event.target.value
  }
  add() {
    let cat = this.categorieModel.filter(x => x.name == this.test)[0]
    this.newsModel.categoriName = cat.name;
    let decode = jwt_decode(localStorage.getItem('token'))
    this.newsModel.managerId = decode.id
    this.newsModel.categoriId = "1"
    this.newsModel.datePost = new Date().toDateString()
    let l = this.newsService.addNews(this.newsModel).subscribe(data => {
      if (data.status === 200) {
        this.notifier.notify('success', "You news is added!");
        this.router.navigate(['/manager-panel'])

      }
      else {
        for (var i = 0; i < data.errors.length; i++) {
          console.log( data.errors[i])
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
    let decode = jwt_decode(localStorage.getItem('token'))
    this.Id = decode.id
    this.userService.getcurrentUser(this.Id).subscribe(data => {
      this.newsModel.managerName = data.fullName
    })
  }

}
