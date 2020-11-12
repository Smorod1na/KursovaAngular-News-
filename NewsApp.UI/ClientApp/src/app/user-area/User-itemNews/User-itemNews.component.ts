import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params } from '@angular/router';
import { CommentModel } from 'src/app/Models/comment.model';
import { NewsModel } from 'src/app/Models/News.model';
import { CommentService } from 'src/app/Services/comment.service';
import { NewsService } from 'src/app/Services/News.service';
import { UserService } from 'src/app/Services/User.service';
import jwt_decode from "jwt-decode";
import { NotifierService } from 'angular-notifier';

@Component({
  selector: 'app-User-itemNews',
  templateUrl: './User-itemNews.component.html',
  styleUrls: ['./User-itemNews.component.css']
})
export class UserItemNewsComponent implements OnInit {

  constructor(
    private route: ActivatedRoute,
    private newsService: NewsService,
    private commentService: CommentService,
    private userService: UserService,
    private notifier:NotifierService
  ) { 
    this.newsService.refreshItem.subscribe(data=>{
      this.model=data
    })
  }
  title: string
  model: NewsModel
  value: boolean = true
  comment: string = ""
  userName: string
  IsFavorite:boolean
    Id:string
changeFavorite(){
  this.IsFavorite=!this.IsFavorite
  this.newsService.setFavorite(this.model,this.Id).subscribe(data=>{
    if (data.status === 200) {
    //  this.newsService.setList(this.model)
      this.notifier.notify('success', "Set favorite!");

    }
    else {
      for (var i = 0; i < data.errors.length; i++) {
        console.log( data.errors[i])
        this.notifier.notify('error', data.errors[i]);
      }
    }
  })
}


  addComment() {
    let model = new CommentModel();
    model.datePost = new Date().toDateString()
    model.text = this.comment
    model.userName = this.userName
    this.commentService.addComment(model, this.title).subscribe(data => {
      if (data.status === 200) {
        this.notifier.notify('success', "You comment is added!");

      }
      else {
        for (var i = 0; i < data.errors.length; i++) {
          console.log( data.errors[i])
          this.notifier.notify('error', data.errors[i]);
        }
      }
    });
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

    let decode = jwt_decode(localStorage.getItem('token'))
    this.Id=decode.id
    this.userService.getcurrentUser(this.Id).subscribe(data => [
      this.userName = data.fullName
    ])

    this.newsService.getFavorite(this.title).subscribe(data=>{
      console.log(data.isFavorite)
      this.IsFavorite=data.isFavorite
    })
  }

}
