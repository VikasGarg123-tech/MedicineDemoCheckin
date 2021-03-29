import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MedicineListComponent } from './medicine-list/medicine-list.component';
import { MedicineDetailComponent } from './medicine-detail/medicine-detail.component';
import { AddMedicineComponent } from './add-medicine/add-medicine.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
  { path: 'medicinelist', component: MedicineListComponent },
  { path: 'medicinedetail/:id', component: MedicineDetailComponent },
  { path: 'addmedicine', component: AddMedicineComponent },
  { path: '', component: MedicineListComponent },
  { path: '**', component: PageNotFoundComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
