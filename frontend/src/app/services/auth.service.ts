import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private apiUrl = 'https://localhost:44380/api';

  constructor(private router: Router) { }

  async login(email: string, password: string): Promise<boolean>{
    const data = {email: email, password: password};
    // const data = {email: "email@gmail.com", password: "Parola123!"};
    // console.log(JSON.stringify(data));
    
    // fetch(`${this.apiUrl}/Students/get`).then(response => response.json())
    // .then(response => console.log(response))
    

    return fetch(`${this.apiUrl}/Auth/Login`, {
      headers: {
        'Content-Type': 'application/json',
      },
      method: 'POST',
      body: JSON.stringify(data)
    })
    .then(response => response.json())
    .then(response => {
      localStorage.setItem('accessToken', response.accessToken);
      localStorage.setItem('refreshToken', response.refreshToken);
      return true;
    })
    .catch(error => {
      console.warn(error)
      return false;
    });
 


    // fetch(`${this.apiUrl}/breeds?limit=${this.limit}`, {
    //   headers:{
    //     'x-api-key': this.apiKey
    //   }
    // }).then(response => response.json());

    
  }

  logout() {
    localStorage.clear();
    this.router.navigate(['/login']);
  }

  isAuthenticated(): boolean {
    return !!localStorage.getItem('accessToken');
  }

}
