import { JwtHelperService } from '@auth0/angular-jwt'
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

const helper = new JwtHelperService();

@Injectable()
export class AuthGuard implements CanActivate {
  constructor(private router: Router) {
  }

  canActivate() {
    var token = localStorage.getItem("jwt");

    console.log("AuthGuard - token " + token);

    console.log("expired " + helper.isTokenExpired(token));

    if (token && !helper.isTokenExpired(token)){
      console.log(helper.decodeToken(token));
      return true;
    }
    this.router.navigate(["login"]);
    return false;
  }
}