import { Component, OnInit } from '@angular/core';
import { Rentacar } from '../entities/rentacar/rentacar';
import { CarserviceService } from '../services/carservice/carservice.service';

@Component({
  selector: 'app-rentacarlist',
  templateUrl: './rentacarlist.component.html',
  styleUrls: ['./rentacarlist.component.css']
})
export class RentacarlistComponent implements OnInit {

  allRents: Array<Rentacar>;

  constructor(private carService: CarserviceService) {
    this.allRents = this.carService.loadCompanies();
   }

  ngOnInit(): void {
  }

}
