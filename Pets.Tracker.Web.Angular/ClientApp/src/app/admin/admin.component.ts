import { Component } from '@angular/core';

@Component({
  selector: 'app-admin-component',
  templateUrl: './admin.component.html'
})
export class AdminComponent {
    public DatabaseComponents =
        [
            {
                TableName: "Animals",
                URL: "Animals"
            },
            {
                TableName: "Breeds",
                URL: "Breeds"
            }
        ];

    selectedIndex = 0;
}
