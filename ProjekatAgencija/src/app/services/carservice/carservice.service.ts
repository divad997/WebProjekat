import { Injectable } from '@angular/core';
import { RentCompany } from 'src/app/entities/rentacar/rentacar';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CarserviceService {

  url = 'http://localhost:50370/api';  
  constructor(private http: HttpClient) { } 

  getRentCompanies()
  {
    return this.http.get(this.url + '/RentCompanies');
  }

  deleteRent(id: number)
  {
    return this.http.delete(this.url + '/RentCompanies/' + id.toString()); 
  }
}
