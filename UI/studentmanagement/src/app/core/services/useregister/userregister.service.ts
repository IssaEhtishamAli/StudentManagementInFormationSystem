import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
// import { addUserProfile, Userprofile } from '../../classes/userprofile/userprofile';

@Injectable({
  providedIn: 'root'
})
export class UserregisterService {
  apiUrl: string = "https://localhost:44350/api/userprofile";  

  constructor(private http:HttpClient) { }

  getUserProfile():Observable<any>{
    return this.http.get<any>(this.apiUrl,{responseType:'json'})
  }
  getUserProfileById(userid:any):Observable<any>{
    const baseUrl="https://localhost:44350/api/userprofile/"+userid;
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json'
      })
    }
    return this.http.get<any>(baseUrl,{responseType:'json'})
  }
  // addUserProfile(addProfile:addUserProfile):Observable<any>{
  //   const httpOptions={
  //     headers:new HttpHeaders({
  //       'Content-Type':'application/json'
  //     })
  //   }
  //   return this.http.post<any>(this.apiUrl,{responseType:'json'})
  // }
  // updateUserProfile(userProfileId:number,formdata:Userprofile):Observable<any>{
  //   const baseUrl="https://localhost:44350/api/userprofile/"+userProfileId;
  //   const httpOptions={
  //     headers:new HttpHeaders({
  //       'Content-Type':'application/json'
  //     })
  //   }
  //   return this.http.put<any>(baseUrl,formdata,{responseType:'json'})
  // }
  // deleteUserProfile(userProfileId:number):Observable<any>{
  //   const baseUrl="https://localhost:44350/api/userprofile/"+userProfileId;
  //   const httpOptions={
  //     headers:new HttpHeaders({
  //       'COntent-Type':'application/json'
  //     })
  //   }
  //   return this.http.delete<any>(baseUrl,{responseType:'json'})
  // }
}
