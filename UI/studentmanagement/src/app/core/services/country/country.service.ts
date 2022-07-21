import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CountryService {
apiUrl="https://localhost:44350/api/country"
  constructor(private http:HttpClient) { }
  getCountry():Observable<any>{
    return this.http.get<any>(this.apiUrl,{responseType:'json'})
  }
}
