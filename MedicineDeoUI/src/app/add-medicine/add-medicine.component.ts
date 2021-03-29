import { Component, OnInit } from '@angular/core';
import { Medicine } from '../model/medicine';
import { MedicineService } from '../shared/services/medicine-service.service';
import { Router } from '@angular/router';
import { FormGroup, FormBuilder, FormControl, Validators } from '@angular/forms';
import { Location } from '@angular/common'

@Component({
  selector: 'app-add-medicine',
  templateUrl: './add-medicine.component.html',
  styleUrls: ['./add-medicine.component.css']
})
export class AddMedicineComponent implements OnInit {
  public httpSub: any;
  public medicineModel: Medicine;
  public addMedForm: FormGroup;
  constructor(private formBuilder: FormBuilder,
    private medicineService: MedicineService,
    private router: Router,
    private location: Location) {
    this.medicineModel = new Medicine();
  }

  ngOnInit(): void {

    this.addMedForm = this.formBuilder.group({
      mname: [''],
      brand: [''],
      expiryDate: [''],
      price: [''],
      quantity: [''],
      notes: ['']
    });
  }


  ngOnDestroy() {
    if (this.httpSub != null) {
      this.httpSub.unsubscribe();
    }
  }

  saveMedicine() {
    this.medicineModel.Name = this.addMedForm.controls['mname'].value;
    this.medicineModel.Brand = this.addMedForm.controls['brand'].value;
    this.medicineModel.ExpiryDate = this.addMedForm.controls['expiryDate'].value;
    this.medicineModel.Price = +this.addMedForm.controls['price'].value;
    this.medicineModel.Quantity = +this.addMedForm.controls['quantity'].value;
    this.medicineModel.Notes = this.addMedForm.controls['notes'].value;

    this.httpSub = this.medicineService.post('Medicine/AddMedicine', this.medicineModel)
      .subscribe(
        retValue => {
          console.log(retValue);
          this.location.back();
        },
        error => {
          console.log(error);
        }
      );
  }

  OnBack() {
    this.location.back();
  }

  expireValidator(control: FormControl): { [s: string]: boolean } {
    let enteredDate = control.value;
    let currentDate = new Date();
    let diff = Math.floor((Date.UTC(currentDate.getFullYear(), currentDate.getMonth(), currentDate.getDate()) - Date.UTC(enteredDate.getFullYear(), enteredDate.getMonth(), enteredDate.getDate())) / (1000 * 60 * 60 * 24));
    return null;
  }

}
