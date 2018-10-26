import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Component } from '@angular/core';
import { Router } from "@angular/router";
import { NgForm } from '@angular/forms';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  invalidLogin: boolean;

  constructor(private router: Router, private http: HttpClient, private svc: AccountService) { }

  login(form: NgForm) {
    let credentials = JSON.stringify(form.value);

    this.svc.login(credentials)
    .subscribe(response => 
      {
        let token = (<any>response).auth_token;
        localStorage.setItem("jwt", token);

        console.log("logged in, redirecting");
        this.invalidLogin = false;
        this.router.navigate(["/images"]);
      }, 
      err => 
        {
          this.invalidLogin = true;
        });
  }

}