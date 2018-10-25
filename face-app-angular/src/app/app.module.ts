import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ImageListComponent } from './image-list/image-list.component';

import { RegisterComponent } from './register/register.component';

import { HttpClientModule } from '@angular/common/http';
import { ImageDetailsComponent } from './image-details/image-details.component';

import { AppRoutingModule } from './app-routing/app-routing.module';
import { UiModule } from './ui/ui.module';
import { LoginComponent } from './components/login/login.component';

import { AuthGuard } from './guards/auth-gard.service';


@NgModule({
  declarations: [
    AppComponent,
    ImageListComponent,
    ImageDetailsComponent,
    RegisterComponent,
    LoginComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    UiModule,
    FormsModule
  ],
  providers: [AuthGuard],
  bootstrap: [AppComponent]
})
export class AppModule { }
