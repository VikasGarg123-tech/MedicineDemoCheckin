import { Component, OnInit } from '@angular/core';
import { Medicine } from '../model/medicine';
import { MedicineService } from '../shared/services/medicine-service.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-medicine-list',
  templateUrl: './medicine-list.component.html',
  styleUrls: ['./medicine-list.component.css']
})
export class MedicineListComponent implements OnInit {
  public medicineList: Medicine[];
  public filterByName: string = '';
  public httpSub: any;
  constructor(private medicineService: MedicineService, private router: Router) { }

  ngOnInit(): void {

    this.medicineService.get('Medicine/GetMedicineList')
      .subscribe(
        retValue => {
          this.medicineList = retValue as Medicine[];
        },
        error => {
          console.log(error);
        }

      );
  }

  ngOnDestroy() {
    if (this.httpSub != null) {
      this.httpSub.unsubscribe();
    }
  }

  OnAddMedicineClick() {
    this.router.navigate(['/addmedicine']);
  }

  OnRowSelected(medicine) {
    this.router.navigate(['/medicinedetail', medicine.id]);
  }
}
