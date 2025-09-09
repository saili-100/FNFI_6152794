import { Component,OnInit } from '@angular/core';
import { contact } from '../../Models/contact';
import { Contact } from '../../Services/contact';

@Component({
  selector: 'app-contact-list',
  standalone: false,
  templateUrl: './contact-list.html',
  styleUrl: './contact-list.css'
})
export class ContactList implements OnInit {
  contactList : any = [];

  constructor(private service : Contact) {
    
  }
  ngOnInit(): void {
    let observable = this.service.getAllContacts();
    observable.subscribe((data : Contact[]) =>{
      this.contactList = data;
    })
  }   

}




