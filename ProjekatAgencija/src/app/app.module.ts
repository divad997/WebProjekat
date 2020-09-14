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
import { BookflightComponent } from './bookflight/bookflight.component';
import { NavComponent } from './nav/nav.component';
import { AuthService } from './services/authservice/auth.service';
import { BookcarComponent } from './bookcar/bookcar.component';


@NgModule({
  declarations: [
    AppComponent,
    ProfileComponent,
    RegisterComponent,
    AircompanylistComponent,
    RentacarlistComponent,
    AirdetailsComponent,
    RentacardetailsComponent,
    BookflightComponent,
    NavComponent,
    BookcarComponent,
    
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
