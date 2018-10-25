import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { Registration } from '../models/registration.model';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map, filter, scan, catchError } from 'rxjs/operators';


const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})

export class AccountService {


  private apiUrl: string = environment.apiUrl;
  private registerUrl: string = this.apiUrl + "/api/account/register";
  private loginUrl: string = this.apiUrl + "/api/auth/login";

  constructor(private http: HttpClient) { }

  registerUser(user) : Observable<any> {

    const body: Registration = {
      FirstName: user.FirstName,
      LastName: user.LastName,
      Email: user.Email
    }

    return this.http.post(this.registerUrl, body, httpOptions);
  }

  login(credentials) : Observable<any> {

    return this.http.post(this.loginUrl, credentials, httpOptions);

  }
}
