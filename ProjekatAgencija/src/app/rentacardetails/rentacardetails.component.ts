import { Component, OnInit } from '@angular/core';
import { CarserviceService } from '../services/carservice/carservice.service'
import { AuthService } from '../services/authservice/auth.service';
import { UserserviceService } from '../services/userservice/userservice.service';
import { User } from '../entities/user';
import { ActivatedRoute } from '@angular/router';
import { RentCompany } from '../entities/rentacar/rentacar';

@Component({
  selector: 'app-rentacardetails',
  templateUrl: './rentacardetails.component.html',
  styleUrls: ['./rentacardetails.component.css']
})
export class RentacardetailsComponent implements OnInit {
  
  Company: RentCompany;
  RCId: number;
  admin: boolean;
  

  constructor(private carService: CarserviceService, private authService: AuthService, private userService: UserserviceService, route: ActivatedRoute) {
    route.params.subscribe(params => {this.RCId = params.id});
   }

  user: User;

  ngOnInit(): void {
    this.getRCById();
  }


  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  isAdmin()
  {
    this.userService.getUserById(this.authService.decodedToken.nameid).subscribe(
      (res: any) => {
        
        this.user = res;
        if(this.user.Role == "Admin")
          this.admin = true;
        else 
          this.admin = false;
      });
  }

  deleteRent()
  {
    this.carService.deleteRent(this.RCId).subscribe(
      (res: any) => {
        console.log(res);
      },
      err => {
        console.log(err);
      }
    );
  }

  getRCById()
  {
    this.carService.getRentCompany(this.RCId).subscribe(
      (res: any) => {
        this.Company = res as RentCompany;
      });
  }
}
