import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators, FormGroup, FormControl } from '@angular/forms';  
import { User } from 'src/app/entities/user';
import { UserserviceService } from 'src/app/services/userservice/userservice.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  userForm: FormGroup;
  private newUser : User = new User();
  users : Array<User> = new Array<User>();


  constructor(private userService:UserserviceService, private formbuilder: FormBuilder) { 
    
  }

  ngOnInit(): void {
    this.userForm = this.formbuilder.group(
      {
        Username: new FormControl(''),
        Email: new FormControl(''),
        Password: new FormControl(''),
        ConfirmPassword: new FormControl(''),
        Name: new FormControl(''),
        LastName: new FormControl(''),
        City: new FormControl(''),
        PhoneNumber: new FormControl(''),
        PassportNumber: new FormControl('')
      }
    );
    //this.loadAllUsers();
  }

  /*loadAllUsers() {  
    this.userService.getAllUsers().subscribe(
      (res: any) => {
        console.log(res);
      }
    );
  }*/
  onFormSubmit()
  {
    console.log('submit');
    this.newUser = <User> this.userForm.value;
    console.log(this.newUser instanceof User);
    console.log(this.newUser);
    this.newUser.Id = 0;
    this.newUser.Role = 'User';

    this.userService.postUser(this.newUser).subscribe(
      res => {
        this.userForm.reset();
      },
      err => {
        console.log(err);
      }
    )

    /*this.userService.createUser(this.newUser).subscribe(  
      (res: any) => {   
        console.log(res)
        //this.loadAllUsers();   
        this.userForm.reset();  
      }  
    );*/
  }

}
