import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';  
import { HttpHeaders } from '@angular/common/http';  
import { Observable } from 'rxjs';
import { User } from 'src/app/entities/user';

@Injectable({
  providedIn: 'root'
})
export class UserserviceService {

  url = 'http://localhost:50370/api';  
  constructor(private http: HttpClient) { }
  
  postUser(formData:User){
   return this.http.post(this.url + '/Auth/register', formData);
  }

  getUserById(id) {
    var idModel = {
      Id: id
    }
    return this.http.post(this.url + '/Users/GetUserById', idModel);
  }

  editUser(user: User){
    return this.http.post(this.url + '/Users/EditUser', user);
  }
  
  /*getAllUsers(){  
    return this.http.get(this.url + '/AllUserDetails');  
  }  
  getUserById(Id: number){  
    return this.http.get(this.url + '/GetUserDetailsById/' + Id);  
  }  
  createUser(user: User) {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.post(this.url + '/InsertUserDetails/',  
    user, httpOptions);  
  }  
  updateUser(user: User) {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.put(this.url + '/UpdateUserDetails/',  
    user, httpOptions);  
  }  
  deleteUserById(id: number) {  
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };  
    return this.http.delete(this.url + '/DeleteUserDetails?id=' +id,  
 httpOptions);  
  }*/ 
}
