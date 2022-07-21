import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { AddSections, Sections } from '../../classes/sections/sections';

@Injectable({
  providedIn: 'root'
})
export class SectionsService {
  apiUrl:string="https://localhost:44350/api/sections";

  constructor(private http:HttpClient) { }

  getSections():Observable<any>{
    return this.http.get<any>(this.apiUrl,{responseType:'json'})
  }

  addSection(addSection:AddSections):Observable<any>{
    const httpOptions = {  
      headers: new HttpHeaders({  
          'Content-Type': 'application/json'  
      })  
  };  
  return this.http.post<any>(this.apiUrl,addSection,{responseType:'json'})
  }

  updateSection(degreeId:number,formData:Sections):Observable<any>{
    const baseUrl="https://localhost:44350/api/degrees/"+degreeId;
    const httpOptions = {  
      headers: new HttpHeaders({  
          'Content-Type': 'application/json'  
      })  
  };  
  return this.http.put<any>(baseUrl,formData,{responseType:'json'})
  }

  deleteSection(degreeId:number):Observable<any>{
    const baseUrl="https://localhost:44350/api/degrees/"+degreeId;
    const httpOptions = {  
      headers: new HttpHeaders({  
          'Content-Type': 'application/json'  
      })  
  };  
  return this.http.delete<any>(baseUrl,{responseType:'json'});  
  }
}
