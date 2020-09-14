import { Injectable } from '@angular/core';
import { RentCompany, Car } from 'src/app/entities/rentacar/rentacar';
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

  getRentCompany(id: number){
    
    return this.http.get(this.url + '/RentCompanies/' + id.toString());
  }

  bookCar(location: string, d1: string, d2: string, id: number)
  {
    var idModel = {
      Id: id,
      Location: location,
      DateStart: d1,
      DateReturn: d2
    }

    return this.http.post(this.url + '/RentCompanies/BookCar', idModel);
  }

  reserveCar(car: number, un: string, pn: string, tp: number, d1: string, d2: string, lc: string, rc: number)
  {
    var idModel = {
      CarId: car,
      Username: un,
      PassportNumber: pn,
      TotalPrice: tp,
      DateStart: d1,
      DateReturn: d2,
      Location: lc,
      RCId: rc
    }

    return this.http.post(this.url + '/RentCompanies/ReserveCar', idModel);
  }
  
}
