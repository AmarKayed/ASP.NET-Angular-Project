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
    email: 'email@gmail.com',
    password: 'Parola123!',
  });

  loginResult: boolean = false;
  toggleResponseMessage: boolean = false;

  constructor(
    private auth: AuthService,
    private fb: FormBuilder,
    private router: Router
  ) { }

  ngOnInit(): void {
    // this.myForm.valueChanges.subscribe(console.log)
  }

  login(): void {
    const { email, password} = this.myForm.value;
    // console.warn(email, password)
    this.auth.login(email, password)
      .then(response => {
        this.loginResult = response;
        console.log("Login Response: " + response)
        this.toggleResponseMessage = true;
        if(this.loginResult)
          this.router.navigate(['/profile']);

      });
    // console.log(this.loginResult)
  

  }
}
