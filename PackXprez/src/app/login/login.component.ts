import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from '../../packXprez-services/user-service/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  status: boolean=false;
  errorMsg: string;
  msg: string;
  showDiv: boolean = false;

  constructor(private _userService: UserService) { }
  submitLoginForm(form: NgForm) {
    this._userService.validateLogin(form.value.email, form.value.password).subscribe(
      responseLoginStatus => {
        this.status = responseLoginStatus;
        this.showDiv = true;
        if (this.status) {
          this.msg = "Login Successful";
        }
        else {
          this.msg = "Invalid Credentials! Please try again.";
        }
      },
      responseLoginError => {
        this.errorMsg = responseLoginError;
      },
      () => console.log("SubmitLoginForm method executed successfully")
    );
  }
  ngOnInit() {
  }
}
