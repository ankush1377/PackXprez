import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-check-service-availability',
  templateUrl: './check-service-availability.component.html',
  styleUrls: ['./check-service-availability.component.css']
})
export class CheckServiceAvailabilityComponent implements OnInit {

  constructor() { }
  submitCheckServiceForm(form: NgForm) {
    console.log(form.value.fromPincode);
    console.log(form.value.toPincode);
  }

  ngOnInit() {
  }

}
