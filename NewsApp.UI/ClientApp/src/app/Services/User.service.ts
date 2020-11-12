import { HttpClient } from '@angular/common/http';
import { EventEmitter, Injectable } from '@angular/core';
import { User } from 'oidc-client';
import { Observable } from 'rxjs';
import { ApiResponse } from '../Models/api.responce';
import { UserModel } from '../Models/User.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
 
  refreshUser:EventEmitter<UserModel>=new EventEmitter()
  constructor(
    private http: HttpClient
  ) {

   }
  baseUrl = "/api/User"

   setUserInfo(model:UserModel){
     this.refreshUser.emit(model)
   }

  getAllManager(): Observable<UserModel[]> {
    return this.http.get<UserModel[]>(this.baseUrl)
  }

  getcurrentUser(id: string): Observable<UserModel> {

    return this.http.get<UserModel>(this.baseUrl + "/" + id);
  }

  getAllUser():Observable<UserModel[]>{
    return this.http.get<UserModel[]>(this.baseUrl+"/getall")
  }


  editUser(model: UserModel, id: string): Observable<ApiResponse> {
    // const body = { model: model};
    return this.http.post<ApiResponse>(this.baseUrl + "/edituser/"+id, model)
  }

  changeUserRole(model: UserModel,role:string): Observable<ApiResponse>{
    return this.http.post<ApiResponse>(this.baseUrl + "/changeRole/"+role,model)
  }

  deleteUser(model:UserModel):Observable<ApiResponse>{
    return this.http.post<ApiResponse>(this.baseUrl + "/deleteuser",model)

  }
}
