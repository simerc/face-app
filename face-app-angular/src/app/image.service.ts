import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, observable } from 'rxjs';

import { environment } from '../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class ImageService {

  private apiUrl: string = environment.apiUrl;
  private url : string = this.apiUrl + "/images";

  constructor(private http: HttpClient) { 
    
  }

  getImages(): Observable<any> {
    return this.http.get<any>(this.url);
  }

  getImageById(id: string): Observable<any> {
    const url = `${this.url}/${id}`

    return this.http.get<any>(url);
  }
}
