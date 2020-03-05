import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';
import { Animal } from 'src/app/admin/animals/animals.component';

@Component({
  selector: 'app-breeds',
  templateUrl: './breeds.component.html'
})
export class BreedsComponent {
    public breeds: Breed[];
    public animals: Animal[];
    selectedIndex: number;
    http: HttpClient;
    baseUrl: string;
    extendedUrl: string;

    newAnimalForm = new FormGroup({
        name: new FormControl(''),
        description: new FormControl(''),
        animalId: new FormControl('')
    });

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.http = http;
      this.baseUrl = baseUrl;
      this.extendedUrl = 'api/Breeds';
      this.load();
    }

    delete(id: number) {
        this.http.delete(this.baseUrl + this.extendedUrl + "/" + id).subscribe(result => {
            this.load();
        },error => console.error(error));
    }

    load() {
        this.http.get<Breed[]>(this.baseUrl + this.extendedUrl).subscribe(result => {
            this.breeds = result;
            this.http.get<Animal[]>(this.baseUrl + "api/Animals").subscribe(result => {
                this.animals = result;
                this.loadAnimalNames();
            }, error => console.error(error));
        }, error => console.error(error));
    }

    loadAnimalNames() {
        for (var x = 0; x < this.breeds.length; x++) {
            for (var y = 0; y < this.animals.length; y++) {
                if (this.breeds[x].animalId == this.animals[y].id) {
                    this.breeds[x].animal = this.animals[y].name;
                    break;
                }
            }
        }
    }

    submit() {
        this.http.post(this.baseUrl + this.extendedUrl, this.newAnimalForm.value).subscribe(result => {
            this.load();
        }, error => console.error(error));
    }
}

export class Breed {
    public name: string;
    public description: number;
    public animal: string;
    public animalId: number;
    public id: number;
}
