import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MedicineListComponent } from './medicine-list/medicine-list.component';
import { MedicineDetailComponent } from './medicine-detail/medicine-detail.component';
import { AddMedicineComponent } from './add-medicine/add-medicine.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { MedicineService } from './shared/services/medicine-service.service'
import { HttpClientModule } from '@angular/common/http';
import { FilterPipe } from './shared/pipes/filter-pipe.pipe';
import { ExpireMedicineValidatorDirective } from './shared/directives/expire-medicine-validator.directive';
import { EditNotesComponent } from './edit-notes/edit-notes.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  declarations: [
    AppComponent,
    MedicineListComponent,
    MedicineDetailComponent,
    AddMedicineComponent,
    PageNotFoundComponent,
    FilterPipe,
    ExpireMedicineValidatorDirective,
    EditNotesComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    NgbModule
  ],
  providers: [MedicineService],
  bootstrap: [AppComponent]
})
export class AppModule { }
