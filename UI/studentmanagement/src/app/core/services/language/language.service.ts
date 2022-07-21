import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LanguageService {
  apiUrl="https://localhost:44350/api/language"

  constructor(private http:HttpClient) { }
  getAllLanguages():Observable<any>{
  return this.http.get(this.apiUrl,{responseType:'json'})
  }
}
