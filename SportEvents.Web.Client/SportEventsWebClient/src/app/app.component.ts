import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  preview: string = 'Preview';
  edit: string = 'Edit';
  buttonText: string;

  ngOnInit() {
    this.buttonText = this.edit;
  }

  changeEventMode() {
    if (this.buttonText == this.preview) {

      this.buttonText = this.edit
    } else {
      this.buttonText = this.preview;
    }
  }
}
