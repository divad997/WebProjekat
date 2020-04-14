import { Injectable } from '@angular/core';
import { AirCompany } from 'src/app/entities/aircompany/aircompany';

@Injectable({
  providedIn: 'root'
})
export class AirserviceService {

  constructor() { }

  loadCompanies() {
    console.log('Učitavanje kompanija...');
    return this.mockedCompanies();
  }

  mockedCompanies(): Array<AirCompany> {
    let allCompanies = new Array<AirCompany>();

    const c1 = new AirCompany('Air Serbia', 'www.airserbia.com', 8, new Array<string>('Serbia', 'Tokyo', 'Wuhan'));
    const c2 = new AirCompany('Air Serbia', 'www.airserbia.com', 8, new Array<string>('Serbia', 'Tokyo', 'Wuhan'));
    const c3 = new AirCompany('Air Serbia', 'www.airserbia.com', 8, new Array<string>('Serbia', 'Tokyo', 'Wuhan'));
    const c4 = new AirCompany('Air Serbia', 'www.airserbia.com', 8, new Array<string>('Serbia', 'Tokyo', 'Wuhan'));
    

    allCompanies.push(c1);
    allCompanies.push(c2);
    allCompanies.push(c3);
    allCompanies.push(c4);
    

    return allCompanies;
  }

}
