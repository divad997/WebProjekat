import { Component, OnInit } from '@angular/core';
import {  RentCompany } from '../entities/rentacar/rentacar';
import { CarserviceService } from '../services/carservice/carservice.service';

@Component({
  selector: 'app-rentacarlist',
  templateUrl: './rentacarlist.component.html',
  styleUrls: ['./rentacarlist.component.css']
})
export class RentacarlistComponent implements OnInit {

  allCompanies: Array<RentCompany>;
  

  constructor(private carService: CarserviceService) {
    
   }

  ngOnInit(): void {

    this.loadAllRC();
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

}
