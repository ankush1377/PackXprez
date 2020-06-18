import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-schedule-shipment',
  templateUrl: './schedule-shipment.component.html',
  styleUrls: ['./schedule-shipment.component.css']
})
export class ScheduleShipmentComponent implements OnInit {

  constructor() { }

  submitScheduleShipmentForm(form: NgForm) {
    console.log(form.value.fromPincode);
    console.log(form.value.toPincode);
    console.log(form.value.shipmentType);
    console.log(form.value.length);
    console.log(form.value.breadth);
    console.log(form.value.height);
    console.log(form.value.weight);
    console.log(form.value.deliveryType);
    console.log(form.value.pickUpTime);
    console.log(form.value.pickUpAddress);
    console.log(form.value.buildingNo);
    console.log(form.value.street);
    console.log(form.value.locality);
    console.log(form.value.pincode);
    console.log(form.value.contact);
    console.log(form.value.approxCost);
  
  }

  ngOnInit() {
  }

}
