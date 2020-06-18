import { Injectable } from '@angular/core';
import { Ishipment } from '../../app/packXprez-interfaces/shipment';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ShipmentService {
  shipments: Ishipment[];
  constructor(private http: HttpClient) { }

  getShipments(): Observable<Ishipment[]> {
    let tempVar = this.http.get<Ishipment[]>('https://localhost:44331/api/Admin/OrderHistory').pipe(catchError(this.errorHandler));;
    return tempVar;
  }

  errorHandler(error: HttpErrorResponse) {
    console.error(error);
    return throwError(error.message || "Server Error");
  } 
}
