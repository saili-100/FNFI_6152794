import { NgModule, provideBrowserGlobalErrorListeners, provideZonelessChangeDetection } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing-module';
import { App } from './app';
import { ContactList } from './Components/contact-list/contact-list';
import { ContactView } from './Components/contact-view/contact-view';
import { EditContact } from './Components/edit-contact/edit-contact';
import { ErrorPage } from './Components/error-page/error-page';
import { Navbar } from './Components/navbar/navbar';
import { NewContact } from './Components/new-contact/new-contact';
import { provideHttpClient } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    App,
    ContactList,
    ContactView,
    EditContact,
    ErrorPage,
    Navbar,
    NewContact,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule
  ],
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZonelessChangeDetection(),
    provideHttpClient()
  ],
  bootstrap: [App]
})
export class AppModule { }
