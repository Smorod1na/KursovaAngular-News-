import { Component, OnInit } from '@angular/core';
import { NewsModel } from 'src/app/Models/News.model';
import { NewsService } from 'src/app/Services/News.service';
import jwt_decode from "jwt-decode";
import { UserService } from 'src/app/Services/User.service';
import { UserModel } from 'src/app/Models/User.model';
import { Categorie } from 'src/app/Models/Categori.model';
import { CategoriService } from 'src/app/Services/Categori.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-userProfil',
  templateUrl: './userProfil.component.html',
  styleUrls: ['./userProfil.component.css']
})
export class UserProfilComponent implements OnInit {

  constructor(private newsService: NewsService,
    private userService: UserService,
    private categoriService: CategoriService,
    private router:Router
  ) {
    this.userService.refreshUser.subscribe(data=>{
      this.userModel=data
      
    })
    this.newsService.refreshList.subscribe(data=>{
      this.newsModel=data
    })
   }
  newsModel: NewsModel[] = []
  Id: string
  Name: string
  Image: string
  userModel: UserModel

  boolNews: boolean = false
  boolCategorie: boolean = false
  boolFavorite: boolean = false
  categoriModel: Categorie[] = []

  allManager: UserModel[] = []
  boolAuthor: boolean = false

  refreshItemClick(model:NewsModel){
this.newsService.setItemNews(model)
  }

  testclick(fullname: string) {
    this.newsService.setNews(fullname)
    this.router.navigate(['/user-panel/'])
  }
  testclick2(categorie: string) {
    this.newsService.setNews(categorie)
  }

  showAuthors() {
    this.boolAuthor = !this.boolAuthor
  }
  showCategorie() {
    this.boolCategorie = !this.boolCategorie
  }
  showFavorite() {
    this.boolFavorite = !this.boolFavorite
  }


  ngOnInit() {

    // this.newsService.getAllNews().subscribe(data => {
    //   this.newsModel = data
    // })

    let decode = jwt_decode(localStorage.getItem('token'))
    this.Name = decode.email
    this.Id = decode.id
    console.log(decode.roles)
    this.userService.getcurrentUser(this.Id).subscribe(data => {
      this.userModel = data

    })
    this.categoriService.getAllCategorie().subscribe(data => {
      this.categoriModel = data
    })

    this.userService.getAllManager().subscribe(data => {
      this.allManager = data
    })

    this.newsService.getFavoritenews(this.Name).subscribe(data=>{
      this.newsModel=data
    })

  }
}
