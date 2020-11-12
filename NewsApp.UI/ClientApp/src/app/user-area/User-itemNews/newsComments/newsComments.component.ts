import { Component, Input, OnInit } from '@angular/core';
import { CommentModel } from 'src/app/Models/comment.model';
import { CommentService } from 'src/app/Services/comment.service';

@Component({
  selector: 'app-newsComments',
  templateUrl: './newsComments.component.html',
  styleUrls: ['./newsComments.component.css']
})
export class NewsCommentsComponent implements OnInit {
@Input() title:string
  constructor(private commentService:CommentService) { }
  comentModel:CommentModel[]=[]
  ngOnInit() {
this.commentService.getnewsComments(this.title).subscribe(data=>{
  this.comentModel=data
})
  }

}
