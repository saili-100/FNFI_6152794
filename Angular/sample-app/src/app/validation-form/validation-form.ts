import { Component, OnInit } from '@angular/core';
import { Employee } from '../Models/employee';

@Component({
  selector: 'app-validation-form',
  standalone: false,
  templateUrl:'./validation-form.html',
  styleUrl: './validation-form.css'
})
export class ValidationForm implements OnInit {
  ngOnInit(): void {
    this.employee={empId:0,empName:"",empAddress:"",empSalary:1000,empImg:"pic5.png"}
  }
  employee:Employee={} as Employee; //data is to be validated
  // called when the User submits the form
  onSubmit(empForm:any){
    console.log("Form Submitted");
    console.log(empForm.value);

}
}
