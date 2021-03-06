import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Observable, observable } from 'rxjs';

import { environment } from '../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ImageService {

 //TODO - Global variables for api endpoints

  private apiUrl: string = environment.apiUrl;
  private url : string = this.apiUrl + "/api/images";

  private uploadUrl: string = this.apiUrl + "/api/images/uploadimage";

  constructor(private http: HttpClient) { 
    
  }

  getImages(): Observable<any> {

    //=====GET JWT TOKEN======//
    let token = localStorage.getItem("jwt");

    let httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'Bearer ' + token
      })
    };

    return this.http.get<any>(this.url, httpOptions);
  }

  getImageById(id: string): Observable<any> {

    const url = `${this.url}/${id}`

    return this.http.get<any>(url);
  }

  uploadImage(formData: FormData): Observable<any> {
    //=====GET JWT TOKEN======//
    let token = localStorage.getItem("jwt");

    let httpRequest = new HttpRequest('POST', this.uploadUrl, formData, {
      reportProgress: true,
      headers: new HttpHeaders({
        'Authorization': 'Bearer ' + token
      })
    });

    return this.http.request<any>(httpRequest);
  }
}
