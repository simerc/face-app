import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, observable } from 'rxjs';

import { environment } from '../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ImageService {

  private apiUrl: string = environment.apiUrl;
  private url : string = this.apiUrl + "/api/images";

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
}
