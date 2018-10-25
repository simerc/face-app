import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from '../guards/auth-gard.service';

import { ModuleWithProviders } from '@angular/core';

import { ImageListComponent } from '../image-list/image-list.component';
import { ImageDetailsComponent } from '../image-details/image-details.component';
import { RegisterComponent } from '../register/register.component';
import { LoginComponent } from '../components/login/login.component';

const appRoutes: Routes = [
  {
    path: "images",
    component: ImageListComponent
    //canActivate: [AuthGuard]
  },
  {
    path: "images/:id",
    component: ImageDetailsComponent
    //canActivate: [AuthGuard]
  },
  {
    path: "register",
    component: RegisterComponent
  },
  {
    path: "login",
    component: LoginComponent
  }
];

export const routingModule: ModuleWithProviders = RouterModule.forRoot(appRoutes);

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
