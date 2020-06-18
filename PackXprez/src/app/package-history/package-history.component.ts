import { Component, OnInit } from '@angular/core';
import { Ishipment } from '../packXprez-interfaces/shipment';
import { ShipmentService } from '../../packXprez-services/shipment-service/shipment.service';


@Component({
  selector: 'app-package-history',
  templateUrl: './package-history.component.html',
  styleUrls: ['./package-history.component.css']
})
export class PackageHistoryComponent implements OnInit {

  shipment: Ishipment[];
  showMsgDiv: boolean = false;
  errMsg: string;
  constructor(private _shipmentService: ShipmentService) { }

  ngOnInit() {
    this.getShipments();
    if (this.shipment == null) {
      console.log(this.shipment);
      this.showMsgDiv = true;
    }
  }

  getShipments() {
    this._shipmentService.getShipments().subscribe(
      responseUserData => {
        this.shipment = responseUserData;
        this.showMsgDiv = false;
      },
      responseUserError => {
        this.shipment = null;
        this.errMsg = responseUserError;
        console.log(this.errMsg);
      },
      () => console.log("GetShipments method excuted successfully")
    );
  }

}
