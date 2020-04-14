import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProfileComponent } from './profile/profile.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { RentacarserviceComponent } from './rentacarservice/rentacarservice.component';
import { AircompanylistComponent } from './aircompanylist/aircompanylist.component';
import { RentacarlistComponent } from './rentacarlist/rentacarlist.component';
import { AirdetailsComponent } from './airdetails/airdetails.component';

const routes: Routes = [
  {
    path : "profile",
    component: ProfileComponent
  },
  {
    path : "login",
    component: LoginComponent
  },
  {
    path : "register",
    component: RegisterComponent
  },
  {
    path : "aircompanylist",
    children: [
      { path: "", component: AircompanylistComponent },
      { path: ":airdetails", component: AirdetailsComponent }
    ]
  },
  {
    path : "rentacarlist",
    children: [
      { path: "", component: RentacarlistComponent },
      { path: ":rentacar", component: RentacarserviceComponent }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
