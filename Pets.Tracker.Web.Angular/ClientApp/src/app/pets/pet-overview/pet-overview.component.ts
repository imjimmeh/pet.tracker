import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Animal } from '../../admin/animals/animals.component';
import { Breed } from '../../admin/breeds/breeds.component';
import { Pet } from 'src/app/pets/pet';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-pet-overview',
  templateUrl: './pet-overview.component.html',
})
export class PetOverviewComponent {
    pets: Pet[];
    animals: Animal[];
    breeds: Breed[];
    http: HttpClient;
    baseUrl: string;
    extendedUrl: string;
    closeResult: string;

    genders = [{ id: 0, value: "Male" }, { id: 1, value: "Female" }, { id: 2, value: "Other" }, { id: 3, value: "Unspecified" }];

    newPetForm = new FormGroup({
        name: new FormControl(''),
        dateOfBirth: new FormControl(''),
        gender: new FormControl(''),
        animalId: new FormControl(''),
        breedId: new FormControl('')
    });

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, private modalService: NgbModal) {
        this.http = http;
        this.baseUrl = baseUrl;
        this.extendedUrl = 'api/Pets';
        this.load();
    }

    load() {
        this.http.get<Pet[]>(this.baseUrl + this.extendedUrl).subscribe(result => {
            this.pets = result;
            this.http.get<Animal[]>(this.baseUrl + "api/Animals").subscribe(result => {
                this.animals = result;
                this.loadAnimalNames();
            }, error => console.error(error));
        }, error => console.error(error));
    }

    loadAnimalNames() {
        for (var x = 0; x < this.animals.length; x++) {
            for (var y = 0; y < this.pets.length; y++) {
                if (this.animals[x].id == this.pets[y].animalId)
                    this.pets[y].animal = this.animals[x].name;
            }
        }
    }

    loadBreeds() {
        this.breeds = [];
        this.http.get<Breed[]>(this.baseUrl + "api/Breeds/Animal/" + this.newPetForm.value["animalId"]).subscribe(result => {
            this.breeds = result;
        }, error => console.error(error));
    }

    open(content) {
        this.modalService.open(content, { ariaLabelledBy: 'modal-basic-title' });
    }

    submit() {
        this.http.post(this.baseUrl + this.extendedUrl, this.newPetForm.value).subscribe(result => {
            this.load();
        }, error => console.error(error));
    }
}
