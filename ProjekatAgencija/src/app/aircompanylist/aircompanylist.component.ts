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
  tmp1: string;
  tmp2: string;

  constructor(private airService: AirserviceService) {
    this.loadAllAC();
   }

  ngOnInit(): void {

    
  }

  loadAllAC() {  
    this.airService.getAirCompanies().subscribe(
      (res: any) => {
        console.log(res);
        this.allCompanies = res as Array<AirCompany>;
      },
      err => {
        console.log(err);
      }
    );
  }

  onSearchClick()
  {
    this.tmp1 = (<HTMLInputElement>document.getElementById("DestinationFrom")).value;
    this.tmp2 = (<HTMLInputElement>document.getElementById("DestinationTo")).value;
    console.log(this.tmp1, this.tmp2);
    this.airService.searchByDestination(this.tmp1, this.tmp2).subscribe(
      (res: any) => {
        console.log(res);
        this.allCompanies = res as Array<AirCompany>;
      },
      err => {
        console.log(err);
      }
    );
  }

  onResetClick()
  {
    this.loadAllAC();
  }

}
