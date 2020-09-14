import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Car, RentCompany } from '../entities/rentacar/rentacar';
import { User } from '../entities/user';
import { AuthService } from '../services/authservice/auth.service';
import { CarserviceService } from '../services/carservice/carservice.service';
import { UserserviceService } from '../services/userservice/userservice.service';

@Component({
  selector: 'app-bookcar',
  templateUrl: './bookcar.component.html',
  styleUrls: ['./bookcar.component.css']
})
export class BookcarComponent implements OnInit {
  
  RCId: number;
  CarId: number;
  Company: RentCompany;
  Car: Car;
  User: User;
  Location: string;
  Date1: string;
  Date2: string;
  TotalPrice: number;
  


  constructor(route: ActivatedRoute, private carService: CarserviceService, private userService: UserserviceService, private authService: AuthService) { 
    route.params.subscribe(params => {this.RCId = params.id});
    route.params.subscribe(params => {this.CarId = params.carid});
  }

  ngOnInit(): void {
    this.getRCById();
    this.loggedUser();
    this.getCarId();
    
  }

  private getCarId() {
    this.Car = this.Company.Cars.find(car => { this.CarId == car.Id; });
    this.CarId = this.Car.Id;
  }

  getRCById()
  {
    this.carService.getRentCompany(this.RCId).subscribe(
      (res: any) => {
        this.Company = res as RentCompany;
      });
  }

  loggedUser()
  {
    this.userService.getUserById(this.authService.decodedToken.nameid).subscribe(
      (res: any) => {
        console.log(res);
        this.User = res as User;
        
      });
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  onBookClick()
  {
    this.Location = (<HTMLInputElement>document.getElementById("location")).value;
    this.Date1 = (<HTMLInputElement>document.getElementById("date1")).value;
    this.Date2 = (<HTMLInputElement>document.getElementById("date2")).value;
    console.log(this.Location, this.Date1, this.Date2);

    this.carService.bookCar(this.Location, this.Date1, this.Date2, this.CarId).subscribe(
      (res: any) => {
        this.TotalPrice = res as number;
        console.log(this.TotalPrice);
      });
  }

  reserveCar()
  {
    
    this.carService.reserveCar(this.CarId, this.User.Username, this.User.PassportNumber, this.TotalPrice, this.Date1, this.Date2, this.Location, this.RCId).subscribe(
      (res: any) => {
        alert("Reservation complete");
      },
      (err: any) => {
        alert("Reservation could not be processed");
      }
    )
  }

}
