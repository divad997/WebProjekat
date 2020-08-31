import { Component, OnInit } from '@angular/core';
import { AirCompany, Flight } from '../entities/aircompany/aircompany';
import { AirserviceService } from '../services/airservice/airservice.service';
import { ActivatedRoute } from '@angular/router';
import { UserserviceService } from '../services/userservice/userservice.service';
import { AuthService } from '../services/authservice/auth.service';
import { User } from '../entities/user';

@Component({
  selector: 'app-bookflight',
  templateUrl: './bookflight.component.html',
  styleUrls: ['./bookflight.component.css']
})
export class BookflightComponent implements OnInit {

  Company: AirCompany;
  ACId: number;
  destFrom: string;
  destTo: string;
  date: string;
  flights: Array<Flight>;
  user: User;
  numberOfTickets: string;

  constructor(private airService: AirserviceService, route: ActivatedRoute, private userService: UserserviceService, private authService: AuthService) {
    route.params.subscribe(params => {this.ACId = params.id});
   }

  ngOnInit(): void {
    this.getACById();
    this.loggedUser();
  }

  getACById()
  {
    this.airService.getAirCompany(this.ACId).subscribe(
      (res: any) => {
        this.Company = res as AirCompany;
      });
  }

  onBookClick()
  {
    this.destFrom = (<HTMLInputElement>document.getElementById("destfrom")).value;
    this.destTo = (<HTMLInputElement>document.getElementById("destto")).value;
    this.date = (<HTMLInputElement>document.getElementById("date")).value;
    console.log(this.destFrom, this.destTo, this.date);

    this.airService.bookFlight(this.destFrom, this.destTo, this.date, this.ACId).subscribe(
      (res: any) => {
        this.flights = res as Array<Flight>;
        console.log(this.flights);
      });
  }

  reserveFlight(event, flight)
  {
    this.numberOfTickets = (<HTMLInputElement>document.getElementById("ticketNum")).value;
    this.airService.reserveFligth(flight, this.user.Username, this.user.PassportNumber, this.numberOfTickets).subscribe(
      (res: any) => {
        alert("Reservation complete");
      },
      (err: any) => {
        alert("Reservation could not be processed");
      }
    )
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

}
