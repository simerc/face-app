import { BrowserModule } from '@angular/platform-browser';
import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';

import { HttpClientModule } from '@angular/common/http';
import { ServerInfoService } from './shared/server-info.service';
import { RegistrationFormComponent } from './registration-form/registration-form.component';
import { AppRoutingModule } from './app-routing/app-routing.module';


const appRoutes: Routes = [
  { path: '', component: HomeComponent}
];


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    RegistrationFormComponent
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(appRoutes),
    HttpClientModule,
    AppRoutingModule
  ],
  bootstrap: [
    AppComponent
  ],
  providers: [
    ServerInfoService
  ],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule { }
