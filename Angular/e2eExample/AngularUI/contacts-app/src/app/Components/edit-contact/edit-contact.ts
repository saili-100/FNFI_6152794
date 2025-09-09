import { Component, OnInit } from '@angular/core';
import { Contact } from '../../Services/contact';
import { contact } from '../../Models/contact';
import { ActivatedRoute,ParamMap,Router } from '@angular/router';


@Component({
  selector: 'app-edit-contact',
  standalone: false,
  templateUrl: './edit-contact.html',
  styleUrl: './edit-contact.css'
})
export class EditContact implements OnInit {
  id:any;
  foundContact:any = {};
  constructor(private service:Contact,private activatedRoute:ActivatedRoute,private nav:Router) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe((params : ParamMap) =>{
      this.id = params.get("id"); //params is a dictionary of all the query strings u pass.
      this.service.getContact(this.id).subscribe((data) => {
        this.foundContact = data;
      });
    })
  }
  
  onUpdate(){ //Called when user clicks update.
    this.service.updateContact(this.foundContact);
    this.nav.navigate(['/contacts/viewall']); //To go back to the list of contacts.
  }

}






