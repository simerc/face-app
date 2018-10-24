import { NgModule } from '@angular/core';
import { RouterModule, Routes} from '@angular/router';
import { HomeComponent } from '../home/home.component';
import { RegistrationFormComponent } from '../registration-form/registration-form.component';

const appRoutes: Routes = [
  {
    path: "home",
    component:  HomeComponent
  },
  {
    path: "register",
    component: RegistrationFormComponent
  }
]

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})

export class AppRoutingModule { }
