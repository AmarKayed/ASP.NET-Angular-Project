import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

export interface Deadline {
  title: string;
  daysLeft: number;
}

export interface Address {
  city: string;
  country: string;
}

export interface Student {
  name: string;
  major: string;
  email: string;
}

export interface StudentDetails extends Student, Address {
  deadlines: Deadline[];
}

export class DeadlineClass implements Deadline{
  title: string='';
  daysLeft: number=1;
}

export class StudentDetailsClass implements StudentDetails {
  name: string = '';
  major: string = '';
  email: string = '';
  city: string = '';
  country: string = '';
  deadlines: Deadline[] = [];

  constructor(
    name: string = '',
    major: string = '',
    email: string = '',
    city: string = '',
    country: string = '',
    deadlines: Deadline[] = [],
  ) {
    this.name = name;
    this.major = major;
    this.email = email;
    this.city = city;
    this.country = country;
    this.deadlines = deadlines;
  }
}

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  private apiUrl = 'https://localhost:44380/api';

  private messageSource = new BehaviorSubject<StudentDetailsClass>(new StudentDetailsClass());
  currentMessage = this.messageSource.asObservable();
  
  constructor() { }

  changeMessage(message: StudentDetailsClass){
    this.messageSource.next(message)
  }

  getIdByEmail(email: string): Promise<number> {
    return fetch(`${this.apiUrl}/Students/get-id-by-email/${email}`)
    .then(response => response.json())
    .catch(console.warn);
  }

  getStudent(id: number): Promise<Student>{
    return fetch(`${this.apiUrl}/Students/get/${id}`)
    .then(response => response.json())
    .catch(console.warn);
  }

  getStudentAddress(id: number): Promise<Address>{
    return fetch(`${this.apiUrl}/StudentAddresses/get-by-student-id/?studentId=${id}`)
    .then(response => response.json())
    .catch(console.warn);
  }

  getStudentDeadlines(id: number): Promise<Deadline[]>{
    return fetch(`${this.apiUrl}/Deadlines/get-by-student-id/?studentId=${id}`)
    .then(response => response.json())
    .catch(console.warn);
  }


  addDeadline(title: string, daysLeft: number, id: number) {
    if(daysLeft >= 1 && !(title === '')) {
      console.log(title, daysLeft, id)
      const data = { title: title, daysLeft: daysLeft}
      fetch(`${this.apiUrl}/Deadlines/create/${id}`, {
        headers: {
          'Content-Type': 'application/json',
        },
        method: 'POST',
        body: JSON.stringify(data)
      })
      .catch(error => {
        console.warn(error)
      });
    }
  }

  updateAddress(city: string, country: string, id: number) {
    const data = { city: city, country: country};
    fetch(`${this.apiUrl}/StudentAddresses/update-by-student-id/${id}`, {
      headers: {
        'Content-Type': 'application/json',
      },
      method: 'PUT',
      body: JSON.stringify(data)
    })
    .then(() => {
      this.getStudentAddress(id).then(address => {
        const newStudent = this.messageSource.value;
        newStudent.city = address.city; newStudent.country = address.country;
        this.changeMessage(newStudent);
      })
    })
    .catch(error => {
      console.warn(error)
    });
  }

}
