import { Injectable } from '@angular/core';
import { Rentacar } from 'src/app/entities/rentacar/rentacar';

@Injectable({
  providedIn: 'root'
})
export class CarserviceService {

  constructor() { }

  loadCompanies() {
    console.log('Učitavanje rent-a-car servisa...');
    return this.mockedCompanies();
  }

  mockedCompanies(): Array<Rentacar> {
    let allRents = new Array<Rentacar>();

    const c1 = new Rentacar('Acara Rent', 'www.acara.rent.com', 8, new Array<string>('BMW', 'Mercedes', 'Audi'));
    const c2 = new Rentacar('Petrov Rent-a-car', 'www.petrov.rs', 8, new Array<string>('BMW', 'Mercedes', 'Audi'));
    const c3 = new Rentacar('Rentara David', 'www.rentara.com', 8, new Array<string>('BMW', 'Mercedes', 'Audi'));
    const c4 = new Rentacar('Rentalescu Rumulescu', 'www.rumulescu.ro', 8, new Array<string>('BMW', 'Mercedes', 'Audi'));
    

    allRents.push(c1);
    allRents.push(c2);
    allRents.push(c3);
    allRents.push(c4);
    

    return allRents;
  }
}
