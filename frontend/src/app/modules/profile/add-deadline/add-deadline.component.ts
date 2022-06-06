import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { ProfileService } from 'src/app/services/profile.service';

@Component({
  selector: 'app-add-deadline',
  templateUrl: './add-deadline.component.html',
  styleUrls: ['./add-deadline.component.scss']
})
export class AddDeadlineComponent implements OnInit {

  myForm: FormGroup = this.fb.group({
    title: '',
    daysLeft: 1,
  });
  
  @Input() email: string = '';

  constructor(
    private fb: FormBuilder,
    private profileService: ProfileService
  ) { }

  ngOnInit(): void {
    // this.myForm.valueChanges.subscribe(console.log)
  }

  addDeadline(): void {
    const { title, daysLeft } = this.myForm.value;
    this.profileService.getIdByEmail(this.email).then(response => {
      this.profileService.addDeadline(title, daysLeft, response);
    })
    // console.log(this.email);
  }

}
