import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { AirCompany, Flight } from 'src/app/entities/aircompany/aircompany';

@Injectable({
  providedIn: 'root'
})
export class AirserviceService {

  url = 'http://localhost:50370/api';  
  constructor(private http: HttpClient) { } 

  getAirCompanies()
  {
    return this.http.get(this.url + '/AirCompanies/GetAirCompanies');
  }

  getAirCompany(num: number){
    var idModel = {
      Id: num
    }
    return this.http.post(this.url + '/AirCompanies/ACById', idModel);
  }

  bookFlight(s1: string, s2: string, s3: string, n: number)
  {
    var idModel = {
      Id: n,
      DestinationFrom: s1,
      DestinationTo: s2,
      Date: s3
    }

    return this.http.post(this.url + '/AirCompanies/BookFlight', idModel);
  }

  reserveFligth(flight: Flight, un: string, pn: string, tn: string)
  {
    var idModel = {
      Username: un,
      PassportNumber: pn,
      Fl: flight,
      NumberOfTickets: tn
    }

    return this.http.post(this.url + '/AirCompanies/ReserveFlight', idModel);
  }

  searchByDestination(df: string, dt: string)
  {
    var idModel = {
      DestinationFrom: df,
      DestinationTo: dt
    }
    return this.http.post(this.url + '/AirCompanies/SearchByDestination', idModel);
  }

  searchByDate(td: string, ld: string)
  {
    var idModel = {
      Date: td,
      LandDate: ld
    }
    return this.http.post(this.url + '/AirCompanies/SearchByDate', idModel);
  }

  searchByBoth(df: string, dt: string, td: string, ld: string)
  {
    var idModel = {
      DestinationFrom: df,
      DestinationTo: dt,
      Date: td,
      LandDate: ld
    }
    return this.http.post(this.url + '/AirCompanies/SearchByBoth', idModel);
  }
}
