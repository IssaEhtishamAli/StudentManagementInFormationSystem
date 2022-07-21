import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Updateguardiandetials } from '../../classes/guardian/guardian';

@Injectable({
  providedIn: 'root'
})
export class GuardianService {
  apiUrl="https://localhost:44350/api/guardians"

  constructor(private http:HttpClient) { }
  getGuardiansDetails():Observable<any>{
    return this.http.get<any>(this.apiUrl,{responseType:'json'})
  }
  getGuardiansDetailsById(usrpid:number):Observable<any>{
    const baseUrl = "https://localhost:44350/api/guardians/"+usrpid;  
    const httpOptions = {  
      headers: new HttpHeaders({  
          'Content-Type': 'application/json'  
      })  
  };
  return this.http.get<any>(baseUrl,{responseType:'json'});
  }
  public updateGuardian(editGuardian:Updateguardiandetials):Observable<any>{
    debugger;
    const baseUrl="https://localhost:44350/api/guardians/updateguardian/";
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json'
      })
    }
    return this.http.put<any>(baseUrl,editGuardian,{responseType:'json'})
  }
}
