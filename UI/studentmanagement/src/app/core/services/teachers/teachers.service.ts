import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Addteacher, Teachers } from '../../classes/teachers/teachers';

@Injectable({
  providedIn: 'root'
})
export class TeachersService {
  apiUrl: string = "https://localhost:44350/api/teachers";  

  constructor(
      private http: HttpClient
      ){ }  

  getTeachers():Observable<any>{  

      return this.http.get<any>(this.apiUrl,{responseType:'json'});  
  }  
 getTeacherByID(teacherId:number):Observable<any>{
    const baseUrl="https://localhost:44350/api/teachers/"+teacherId;
    const httpOptions = {  
        headers: new HttpHeaders({  
            'Content-Type': 'application/json'  
        })  
    };  
     return this.http.get<any>(baseUrl,{responseType:'json'})
   }
  addTeacher(addTeacher:Addteacher):Observable<any>{  
      const httpOptions = {  
          headers: new HttpHeaders({  
              'Content-Type': 'application/json'  
          })  
      };  
      return this.http.post<any>(this.apiUrl,addTeacher,{responseType:'json'});  
  }  
  upDateTeacher(teacherId:number, formData:Teachers):Observable<any>{  
    const baseUrl="https://localhost:44350/api/Teachers/"+teacherId;
      const httpOptions = {  
          headers: new HttpHeaders({  
              'Content-Type': 'application/json'  
          })  
      };  
      return this.http.put<any>(baseUrl,formData,{responseType:'json'});  
  }  
  deleteTeacher(teacherId: any):Observable<any>{  
      const baseUrl="https://localhost:44350/api/Teachers/"+teacherId;
      const httpOptions = {  
          headers: new HttpHeaders({  
              'Content-Type': 'application/json'  
          })  
      };  
      return this.http.delete<any>(baseUrl,{responseType:'json'});  
  }  
}  