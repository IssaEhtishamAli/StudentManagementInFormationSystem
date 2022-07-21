import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddDegree, Degrees } from '../../classes/degrees/degrees';

@Injectable({
  providedIn: 'root'
})
export class DegreesService {
apiUrl:string="https://localhost:44350/api/degrees";

  constructor(private http:HttpClient) { }

  getDegrees():Observable<any>{
    return this.http.get<any>(this.apiUrl,{responseType:'json'})
  }

  addDegree(addDegree:AddDegree):Observable<any>{
    const httpOptions = {  
      headers: new HttpHeaders({  
          'Content-Type': 'application/json'  
      })  
  };  
  return this.http.post<any>(this.apiUrl,addDegree,{responseType:'json'})
  }

  updateDegree(degreeId:number,formData:Degrees):Observable<any>{
    const baseUrl="https://localhost:44350/api/degrees/"+degreeId;
    const httpOptions = {  
      headers: new HttpHeaders({  
          'Content-Type': 'application/json'  
      })  
  };  
  return this.http.put<any>(baseUrl,formData,{responseType:'json'})
  }

  deleteDegree(degreeId:number):Observable<any>{
    const baseUrl="https://localhost:44350/api/degrees/"+degreeId;
    const httpOptions = {  
      headers: new HttpHeaders({  
          'Content-Type': 'application/json'  
      })  
  };  
  return this.http.delete<any>(baseUrl,{responseType:'json'});  
  }
}
