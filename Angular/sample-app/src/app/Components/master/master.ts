import { Component, OnInit } from '@angular/core';
import { Employee } from '../../Models/employee';

@Component({
  selector: 'app-master',
  standalone: false,
  templateUrl: './master.html',
  styleUrl: './master.css'
})
export class Master implements OnInit {
  ngOnInit(): void {
    this.empList.push ({empId:10,empName:"Saili",empAddress:"Banglore",empSalary:50000,empImg:"pic1.png"});
    this.empList.push ({empId:11,empName:"Anuja",empAddress:"Delhi",empSalary:40000,empImg:"pic2.png"});
    this.empList.push ({empId:12,empName:"Raj",empAddress:"Mumbai",empSalary:30000,empImg:"pic3.png"});
    this.empList.push ({empId:13,empName:"Jay",empAddress:"Pune",empSalary:20000,empImg:"pic4.png"});
    this.empList.push ({empId:14,empName:"John",empAddress:"Hyderabad",empSalary:50000,empImg:"pic5.png"});
    this.empList.push ({empId:15,empName:"Bob",empAddress:"Pune",empSalary:10000,empImg:"pic6.png"});
    this.empList.push ({empId:16,empName:"Pooja",empAddress:"Nashik",empSalary:50000,empImg:"pic7.png"});

  }
  empList:Employee[]=[]; //created an array of Employee.
  //  selectedEmp: Employee = {} as Employee;
   foundEmp: Employee | null  = null;

   onEdit(rec:Employee){
    this.foundEmp = rec;
  }

  onSaved(rec : Employee){
      debugger;
      var index = this.empList.findIndex(r =>r.empId == rec.empId);
      if(index < 0){
        alert("No record found to update");
        return;
      }
      this.empList.splice(index, 1, rec);
      alert("Employee updated to the Master");
    }


}




    
