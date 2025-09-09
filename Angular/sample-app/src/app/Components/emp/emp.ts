import { Component } from '@angular/core';

@Component({
  selector: 'app-emp',
  standalone: false,
  templateUrl: './emp.html',
  styleUrl: './emp.css'
})
export class Emp {
   empName : string ="Saili"
    empAddress : string ="Bangalore"
    empSalary : number = 45000;

    onClick(){
      alert("The User has clicked")
    }

}
