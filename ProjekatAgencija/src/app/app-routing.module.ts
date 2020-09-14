import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProfileComponent } from './profile/profile.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { RentacardetailsComponent } from './rentacardetails/rentacardetails.component';
import { AircompanylistComponent } from './aircompanylist/aircompanylist.component';
import { RentacarlistComponent } from './rentacarlist/rentacarlist.component';
import { AirdetailsComponent } from './airdetails/airdetails.component';
import { BookflightComponent } from './bookflight/bookflight.component';
import { BookcarComponent } from './bookcar/bookcar.component';

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
      { path: ":id/details", component: AirdetailsComponent }
    ]
  },
  {
    path : "rentacarlist",
    children: [
      { path: "", component: RentacarlistComponent },
      { path: ":id/details", component: RentacardetailsComponent },
      { path: ":id/details/car/:carid", component: BookcarComponent }
    ]
  },
  {
    path : "bookflight/:id",
    component: BookflightComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
