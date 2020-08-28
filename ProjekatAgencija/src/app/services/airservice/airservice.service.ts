import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { AirCompany } from 'src/app/entities/aircompany/aircompany';

@Injectable({
  providedIn: 'root'
})
export class AirserviceService {

  url = 'http://localhost:50370/api';  
  constructor(private http: HttpClient) { } 

  getAirCompanies()
  {
    return this.http.get(this.url + '/AirCompanies');
  }
}
