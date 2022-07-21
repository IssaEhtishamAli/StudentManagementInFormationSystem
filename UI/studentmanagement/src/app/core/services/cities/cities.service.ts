import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddCity, Cities } from '../../classes/cities/cities';

@Injectable({
  providedIn: 'root'
})
export class CitiesService {
  apiUrl: string = "https://localhost:44350/api/cities";
  constructor(private http:HttpClient) { }


  getCities():Observable<any>{
   return this.http.get<any>(this.apiUrl,{responseType:'json'})
  }

  addCity(addCity:AddCity):Observable<any>{
    const httpOptions = {  
      headers: new HttpHeaders({  
          'Content-Type': 'application/json'  
      })  
  };  
  return this.http.post<any>(this.apiUrl,addCity,{responseType:'json'});  
  }

  updateCity(cityId:number,formData:Cities):Observable<any>{
    const baseUrl="https://localhost:44350/api/cities/"+cityId;
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json'
      })
    };
    return this.http.put<any>(baseUrl,formData,{responseType:'json'})
  }

  deleteCity(cityId:any):Observable<any>{  
    const baseUrl="https://localhost:44350/api/cities/"+cityId;
    const httpOptions = {  
        headers: new HttpHeaders({  
            'Content-Type': 'application/json'  
        })  
    };  
    return this.http.delete<any> (baseUrl,{responseType:'json'});  
}  
  }
