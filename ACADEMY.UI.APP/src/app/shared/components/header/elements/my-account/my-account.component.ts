import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppService } from 'src/app/app.service';
import { HomeService } from '../../../../../pages/home/home.service';

@Component({
  selector: 'app-my-account',
  templateUrl: './my-account.component.html',
  styleUrls: ['./my-account.component.scss'],
})
export class MyAccountComponent implements OnInit {
  public userName: string;
  public profileImg: 'assets/images/dashboard/profile.jpg';

  constructor(
    private appService: AppService,
  ) // private sharedService: SharedService
  {
    if (JSON.parse(localStorage.getItem('user'))) {
    } else {
    }
  }

  ngOnInit() {}

  logoutFunc() {
    this.appService.logout();
  }
}
