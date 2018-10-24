import { Injectable, Component } from '@angular/core';
import { IServerInfo } from './server-info';

import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

import { catchError, tap, map } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

import { environment } from './../../environments/environment';

const HttpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

@Injectable({
    providedIn: 'root'
})

export class ServerInfoService {

    constructor(private httpClient: HttpClient) {

    }
    
    getServerInfo() : Observable<IServerInfo>  {

        var url = environment.apiEndpoint;

        console.log('ServerInfo service called');
        var item = this.httpClient.get<IServerInfo>('http://faceapp.api.local/api/serverinfo')
                        .pipe(
                            tap(data => console.log('JSON: ' + JSON.stringify(data))),
                            catchError(this.handleError)
                        );

        console.log(item);

        return item;
    }

    private handleError(err: HttpErrorResponse) {
        let errorMessage = '';

        if(err.error instanceof ErrorEvent) {
            errorMessage = `An error occurred: ${err.error.message}`;
        } else {
            errorMessage = `server returned code ${err.status}, message is ${err.message}`
        }

        console.error(errorMessage);

        return throwError(errorMessage);
    }
}