import { Component, OnInit } from '@angular/core';
import { AirserviceService } from '../services/airservice/airservice.service';
import { AirCompany, Destination } from '../entities/aircompany/aircompany';

@Component({
  selector: 'app-aircompanylist',
  templateUrl: './aircompanylist.component.html',
  styleUrls: ['./aircompanylist.component.css']
})
export class AircompanylistComponent implements OnInit {

  allCompanies: Array<AirCompany>;
  destin: Array<Destination>;

  constructor(private airService: AirserviceService) {
    
   }

  ngOnInit(): void {

    this.loadAllAC();
  }

  loadAllAC() {  
    this.airService.getAirCompanies().subscribe(
      (res: any) => {
        console.log(res);
        this.allCompanies = res as Array<AirCompany>;
        this.destin = this.allCompanies[1].Destinations;
        console.log(this.destin);
      },
      err => {
        console.log(err);
      }
    );
  }

}
