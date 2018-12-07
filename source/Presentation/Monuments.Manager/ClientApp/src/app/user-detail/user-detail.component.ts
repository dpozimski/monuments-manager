import { Component, OnInit } from '@angular/core';
import { UserStatisticsResult } from '../api/monuments-manager-api';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent {
  userStatistics: UserStatisticsResult;
}
