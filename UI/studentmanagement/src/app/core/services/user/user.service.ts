import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddUsers, UpdatePassword, UserLogin, Users } from '../../classes/user/user';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  apiUrl: string = "https://localhost:44350/api/user";  

  constructor(
      private http: HttpClient
      ){ }  

    getUser():Observable<any>{  

        return this.http.get<any>(this.apiUrl,{responseType:'json'});  
    }  
    getUserById(id:any):Observable<any>{
        const baseUrl="https://localhost:44350/api/user"+id;
    return this.http.get<any>(baseUrl,{responseType:'json'})
    }
    userLoginValidate(login:UserLogin):Observable<any>{
        const baseUrl="https://localhost:44350/api/user/Login/";
        const httpOptions = {  
            headers: new HttpHeaders({  
                'Content-Type': 'application/json'  
            })  
        };  
        return this.http.post<any>(baseUrl,login,{responseType:'json'}) 
    }
    addUser(addUser:AddUsers):Observable<any>{ 
        const httpOptions = {  
            headers: new HttpHeaders({  
                'Content-Type': 'application/json'  
            })  
        };  
        return this.http.post<any>(this.apiUrl,addUser,{responseType:'json'});  
    }  
    updateUserPassword(userpasswordupdate:UpdatePassword):Observable<any>{
        const baseUrl="https://localhost:44350/api/user/password";
        const httpOptions = {  
            headers: new HttpHeaders({  
                'Content-Type': 'application/json'  
            })  
        };  
        return this.http.put<any>(baseUrl,userpasswordupdate,{responseType:'json'})
  }
    upDateUser(userId:number, formData:Users):Observable<any>{  
        const baseUrl="https://localhost:44350/api/user/"+userId;
        const httpOptions = {  
            headers: new HttpHeaders({  
                'Content-Type': 'application/json'  
            })  
        };  
        return this.http.put<any>(baseUrl,formData,{responseType:'json'});  
    }  
    deleteUser(userId: any):Observable<any>{  
        debugger;
        const baseUrl="https://localhost:44350/api/user/"+userId;
        const httpOptions = {  
            headers: new HttpHeaders({  
                'Content-Type': 'application/json'  
            })  
        };  
        return this.http.delete<any> (baseUrl,{responseType:'json'});  
    }  
}
