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
    
   }

  ngOnInit(): void {

    this.loadAllAC();
  }

  loadAllAC() {  
    this.airService.getAllAC().subscribe(
      (res: any) => {
        console.log(res);
        this.allCompanies = res as Array<AirCompany>;
      },
      err => {
        console.log(err);
      }
    );
  }

}
