import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Students,Addstudent } from '../../classes/students/students';

@Injectable({
  providedIn: 'root'
})
export class StudentsService {
  apiUrl: string = "https://localhost:44350/api/Students";

  constructor(

   private http: HttpClient

   ){ }  

  getStudents():Observable<any>{  

      return this.http.get<any>(this.apiUrl,{responseType:'json'});  
  }  
  getStudentById(studentId:any):Observable<any>{
    const baseUrl="https://localhost:44350/api/Students/"+studentId;
    const httpOptions = {  
        headers: new HttpHeaders({  
            'Content-Type': 'application/json'  
        })  
    };  
    return this.http.get<any>(baseUrl,{responseType:'json'});
  }
  addStudent(addstudent:Addstudent):Observable<any>{  
    debugger;
    const baseUrl="https://localhost:44350/api/Students/addstudents/";

      const httpOptions = {  
          headers: new HttpHeaders({  
              'Content-Type': 'application/json'  
          })  
      };  
      return this.http.post<any>(baseUrl,addstudent,{responseType:'json'});  
  }  
  
  upDateStudent(formData:Students):Observable<any>{  
    debugger;
    const baseUrl="https://localhost:44350/api/Students/updatestd/";
      const httpOptions = {  
          headers: new HttpHeaders({  
              'Content-Type': 'application/json'  
          })  
      };  
      return this.http.put<any>(baseUrl,formData,{responseType:'json'});  
  }  
  deleteStudent(studentId: any):Observable<any>{  
      const baseUrl="https://localhost:44350/api/Students/"+studentId;
      const httpOptions = {  
          headers: new HttpHeaders({  
              'Content-Type': 'application/json'  
          })  
      };  
      return this.http.delete<any> (baseUrl,{responseType:'json'});  
  }  
 
}  