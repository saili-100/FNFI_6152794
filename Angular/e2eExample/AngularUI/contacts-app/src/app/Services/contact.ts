import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root' 
})
export class Contact {
  url:string ="http://localhost:3000/contacts"
  constructor(private httpClient:HttpClient)
  {

  }

  public getAllContacts():Observable<Contact[]>{
    return this.httpClient.get<Contact[]>(this.url);
  }
  
  public getContact(id : string) : Observable<Contact>{
    const temp : string = `${this.url}/${id}` 
    return this.httpClient.get<Contact>(temp)
  }
  
  public addContact(contact: Contact): Observable<Contact> {
    return this.httpClient.post(this.url, contact) as Observable<Contact>;
  }

  public updateContact(contact:any): Observable<any> {
    const temp: string = `${this.url}/${contact.id}`;
    return this.httpClient.put(temp, contact);
  }

  public deleteContact(id: string): Observable<Contact> {
    const temp: string = `${this.url}/${id}`;
    return this.httpClient.delete(temp) as Observable<Contact>;
  }
}























//constructor is used to inject dependency for connecting with api.
