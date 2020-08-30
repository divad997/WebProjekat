import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule} from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ProfileComponent } from './profile/profile.component';
import { RegisterComponent } from './register/register.component';
import { AircompanylistComponent } from './aircompanylist/aircompanylist.component';
import { RentacarlistComponent } from './rentacarlist/rentacarlist.component';
import { AirdetailsComponent } from './airdetails/airdetails.component';
import { RentacardetailsComponent } from './rentacardetails/rentacardetails.component';
import { UserserviceService } from './services/userservice/userservice.service';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './services/authservice/auth.service';


@NgModule({
  declarations: [
    AppComponent,
    ProfileComponent,
    RegisterComponent,
    AircompanylistComponent,
    RentacarlistComponent,
    AirdetailsComponent,
    RentacardetailsComponent,
    NavComponent,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule, 
    ReactiveFormsModule
  ],
  providers: [
    UserserviceService, 
    AuthService
  ], 
  bootstrap: [AppComponent]
})
export class AppModule { }
