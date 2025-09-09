import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { App } from './app';
import { Calc } from './Components/calc/calc';
import { Master } from './Components/master/master';
import { Second } from './Components/second/second';
import { ValidationForm } from './validation-form/validation-form';
import ReactiveForm from './Components/reactive-form/reactive-form';

const routes: Routes = [
  {path:"", redirectTo: "/Calc", pathMatch: "full"},
  // {path:"Home", component:App},
  {path:"Calc",component:Calc},
  {path:"Master-Detail", component:Master},
  {path:"Second", component:Second},
  {path:"Validation", component:ValidationForm},
  {path:"Reactive", component:ReactiveForm},
  { path: 'admin', loadChildren: () => import('./Modules/admin/admin-module').then(m => m.AdminModule) }
  //for UR lazy loading of module,Admin module to load on;y when the user clicks Admin....

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
