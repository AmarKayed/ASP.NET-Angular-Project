import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';

import { Router } from '@angular/router';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  myForm: FormGroup = this.fb.group({
    email: 'email2@gmail.com',
    password: 'Parola123!',
    repeatPassword: 'Parola123!',
  });

  loginResult: boolean = false;
  toggleResponseMessage: boolean = false;
  toggleRegister: boolean = false;

  constructor(
    private auth: AuthService,
    private fb: FormBuilder,
    private router: Router
  ) { }

  ngOnInit(): void {
    // this.myForm.valueChanges.subscribe(console.log)
  }


  toggle(){
    this.toggleRegister = !this.toggleRegister;
  }

  login(): void {
    const { email, password} = this.myForm.value;
    // console.warn(email, password)
    this.auth.login(email, password)
      .then(response => {
        this.loginResult = response;
        // console.log("Login Response: " + response)
        this.toggleResponseMessage = true;
        if(this.loginResult)
          this.router.navigate([`/profile/${email}`]);
      });
    // console.log(this.loginResult)

  }


  register(): void{
    const { email, password, repeatPassword} = this.myForm.value;
    if (!(password === repeatPassword)){
      alert("Passwords donot match!")
    }
    else{
      this.auth.register(email, password);
    }
  }


}
