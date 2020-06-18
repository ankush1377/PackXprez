import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-track-package',
  templateUrl: './track-package.component.html',
  styleUrls: ['./track-package.component.css']
})
export class TrackPackageComponent implements OnInit {

  constructor() { }
  submitForm(form: NgForm) {
    console.log(form.value.awbNumber);
  }
  ngOnInit() {
  }

}
