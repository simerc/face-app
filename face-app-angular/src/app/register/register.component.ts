import { Component, OnInit } from '@angular/core';
import { Registration } from '../models/registration.model';
import { NgForm } from '@angular/forms';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  private registerModel: Registration;

  userExists: boolean = false;
  successfulRegistration: boolean = false;

  emailPattern: string = "^[a-z0-9._%+-]+@[a-z0-9._]+\.[a-z]{2,4}$";

  constructor(private svc: AccountService) { 
    this.registerModel = {
      FirstName: "",
      LastName: "",
      Email: ""
    }
  }

  ngOnInit() {

  }

  onSubmit(form: NgForm)  {
    if(form.valid) {
      this.svc.registerUser(this.registerModel).subscribe(
        data => { this.postSuccess(data)},
        err => { this.postFailure(err)}
      );
    }
  }

  postFailure(data) {
    if(data.status == 400) {
      this.userExists = true; 
    }
  }

  postSuccess(data) {
    this.successfulRegistration = true;
  }

}
