import { Component } from '@angular/core';

@Component({
  selector: 'app-second',
  standalone: false,
  template: '<p style="font-style: italic;">All Rights Reserved, Powered by Angular 18-{{year}}</p>',
  // templateUrl not required instead template only.
})
export class Second {
    year : number = new Date().getFullYear()
}




