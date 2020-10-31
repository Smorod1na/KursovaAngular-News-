import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Models/api.responce';
import { UserModel } from '../Models/User.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(
    private http: HttpClient
  ) { }
  baseUrl = "/api/User"

  getAllManager(): Observable<UserModel[]> {
    return this.http.get<UserModel[]>(this.baseUrl)
  }

  getcurrentUser(id: string): Observable<UserModel> {

    return this.http.get<UserModel>(this.baseUrl + "/" + id);
  }

  editUser(model: UserModel, id: string): Observable<ApiResponse> {
    // const body = { model: model};
    return this.http.post<ApiResponse>(this.baseUrl + "/edituser/"+id, model)
  }
}
