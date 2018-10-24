import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class AccountService {

  private apiUrl: string = environment.apiUrl;
  private url: string = this.apiUrl + "/api/account";

  constructor() { }
}
