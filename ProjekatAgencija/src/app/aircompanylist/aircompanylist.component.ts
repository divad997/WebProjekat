import { Component, OnInit } from '@angular/core';
import { AirserviceService } from '../services/airservice/airservice.service';
import { AirCompany, Destination } from '../entities/aircompany/aircompany';
import { AuthService } from '../services/authservice/auth.service';
import { UserserviceService } from '../services/userservice/userservice.service';
import { User } from '../entities/user';

@Component({
  selector: 'app-aircompanylist',
  templateUrl: './aircompanylist.component.html',
  styleUrls: ['./aircompanylist.component.css']
})
export class AircompanylistComponent implements OnInit {


  user: User;
  allCompanies: Array<AirCompany>;
  tmp1: string;
  tmp2: string;
  tmp3: string;
  tmp4: string;

  constructor(private airService: AirserviceService, private authService: AuthService, private userService: UserserviceService) {
    this.loadAllAC();
   }

  ngOnInit(): void {

    
  }

  loadAllAC() {  
    this.airService.getAirCompanies().subscribe(
      (res: any) => {
        console.log(res);
        this.allCompanies = res as Array<AirCompany>;
      },
      err => {
        console.log(err);
      }
    );
  }

  onSearchClick()
  {
    this.tmp1 = (<HTMLInputElement>document.getElementById("DestinationFrom")).value;
    this.tmp2 = (<HTMLInputElement>document.getElementById("DestinationTo")).value;
    console.log(this.tmp1, this.tmp2);
    this.airService.searchByDestination(this.tmp1, this.tmp2).subscribe(
      (res: any) => {
        console.log(res);
        this.allCompanies = res as Array<AirCompany>;
      },
      err => {
        console.log(err);
      }
    );
  }

  onSearchDateClick()
  {
    this.tmp3 = (<HTMLInputElement>document.getElementById("TakeoffDate")).value;
    this.tmp4 = (<HTMLInputElement>document.getElementById("LandDate")).value;
    console.log(this.tmp1, this.tmp2);
    this.airService.searchByDate(this.tmp3, this.tmp4).subscribe(
      (res: any) => {
        console.log(res);
        this.allCompanies = res as Array<AirCompany>;
      },
      err => {
        console.log(err);
      }
    );
  }

  onSearchBothClick()
  {
    this.tmp1 = (<HTMLInputElement>document.getElementById("DestinationFrom")).value;
    this.tmp2 = (<HTMLInputElement>document.getElementById("DestinationTo")).value;
    this.tmp3 = (<HTMLInputElement>document.getElementById("TakeoffDate")).value;
    this.tmp4 = (<HTMLInputElement>document.getElementById("LandDate")).value;
    console.log(this.tmp1, this.tmp2);
    this.airService.searchByBoth(this.tmp1, this.tmp2, this.tmp3, this.tmp4).subscribe(
      (res: any) => {
        console.log(res);
        this.allCompanies = res as Array<AirCompany>;
      },
      err => {
        console.log(err);
      }
    );
  }

  loggedUser()
  {
    this.userService.getUserById(this.authService.decodedToken.nameid).subscribe(
      (res: any) => {
        console.log(res);
        this.user = res;
      });
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
          return true;
        else 
          return false;
      });
  }

  onResetClick()
  {
    this.loadAllAC();
  }

}
