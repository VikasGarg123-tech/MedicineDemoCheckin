import { Component, OnInit } from '@angular/core';
import { Medicine } from '../model/medicine';
import { MedicineService } from '../shared/services/medicine-service.service';
import { Router, ActivatedRoute } from '@angular/router';
import { FormGroup, FormBuilder } from '@angular/forms';
import { Location } from '@angular/common';

@Component({
  selector: 'app-medicine-detail',
  templateUrl: './medicine-detail.component.html',
  styleUrls: ['./medicine-detail.component.css']
})
export class MedicineDetailComponent implements OnInit {
  public httpSub: any;
  public id: number;
  public notes: string;
  public medicineModel: any;
  public detailMedForm: FormGroup;
  public editNotes: boolean = false;
  constructor(private medicineService: MedicineService,
    private formBuilder: FormBuilder,
    private router: Router,
    private route: ActivatedRoute,
    private location: Location) { }

  ngOnInit(): void {
    this.id = this.route.snapshot.params['id'];

    this.detailMedForm = this.formBuilder.group({
      mname: [''],
      brand: [''],
      expiryDate: [''],
      price: [''],
      quantity: [''],
      notes: ['']
    });

    this.httpSub = this.medicineService.get('Medicine/GetMedicineDetails?id=' + this.id)
      .subscribe(
        retValue => {
          this.detailMedForm.controls['mname'].setValue(retValue.name);
          this.detailMedForm.controls['brand'].setValue(retValue.brand);
          this.detailMedForm.controls['expiryDate'].setValue(retValue.expiryDate);
          this.detailMedForm.controls['price'].setValue(retValue.price);
          this.detailMedForm.controls['quantity'].setValue(retValue.quantity);
          this.detailMedForm.controls['notes'].setValue(retValue.notes);
          this.medicineModel = retValue;
          this.notes = retValue.notes;
        },
        error => {
          console.log(error);
        }
      );
  }

  OnEditNotes() {
    this.editNotes = true;
  }

  OnBack() {
    this.location.back();
  }

  ngOnDestroy() {
    if (this.httpSub != null) {
      this.httpSub.unsubscribe();
    }
  }

  onNotesSave(eventData) {
    this.detailMedForm.controls['notes'].setValue(eventData);
    this.medicineModel.notes = eventData;
    this.httpSub = this.medicineService.put('Medicine/UpdateMedicine', this.medicineModel)
      .subscribe(
        retValue => {
          console.log(retValue);
        },
        error => {
          console.log(error);
        }
      );
    this.editNotes = false;
  }

  onNotesClose() {
    this.editNotes = false;
  }

}
