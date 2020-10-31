import { Component, OnInit } from '@angular/core';
import { NewsModel } from 'src/app/Models/News.model';
import { NewsService } from 'src/app/Services/News.service';
import jwt_decode from "jwt-decode";
import { UserService } from 'src/app/Services/User.service';
import { UserModel } from 'src/app/Models/User.model';
import { Categorie } from 'src/app/Models/Categori.model';
import { CategoriService } from 'src/app/Services/Categori.service';

@Component({
  selector: 'app-userProfil',
  templateUrl: './userProfil.component.html',
  styleUrls: ['./userProfil.component.css']
})
export class UserProfilComponent implements OnInit {

  constructor(private newsService: NewsService,
    private userService: UserService,
    private categoriService:CategoriService
  ) { }
  newsModel: NewsModel[] = []
  Id: string
  Name: string
  Image: string
  userModel: UserModel

  boolNews: boolean = false
  boolCategorie: boolean = false
  boolFavorite: boolean = false
  categoriModel: Categorie[] = []

  allManager:UserModel[]=[]
boolAuthor:boolean=false

showAuthors(){
  this.boolAuthor=!this.boolAuthor
}

  showNews() {
    this.boolNews = !this.boolNews
  }
  showCategorie() {
    this.boolCategorie = !this.boolCategorie
  }
  showFavorite() {
    this.boolFavorite = !this.boolFavorite
  }
  ngOnInit() {
    this.newsService.getAllNews().subscribe(data => {
      console.log(data)
      this.newsModel = data
    })
    let decode = jwt_decode(localStorage.getItem('token'))
    this.Name = decode.email
    this.Id = decode.id
    this.userService.getcurrentUser(this.Id).subscribe(data => {
      this.userModel = data
      
    })
    this.categoriService.getAllCategorie().subscribe(data=>{
      this.categoriModel=data
    })

    this.userService.getAllManager().subscribe(data=>{
      this.allManager=data
    })

  }
}
