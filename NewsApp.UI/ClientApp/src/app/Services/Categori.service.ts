import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Categorie } from '../Models/Categori.model';

@Injectable({
  providedIn: 'root'
})
export class CategoriService {
  categories: Categorie[]
  constructor(
    private http: HttpClient
  ) { }
  baseUrl = "/api/Categorie"

  getAllCategorie(): Observable<Categorie[]> {
    return this.http.get<Categorie[]>(this.baseUrl);
  }
  
}
