import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { ModuleWithProviders } from '@angular/core';

import { ImageListComponent } from '../image-list/image-list.component';
import { ImageDetailsComponent } from '../image-details/image-details.component';
import { RegisterComponent } from '../register/register.component';

const appRoutes: Routes = [
  {
    path: "images",
    component: ImageListComponent
  },
  {
    path: "",
    redirectTo: "/images",
    pathMatch: "full"
  },
  {
    path: "images/:id",
    component: ImageDetailsComponent
  },
  {
    path: "register",
    component: RegisterComponent
  }
];

export const routingModule: ModuleWithProviders = RouterModule.forRoot(appRoutes);

@NgModule({
  imports: [RouterModule.forRoot(appRoutes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
