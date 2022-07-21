import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Updatequalificationdetails } from '../../classes/qualification/qualification';

@Injectable({
  providedIn: 'root'
})
export class QualificationService {
  apiUrl="https://localhost:44350/api/qualifications/"

  constructor(private http:HttpClient) { }
  getAllQualification():Observable<any>{
    return this.http.get<any>(this.apiUrl,{responseType:'json'})
  }
  getQualificationsDetailsById(usrpid:number):Observable<any>{
    const baseUrl = "https://localhost:44350/api/qualifications/"+usrpid;  
    const httpOptions = {  
      headers: new HttpHeaders({  
          'Content-Type': 'application/json'  
      })  
  };
  return this.http.get<any>(baseUrl,{responseType:'json'});
  }
  public updateQualification(editQualification:Updatequalificationdetails):Observable<any>{
    debugger;
    const baseUrl="https://localhost:44350/api//qualifications/updatequalifications/";
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json'
      })
    }
    return this.http.put<any>(baseUrl,editQualification,{responseType:'json'})
  }
 
}
