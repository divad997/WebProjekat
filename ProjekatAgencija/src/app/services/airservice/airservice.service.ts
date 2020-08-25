import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { AirCompany } from 'src/app/entities/aircompany/aircompany';

@Injectable({
  providedIn: 'root'
})
export class AirserviceService {

  url = 'http://localhost:60615/Api/Air';  
  constructor(private http: HttpClient) { }  
  getAllAC(){  
    return this.http.get(this.url + '/AllAirDetails');  
  }  
  getACById(Id: number){  
    return this.http.get(this.url + '/GetAirDetailsById/' + Id);  
  }  
  createAC(user: AirCompany) {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.post(this.url + '/InsertAirDetails/',  
    user, httpOptions);  
  }  
  updateAC(ac: AirCompany) {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.put(this.url + '/UpdateAirDetails/',  
    ac, httpOptions);  
  }  
  deleteACById(id: number) {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.delete(this.url + '/DeleteAirDetails?id=' +id,  
 httpOptions);  
  } 

}
