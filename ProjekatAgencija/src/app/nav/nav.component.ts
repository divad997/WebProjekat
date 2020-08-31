import { Component, OnInit } from '@angular/core';
import { User } from '../entities/user'
import { AuthService } from '../services/authservice/auth.service';
import { UserserviceService } from '../services/userservice/userservice.service';


@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  model: any = {};
  user: User;

  constructor(private authService: AuthService, private userService: UserserviceService) { }

  ngOnInit(): void {
  }

  login(){
    this.authService.login(this.model).subscribe(next => {
      console.log('Logged in successfully');
    }, error => {
      console.log('Failed to Log in');
    });
  }

  isAdmin()
  {
    this.userService.getUserById(this.authService.decodedToken.nameid).subscribe(
      (res: any) => {
        
        this.user = res;
        if(this.user.Role == "Admin")
          return true;
        else 
          return false;
      });
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    return !!token;
  }

  logout() {
    localStorage.removeItem('token');
    console.log('logged out');
  }

}
