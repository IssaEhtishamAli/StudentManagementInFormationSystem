import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AddCourses, Courses } from '../../classes/courses/courses';

@Injectable({
  providedIn: 'root'
})
export class CoursesService {
  apiUrl: string = "https://localhost:44350/api/courses";

  constructor(
   private http: HttpClient
   ){ }  

  getCourse():Observable<any>{  

      return this.http.get<any>(this.apiUrl,{responseType:'json'});  
  }  

  addCourse(addCourse:Courses):Observable<any>{  
      const httpOptions = {  
          headers: new HttpHeaders({  
              'Content-Type': 'application/json'  
          })  
      };  
      return this.http.post<any>(this.apiUrl,addCourse,{responseType:'json'});  
  }  
  

  upDateCourse(courseId:number,formData:Courses):Observable<any>{  
    const baseUrl="https://localhost:44350/api/courses/"+courseId;
    //   const httpOptions = {  
    //       headers: new HttpHeaders({  
    //           'Content-Type': 'application/json'  
    //       })  
    //   };  
      return this.http.put<any>(baseUrl,formData,{responseType: 'json'});  
  }
  deleteCourse(courseId: any):Observable<any>{  
      const baseUrl="https://localhost:44350/api/courses/"+courseId;
      const httpOptions = {  
          headers: new HttpHeaders({  
              'Content-Type': 'application/json'  
          })  
      };  
      return this.http.delete<any> (baseUrl,{responseType:'json'});  
  }  
}  