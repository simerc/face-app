import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { ImageListComponent } from './image-list/image-list.component';

import { RegisterComponent } from './register/register.component';

import { HttpClientModule } from '@angular/common/http';
import { ImageDetailsComponent } from './image-details/image-details.component';

import { AppRoutingModule } from './app-routing/app-routing.module';
import { UiModule } from './ui/ui.module';


@NgModule({
  declarations: [
    AppComponent,
    ImageListComponent,
    ImageDetailsComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    UiModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
