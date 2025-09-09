import { NgModule, provideBrowserGlobalErrorListeners, provideZonelessChangeDetection } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { Second } from './Components/second/second';
import { Emp } from './Components/emp/emp';
import { Calc } from './Components/calc/calc';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { EmpDetail } from './Components/emp-detail/emp-detail';
import { Master } from './Components/master/master';
import { ValidationForm } from './validation-form/validation-form';
import { NavBar } from './nav-bar/nav-bar';
import ReactiveForm from './Components/reactive-form/reactive-form';
import { Dashboard } from './Components/dashboard/dashboard';
import { User } from './Components/user/user';
import { Rights } from './Components/rights/rights';
import { AdminModule } from './Modules/admin/admin-module';

@NgModule({
  declarations: [
    App,
    Second,
    Emp,
    Calc,
    EmpDetail,
    Master,
    ValidationForm,
    NavBar,
    ReactiveForm,
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    AdminModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZonelessChangeDetection()
  ],
  bootstrap: [App]
  // Master,Second,Emp removed from here.
})
export class AppModule { }
