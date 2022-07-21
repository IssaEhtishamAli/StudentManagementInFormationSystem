import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { AddFile, updateFile } from '../../classes/file/file';

@Injectable({
  providedIn: 'root'
})
export class FileService {
  apiUrl:string="https://localhost:44350/api/imagefile/";
  constructor(private http:HttpClient) { }
  getFile():Observable<any>{
    return this.http.get<any>(this.apiUrl,{responseType:'json'})
  }
  getFileById(user_id:number):Observable<any>{
    const baseUrl:string="https://localhost:44350/api/imagefile/"+user_id;
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json'
      })
    }
    return this.http.get<any>(baseUrl,{responseType:'json'})
  }
  addFile(imageFile:any):Observable<any>{
    debugger;
    const baseUrl:string="https://localhost:44350/api/imagefile/fileupload/";
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json'
      })
    }
   return this.http.post<any>(baseUrl,imageFile)
  }
  updateFile(editFile:updateFile):Observable<any>{
    debugger;
    const baseUrl:string="https://localhost:44350/api/imagefile/imagepathupdate/";
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json'
      })
    }
    return this.http.put<any>(baseUrl,editFile,{responseType:'json'})
  }
  addFiles(editFile:AddFile):Observable<any>{
    const baseUrl:string="https://localhost:44350/api/imagefile/storeimagepath/";
    const httpOptions={
      headers:new HttpHeaders({
        'Content-Type':'application/json'
      })
    }
    return this.http.post<any>(baseUrl,editFile,{responseType:'json'})
  }
}
