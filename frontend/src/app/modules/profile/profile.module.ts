import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { routes } from './profile.routes';

import { ProfileComponent } from './profile/profile.component';
import { DeadlineComponent } from './deadline/deadline.component';
import { AddDeadlineComponent } from './add-deadline/add-deadline.component';


import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatChipsModule } from '@angular/material/chips';
import { UpdateAddressComponent } from './update-address/update-address.component';

@NgModule({
  declarations: [
    ProfileComponent,
    DeadlineComponent,
    AddDeadlineComponent,
    UpdateAddressComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),

    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatSelectModule,
    MatButtonModule,
    MatCheckboxModule,
    MatChipsModule,
  ]
})
export class ProfileModule { }
