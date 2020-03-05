import { Component, Inject, Input, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup, FormControl } from '@angular/forms';
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

  genders = [{ id: 0, value: "Male" }, { id: 1, value: "Female" }, { id: 2, value: "Other" }, { id: 3, value: "Unspecified" }];

  newPetForm = new FormGroup({
    name: new FormControl(''),
    dateOfBirth: new FormControl(''),
    nickname: new FormControl(''),
    gender: new FormControl(''),
    animalId: new FormControl(''),
    breedId: new FormControl('')
  });

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
