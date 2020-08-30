import { Component, OnInit } from '@angular/core';
import { AirserviceService } from '../services/airservice/airservice.service';
import { AirCompany } from '../entities/aircompany/aircompany';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-airdetails',
  templateUrl: './airdetails.component.html',
  styleUrls: ['./airdetails.component.css']
})
export class AirdetailsComponent implements OnInit {

  Company: AirCompany;
  ACId: number;

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

}
