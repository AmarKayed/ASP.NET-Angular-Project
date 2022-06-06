import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from 'src/app/guards/auth.guard';
import { ProfileComponent } from './profile/profile.component';

export const routes: Routes = [
  { path: 'profile/:email', canActivate:[AuthGuard], component: ProfileComponent}
];


