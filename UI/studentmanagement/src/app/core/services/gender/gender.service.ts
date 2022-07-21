import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class GenderService {
apiUrl="https://localhost:44350/api/genders"
  constructor(private http:HttpClient) { }

  getGender():Observable<any>{
    return this.http.get<any>(this.apiUrl,{responseType:'json'})
  }
}
