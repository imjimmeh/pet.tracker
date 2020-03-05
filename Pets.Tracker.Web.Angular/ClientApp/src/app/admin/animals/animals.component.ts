import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-animals',
  templateUrl: './animals.component.html'
})
export class AnimalsComponent {
    public animals: Animal[];
    http: HttpClient;
    baseUrl: string;
    extendedUrl: string;

    newAnimalForm = new FormGroup({
        name: new FormControl(''),
        description: new FormControl('')
    });

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
      this.http = http;
      this.baseUrl = baseUrl;
      this.extendedUrl = 'api/Animals';
      this.load();
    }

    delete(id: number) {
        this.http.delete(this.baseUrl + this.extendedUrl + "/" + id).subscribe(result => {
            this.load();
        },error => console.error(error));
    }

    load() {
        this.http.get<Animal[]>(this.baseUrl + this.extendedUrl).subscribe(result => {
            this.animals = result;
        }, error => console.error(error));
    }

    submit() {
        this.http.post(this.baseUrl + this.extendedUrl, this.newAnimalForm.value).subscribe(result => {
            this.load();
        }, error => console.error(error));
    }
}

export class Animal {
    public name: string;
    public description: number;
    public id: number;
}
