import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ProfileService } from 'src/app/services/profile.service';

@Component({
  selector: 'app-update-address',
  templateUrl: './update-address.component.html',
  styleUrls: ['./update-address.component.scss']
})
export class UpdateAddressComponent implements OnInit {

  myForm: FormGroup = this.fb.group({
    city: '',
    country: '',
  });
  
  @Input() email: string = '';

  constructor(
    private fb: FormBuilder,
    private profileService: ProfileService
  ) { }

  ngOnInit(): void {
    // this.myForm.valueChanges.subscribe(console.log)
  }

  updateAddress(): void {
    const { city, country } = this.myForm.value;
    this.profileService.getIdByEmail(this.email).then(response => {
      this.profileService.updateAddress(city, country, response);
    })
    // console.log(this.email);
  }

}
