import { Component, OnInit } from '@angular/core';
import { AirserviceService } from '../services/airservice/airservice.service';
import { AirCompany } from '../entities/aircompany/aircompany';

@Component({
  selector: 'app-aircompanylist',
  templateUrl: './aircompanylist.component.html',
  styleUrls: ['./aircompanylist.component.css']
})
export class AircompanylistComponent implements OnInit {

  allCompanies: Array<AirCompany>;

  constructor(private airService: AirserviceService) {
    this.allCompanies = this.airService.loadCompanies();
   }

  ngOnInit(): void {


  }

}
