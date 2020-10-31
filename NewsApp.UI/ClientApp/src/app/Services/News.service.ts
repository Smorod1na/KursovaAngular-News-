import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Models/api.responce';
import { NewsModel } from '../Models/News.model';

@Injectable({
  providedIn: 'root'
})
export class NewsService {

  constructor(private http: HttpClient) { }
  baseUrl = "/api/News"


  getAllNews(): Observable<NewsModel[]> {
    return this.http.get<NewsModel[]>(this.baseUrl);
  }
  addNews(model: NewsModel): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(this.baseUrl + "/addnews", model)
  }

}
