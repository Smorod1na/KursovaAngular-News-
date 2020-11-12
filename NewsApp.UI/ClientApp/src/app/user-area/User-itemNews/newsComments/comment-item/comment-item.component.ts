import { Component, Input, OnInit } from '@angular/core';
import { CommentModel } from 'src/app/Models/comment.model';
import { CommentService } from 'src/app/Services/comment.service';
import jwt_decode from "jwt-decode";
import { UserService } from 'src/app/Services/User.service';
import { UserModel } from 'src/app/Models/User.model';

@Component({
  selector: 'app-comment-item',
  templateUrl: './comment-item.component.html',
  styleUrls: ['./comment-item.component.css']
})
export class CommentItemComponent implements OnInit {
  @Input() currenComment: CommentModel
  constructor(
    private commentService: CommentService,
    private userService: UserService
  ) { }
  Id: string
  userModel: UserModel
  ngOnInit() {
    let decode = jwt_decode(localStorage.getItem('token'))
    this.Id = decode.id
    this.userService.getcurrentUser(this.Id).subscribe(data => {
      this.userModel = data

    })
  }
  delete() {
    this.commentService.deleteComment(this.currenComment).subscribe(data => {
      console.log(data)
    })
  }
}
