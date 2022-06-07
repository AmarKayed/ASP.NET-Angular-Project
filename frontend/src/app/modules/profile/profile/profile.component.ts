import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { ProfileService, Student, StudentDetailsClass } from 'src/app/services/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  email: string = '';
  // studentDetails: StudentDetailsClass = new StudentDetailsClass;
  studentDetails: StudentDetailsClass = new StudentDetailsClass;
  showDeadlines: boolean = false;
  showAddDeadline: boolean = false;
  showUpdateAddress: boolean = false;

  constructor(
    private auth: AuthService,
    private route: ActivatedRoute,
    private profileService: ProfileService
  ) {
    this.route.params.subscribe((params) => {this.email = params['email']});

    this.profileService.getIdByEmail(this.email)
    .then(response => {
      this.profileService.getStudent(response).then(student => {
        this.profileService.getStudentAddress(response).then(address => {
          this.profileService.getStudentDeadlines(response).then(deadlines => {
            const { name, major, email, city, country} = {...student, ...address}
            const newStudentDetailsClass = new StudentDetailsClass( name, major, email, city, country, deadlines); 
            this.profileService.changeMessage(newStudentDetailsClass)
          });
        });
      });
    });
  }

  ngOnInit(): void {
    this.profileService.currentMessage.subscribe(message => this.studentDetails = message);
  }

  toggleDeadlines() {
    this.showDeadlines = !this.showDeadlines;
  }

  toggleAddDeadline() {
    this.showUpdateAddress = false;
    this.showAddDeadline = !this.showAddDeadline;
  }

  toggleUpdateAddress() {
    this.showAddDeadline = false;
    this.showUpdateAddress = !this.showUpdateAddress;
  }

  logout(): void{
    this.auth.logout();
  }

}
