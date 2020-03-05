import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { PetOverviewComponent } from '../pet-overview/pet-overview.component';
@NgModule({
  imports: [BrowserModule, NgbModule],
    declarations: [PetOverviewComponent],
    exports: [PetOverviewComponent],
    bootstrap: [PetOverviewComponent]
})
export class PetOverviewComponentModule {}
