import { Component, OnInit } from '@angular/core';
import { Registration } from '../models/registration.model';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  private registerModel: Registration;

  emailPattern: string = "^[a-z0-9._%+-]+@[a-z0-9._]+\.[a-z]{2,4}$";

  constructor() { }

  ngOnInit() {
    this.resetForm()
  }

  resetForm(form?: NgForm) {

    if(form != null)  {
      form.reset();

      this.registerModel = {
        FirstName: "",
        LastName: "",
        Email: ""
      }
    }

  }
}
