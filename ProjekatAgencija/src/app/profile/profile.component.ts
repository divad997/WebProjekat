import { Component, OnInit } from '@angular/core';
import { AuthService } from '../services/authservice/auth.service';
import { User } from '../entities/user';
import { UserserviceService } from '../services/userservice/userservice.service';
import { FormBuilder, FormGroup, FormControl } from '@angular/forms';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  user: User;
  userHelp: User;
  editForm: FormGroup;

  constructor(private authService: AuthService, private userService: UserserviceService, private formbuilder: FormBuilder) {
    
   }

  ngOnInit(): void {
    this.loadUser();
    
  }

  loadUser()
  {
    this.userService.getUserById(this.authService.decodedToken.nameid).subscribe(
      (res: any) => {
        console.log(res);
        this.user = res;
        console.log(this.user);
        this.editForm = this.formbuilder.group(
          {
            Username: new FormControl(this.user.Username),
            Email: new FormControl(this.user.Email),
            Password: new FormControl(this.user.Password),
            ConfirmPassword: new FormControl(this.user.Password),
            Name: new FormControl(this.user.Name),
            LastName: new FormControl(this.user.LastName),
            City: new FormControl(this.user.City),
            PhoneNumber: new FormControl(this.user.PhoneNumber),
            PassportNumber: new FormControl(this.user.PassportNumber)
          }
        );
      });
  }

  onEditSubmit()
  {
    this.userHelp = <User> this.editForm.value;
    this.userHelp.Id = this.user.Id;
    this.userHelp.Role = this.user.Role;
    console.log(this.user);
    this.userService.editUser(this.userHelp).subscribe(
      (res: any) => {
        alert("Details edited");
      },
      err => {
        alert("Something went wrong");
      });
  }
    
}
