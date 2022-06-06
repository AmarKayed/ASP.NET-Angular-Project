import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { routes } from './profile.routes';

import { ProfileComponent } from './profile/profile.component';
import { DeadlineComponent } from './deadline/deadline.component';

@NgModule({
  declarations: [
    ProfileComponent,
    DeadlineComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
  ]
})
export class ProfileModule { }
