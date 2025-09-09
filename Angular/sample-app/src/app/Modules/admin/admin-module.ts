import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminRoutingModule } from './admin-routing-module';
import { Admin } from './admin';
import { Rights } from '../../Components/rights/rights';
import { User } from '../../Components/user/user';
import { Dashboard } from '../../Components/dashboard/dashboard';


@NgModule({
  declarations: [
    Admin,
    Dashboard,
    User,
    Rights
  ],
  imports: [
    CommonModule,
    AdminRoutingModule
  ]
})
export class AdminModule { }
