import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { Admin } from './admin';
import { Rights } from '../../Components/rights/rights';
import { User } from '../../Components/user/user';
import { Dashboard } from '../../Components/dashboard/dashboard';

//localhost:4200/Admin/dashboard

const routes: Routes = [{ path: 'admin', children:[
  {path:"dashboard", component:Dashboard},
  {path:"user", component:User},
  {path:"rights", component:Rights},
]}];

@NgModule({
  imports: [RouterModule.forChild(routes)], //This module shall load the components on request only
  exports: [RouterModule]
})
export class AdminRoutingModule { }
