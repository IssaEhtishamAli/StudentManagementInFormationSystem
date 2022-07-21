import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {updateUserProfile } from '../../classes/userprofile/userprofile';

@Injectable({
  providedIn: 'root'
})
export class UserprofileService {
  apiUrl: string = "https://localhost:44350/api/userprofile";  

  constructor(
    private http:HttpClient
    ) { }
    getUserProfile():Observable<any>{
      return this.http.get<any>(this.apiUrl,{responseType:'json'})
    }
    getUserProfileById(usrpid:any):Observable<any>{
      const baseUrl = "https://localhost:44350/api/userprofile/"+usrpid;  
      const httpOptions = {  
        headers: new HttpHeaders({  
            'Content-Type': 'application/json'  
        })  
    };
    return this.http.get<any>(baseUrl,{responseType:'json'});
    }
    // addUserProfile(addProfile:addUserProfile):Observable<any>{
    //   const httpOptions={
    //     headers:new HttpHeaders({
    //       'Content-Type':'application/json'
    //     })
    //   }
    //   return this.http.post<any>(this.apiUrl,addProfile,{responseType:'json'})
    // }
   public updateUserProfile(editProfile:updateUserProfile):Observable<any>{
      debugger;
      const baseUrl="https://localhost:44350/api/userprofile/UpdateProfile/";
      const httpOptions={
        headers:new HttpHeaders({
          'Content-Type':'application/json'
        })
      }
      return this.http.put<any>(baseUrl,editProfile,{responseType:'json'})
    }
   
    // public uploadimg(imgfile:any):Observable<any>{
    //   debugger;
    //   const baseUrl="https://localhost:44350/api/userprofile/uploadimg/";
    //   const httpOptions={
    //     headers:new HttpHeaders({
    //       'Content-Type':'application/json'
    //     })
    //   }
    //   return this.http.put<any>(baseUrl,imgfile)
    // }
    deleteUserProfile(id:number):Observable<any>{
      const baseUrl="https://localhost:44350/api/userprofile/"+id;
      const httpOptions={
        headers:new HttpHeaders({
          'Content-Type':'application/json'
        })
      }
      return this.http.delete<any>(baseUrl,{responseType:'json'})
    }
}
