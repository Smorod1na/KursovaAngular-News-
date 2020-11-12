import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Models/api.responce';
import { CommentModel } from '../Models/comment.model';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  constructor(
    private http: HttpClient
  ) { }
  commentModel: CommentModel[] = []
  baseUrl = "/api/Comment"

  getnewsComments(title: string): Observable<CommentModel[]> {
    return this.http.get<CommentModel[]>(this.baseUrl + "/" + title)
  }
  addComment(model:CommentModel,title:string):Observable<ApiResponse>{
    return this.http.post<ApiResponse>(this.baseUrl+"/addcomment/"+title,model)
  }
  deleteComment(model:CommentModel):Observable<ApiResponse>{
    return this.http.post<ApiResponse>(this.baseUrl+"/deletecomment",model)
  }
}
