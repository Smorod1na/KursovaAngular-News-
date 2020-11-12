import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Models/api.responce';
import { IsFavoriteModel } from '../Models/IsFavorite.model';
import { NewsModel } from '../Models/News.model';
import { PaginationModel } from '../Models/PaginationList.model';

@Injectable({
  providedIn: 'root'
})
export class NewsService {

  constructor(
    private http: HttpClient
  ) { }
  baseUrl = "/api/News"
  refreshString: EventEmitter<string> = new EventEmitter()
  refreshItem: EventEmitter<NewsModel> = new EventEmitter()
  refreshList: EventEmitter<NewsModel[]> = new EventEmitter()
  setList(model: NewsModel[]) {
    this.refreshList.emit(model)
  }
  setNews(filter: string) {
    this.refreshString.emit(filter)
  }
  setItemNews(model: NewsModel) {
    this.refreshItem.emit(model)
  }
  getPagNews(value: number, filter: string): Observable<PaginationModel> {
    return this.http.get<PaginationModel>(this.baseUrl + "/" + value + "/" + filter)
  }

  getFavoritenews(email: string): Observable<NewsModel[]> {
    return this.http.get<NewsModel[]>(this.baseUrl + "/getlistfavorite/" + email)
  }

  getAllNews(): Observable<NewsModel[]> {
    return this.http.get<NewsModel[]>(this.baseUrl)
  }

  addNews(model: NewsModel): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(this.baseUrl + "/addnews", model)
  }
  getManagerNews(id: string): Observable<NewsModel[]> {
    return this.http.get<NewsModel[]>(this.baseUrl + "/" + id)
  }
  deleteNews(model: NewsModel): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(this.baseUrl + "/deleteNews", model)
  }
  setFavorite(model: NewsModel, id: string): Observable<ApiResponse> {
    return this.http.post<ApiResponse>(this.baseUrl + "/setFavorite/" + id, model)
  }
  getFavorite(model: string): Observable<IsFavoriteModel> {
    return this.http.get<IsFavoriteModel>(this.baseUrl + "/getfavorite/" + model)
  }
}
