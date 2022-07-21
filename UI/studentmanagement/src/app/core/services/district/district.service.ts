import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DistrictService {
  apiUrl: string = "https://localhost:44350/api/districts";

  constructor(private http:HttpClient) { }
  getAllDistricts():Observable<any>{
    return this.http.get<any>(this.apiUrl,{responseType:'json'})
  }
}
