import { HttpClient } from '@angular/common/http';
import { Component, Inject, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Pet } from 'src/app/pets/pet';

@Component({
    selector: 'app-pet',
    templateUrl: './pet.component.html',
})

export class PetComponent {
    pet: Pet;
    http: HttpClient;
    baseUrl: string;
    @Input() petId: number; 
    extendedUrl: string;

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private route: ActivatedRoute) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.extendedUrl = "api/Pets";
    }

    load() {
        this.http.get<Pet>(this.baseUrl + this.extendedUrl + "/" + this.petId).subscribe(result => {
            this.pet = result;
        }, error => console.error(error));
    }

    ngOnInit() {
        this.route.paramMap.subscribe(params => {
            this.petId = parseInt(params.get('petId'));
            this.load();
        });
    }
}
