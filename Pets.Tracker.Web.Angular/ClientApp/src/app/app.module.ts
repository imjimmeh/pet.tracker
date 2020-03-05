import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { AdminComponent } from './admin/admin.component';
import { AnimalsComponent } from './admin/animals/animals.component';
import { BreedsComponent } from './admin/breeds/breeds.component';
import { PetOverviewComponent } from './pets/pet-overview/pet-overview.component';
import { PetOverviewComponentModule } from './pets/pet-overview/pet-overview.component.module';
import { PetComponent } from './pets/pet/pet.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        AdminComponent,
        AnimalsComponent,
        BreedsComponent,
        PetOverviewComponent,
        PetComponent
    ],
    imports: [
        BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
        HttpClientModule,
        FormsModule,
        NgbModule,
        ApiAuthorizationModule,
        RouterModule.forRoot([
            { path: '', component: HomeComponent, pathMatch: 'full' },
            { path: 'admin', component: AdminComponent },
            { path: 'pets', component: PetOverviewComponent },
            { path: 'pets/pet/:petId', component: PetComponent }
        ]),
        ReactiveFormsModule
    ],
    providers: [
        { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true }
    ],
    bootstrap: [AppComponent]
})
export class AppModule { }
