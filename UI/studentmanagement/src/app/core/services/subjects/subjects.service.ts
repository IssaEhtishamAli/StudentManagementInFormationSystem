import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Addsubjects, Subjects } from '../../classes/subjects/subjects';

@Injectable({
  providedIn: 'root'
})
export class SubjectsService {
  apiUrl: string = "https://localhost:44350/api/Subjects";

  constructor(

   private http: HttpClient

   ){ }  

  getSubject():Observable<any>{  

      return this.http.get<any>(this.apiUrl,{responseType:'json'});  
  }  

  addSubject(addSubject:Addsubjects):Observable<any>{  
      const httpOptions = {  
          headers: new HttpHeaders({  
              'Content-Type': 'application/json'  
          })  
      };  
      return this.http.post<any>(this.apiUrl,addSubject,{responseType:'json'});  
  }  
  
  upDateSubject(subjectId:number, formData:Subjects):Observable<any>{  
    const baseUrl="https://localhost:44350/api/Subjects/"+subjectId;
      const httpOptions = {  
          headers: new HttpHeaders({  
              'Content-Type': 'application/json'  
          })  
      };  
      return this.http.put<any>(baseUrl,formData,{responseType:'json'});  
  }  
  deleteSubject(subjectId: any):Observable<any>{  
      const baseUrl="https://localhost:44350/api/Subjects/"+subjectId;
      const httpOptions = {  
          headers: new HttpHeaders({  
              'Content-Type': 'application/json'  
          })  
      };  
      return this.http.delete<any>(baseUrl,{responseType:'json'});  
  }  
}  