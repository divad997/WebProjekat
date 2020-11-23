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
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


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

    MatInputModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule, 
    ReactiveFormsModule,
    MatFormFieldModule,
    MatSelectModule,
    BrowserAnimationsModule
    
  ],
  providers: [
    UserserviceService, 
    AuthService
  ], 
  bootstrap: [AppComponent]
})
export class AppModule { }
