import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProfileComponent } from './profile/profile.component';
import { RegisterComponent } from './register/register.component';
import { AircompanyComponent } from './aircompany/aircompany.component';
import { RentacarserviceComponent } from './rentacarservice/rentacarservice.component';
import { AircompanylistComponent } from './aircompanylist/aircompanylist.component';
import { RentacarlistComponent } from './rentacarlist/rentacarlist.component';


@NgModule({
  declarations: [
    AppComponent,
    ProfileComponent,
    RegisterComponent,
    AircompanyComponent,
    RentacarserviceComponent,
    AircompanylistComponent,
    RentacarlistComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
