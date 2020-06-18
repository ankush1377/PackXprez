import { Component, OnInit } from '@angular/core';
import { IUser } from '../packXprez-interfaces/user';
import { UserService } from '../../packXprez-services/user-service/user.service';

@Component({
  selector: 'app-view-users',
  templateUrl: './view-users.component.html',
  styleUrls: ['./view-users.component.css']
})
export class ViewUsersComponent implements OnInit {

  users: IUser[];
  showMsgDiv: boolean = false;
  errMsg: string;
  constructor(private _userService: UserService) { }

  ngOnInit() {
    this.getUsers();
    if (this.users == null) { 
      this.showMsgDiv = true;
    }
  }

  getUsers() {
    this._userService.getUsers().subscribe(
      responseUserData => {
        this.users = responseUserData;
        this.showMsgDiv = false;
      },
      responseUserError => {
        this.users = null;
        this.errMsg = responseUserError;
        console.log(this.errMsg);
      },
      () => console.log("GetUsers method excuted successfully")
    );
  }

}
