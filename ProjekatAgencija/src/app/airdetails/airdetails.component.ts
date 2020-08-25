import { Component, OnInit } from '@angular/core';
import { AirserviceService } from '../services/airservice/airservice.service';
import { AirCompany } from '../entities/aircompany/aircompany';

@Component({
  selector: 'app-airdetails',
  templateUrl: './airdetails.component.html',
  styleUrls: ['./airdetails.component.css']
})
export class AirdetailsComponent implements OnInit {

  allCompanies: Array<AirCompany>;

  constructor(private airService: AirserviceService) {
    
   }

  ngOnInit(): void {
  }

}
