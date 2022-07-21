import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Addusertype, Usertype } from '../../classes/usertype/usertype';

@Injectable({
  providedIn: 'root'
})
export class UsertypeService {
  apiUrl: string = "https://localhost:44350/api/usertype";  

  constructor(
      private http: HttpClient
      ){ }  

  getUserType():Observable<any>{  

      return this.http.get<any>(this.apiUrl,{responseType:'json'});  
  }  

  addUserType(addUserType:Addusertype):Observable<any>{ 
      const httpOptions = {  
          headers: new HttpHeaders({  
              'Content-Type': 'application/json'  
          })  
      };  
      return this.http.post<any>(this.apiUrl,addUserType,{responseType:'json'});  
  }  
  
  upDateUserType(userId:number, formData:Usertype):Observable<any>{  
      
    const baseUrl="https://localhost:44350/api/usertype/"+userId;
      const httpOptions = {  
          headers: new HttpHeaders({  
              'Content-Type': 'application/json'  
          })  
      };  
      return this.http.put<any>(baseUrl,formData,{responseType:'json'});  
  }  
  deleteUserType(userId: any):Observable<any>{  
      const baseUrl="https://localhost:44350/api/usertype/"+userId;
      const httpOptions = {  
          headers: new HttpHeaders({  
              'Content-Type': 'application/json'  
          })  
      };  
      return this.http.delete<any> (baseUrl,{responseType:'json'});  
  }  
}
