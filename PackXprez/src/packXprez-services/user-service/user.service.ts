import { Injectable } from '@angular/core';
import { IUser } from '../../app/packXprez-interfaces/user';
import { ICustomer } from '../../app/packXprez-interfaces/customer';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  users: IUser[];
  constructor(private http: HttpClient) { }

  getUsers(): Observable<IUser[]> {
    console.log("Testing method");
    let tempVar = this.http.get<IUser[]>('https://localhost:44331/api/Admin/GetAllUsers').pipe(catchError(this.errorHandler));
    return tempVar;
  }

  validateLogin(id: string, password: string): Observable<boolean> {
    var userObj: ICustomer;
    userObj = { EmailId: id, UserPassword: password };
    return this.http.post<boolean>('https://localhost:44331/api/admin/ValidateLogin', userObj).pipe(catchError(this.errorHandler));
  }


  errorHandler(error: HttpErrorResponse) {
    console.error(error);
    return throwError(error.message || "Server Error");
  } 
}
