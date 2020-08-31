import { Component, OnInit } from '@angular/core';
import { AirCompany, Flight } from '../entities/aircompany/aircompany';
import { AirserviceService } from '../services/airservice/airservice.service';
import { ActivatedRoute } from '@angular/router';

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

  constructor(private airService: AirserviceService, route: ActivatedRoute) {
    route.params.subscribe(params => {this.ACId = params.id});
   }

  ngOnInit(): void {
    this.getACById();
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
    this.airService.reserveFligth(flight).subscribe(
      (res: any) => {
        alert("Reservation complete");
      },
      (err: any) => {
        alert("Reservation could not be processed");
      }
    )
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

}
