import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-reactive-form',
  standalone: false,
  templateUrl: './reactive-form.html',
  styleUrl: './reactive-form.css'
})
export default class ReactiveForm {
  employeeForm: FormGroup;
  submitted = false;

  constructor(private fb: FormBuilder) {
    this.employeeForm = this.fb.group({
      empId: ['', [Validators.required, Validators.min(101), Validators.max(1000)]],
      empName: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(30)]],
      empAddress: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(50)]],
      empSalary: ['', [Validators.required, Validators.min(1000), Validators.max(100000)]],
      empImg: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.employeeForm.valid) {
      this.submitted = true;
      console.log('Form Submitted:', this.employeeForm.value);
    } else {
      this.employeeForm.markAllAsTouched(); // Show all errors if form is invalid
    }
  }
    get empId(){
    return this.employeeForm.get('empId');      
  }
  get empName(){
    return this.employeeForm.get('empName');
  }
  get empAddress(){
    return this.employeeForm.get('empAddress');
  }
  get empSalary(){
    return this.employeeForm.get('empSalary');
  }
  get empImg(){
    return this.employeeForm.get('empImg');
  }

}
  



//   employeeForm: FormGroup;
//   submitted = false;

//   constructor(private fb: FormBuilder) {
//     this.employeeForm = this.fb.group({
//       empId: ['', [Validators.required, Validators.min(101), Validators.max(1000)]],
//       empName: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(30)]],
//       empAddress: ['', [Validators.required, Validators.minLength(5), Validators.maxLength(50)]],
//       empSalary: ['', [Validators.required, Validators.min(1000), Validators.max(100000)]],
//       empImg: ['', Validators.required]
//     });
//   }

//   onSubmit(): void {
//     if (this.employeeForm.valid) {
//       this.submitted = true;
//       console.log('Form Submitted:', this.employeeForm.value);
//     } else {
//       this.employeeForm.markAllAsTouched(); // Show all errors if form is invalid
//     }
//   }



// import { FormBuilder, FormGroup, Validators } from '@angular/forms';
