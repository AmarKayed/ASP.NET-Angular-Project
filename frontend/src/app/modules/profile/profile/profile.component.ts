import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { ProfileService, StudentDetailsClass } from 'src/app/services/profile.service';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {

  email: string = '';
  studentDetails: StudentDetailsClass = new StudentDetailsClass;
  showDeadlines: boolean = false;

  constructor(
    private auth: AuthService,
    private route: ActivatedRoute,
    private profileService: ProfileService
  ) {
    this.route.params.subscribe((params) => {this.email = params['email']});

    this.profileService.getIdByEmail(this.email)
    .then(response => {
      this.profileService.getStudent(response).then(student => {
        this.studentDetails.name = student.name;
        this.studentDetails.major = student.major;
        this.studentDetails.email = student.email;
        this.profileService.getStudentAddress(response).then(address => {
          this.studentDetails.city = address.city;
          this.studentDetails.country = address.country;
          this.profileService.getStudentDeadlines(response).then(deadlines => {
            this.studentDetails.deadlines = deadlines;
          });
        });
      });
    });
  }

  ngOnInit(): void {}

  toggleDeadlines() {
    this.showDeadlines = !this.showDeadlines;
  }

  logout(): void{
    this.auth.logout();
  }

}
