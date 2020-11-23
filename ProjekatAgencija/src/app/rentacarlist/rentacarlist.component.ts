import { Component, OnInit } from '@angular/core';
import {  RentCompany } from '../entities/rentacar/rentacar';
import { CarserviceService } from '../services/carservice/carservice.service';
import { UserserviceService } from '../services/userservice/userservice.service';
import { AuthService } from '../services/authservice/auth.service';
import { User } from '../entities/user';


@Component({
  selector: 'app-rentacarlist',
  templateUrl: './rentacarlist.component.html',
  styleUrls: ['./rentacarlist.component.css']
})
export class RentacarlistComponent implements OnInit {

  allCompanies: Array<RentCompany>;
  Locations: Array<Location>;
  user: User;
  tmp1: string;

  constructor(private carService: CarserviceService, private userService: UserserviceService, private authService: AuthService) {
    
   }

  ngOnInit(): void {

    this.loadAllRC();
    this.loadAllLocations();
  }

  loadAllRC() {  
    this.carService.getRentCompanies().subscribe(
      (res: any) => {
        console.log(res);
        this.allCompanies = res as Array<RentCompany>;
      },
      err => {
        console.log(err);
      }
    );
  }

  loadAllLocations() {
    this.carService.getLocations().subscribe(
      (res: any) => {
        console.log(res);
        this.Locations = res as Array<Location>;
      },
      err => {
        console.log(err);
      }
    );
  }

  onSearchClick()
  {
    
    
    console.log(this.tmp1);
    this.carService.searchByLocation(this.tmp1).subscribe(
      (res: any) => {
        console.log(res);
        this.allCompanies = res as Array<RentCompany>;
      },
      err => {
        console.log(err);
      }
    );
  }

}
