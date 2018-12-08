import { Component, OnInit } from '@angular/core';
import { UserStatisticsResult, UsersClient, UserDto } from '../../api/monuments-manager-api';
import { UsersService } from '../users.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {
  userStatistics: UserStatisticsResult;

  constructor(private usersService: UsersService,
              private usersClient: UsersClient,
              private toastr: ToastrService) {
  }

  ngOnInit() {
    this.usersService.userStatsContextChanged
        .subscribe({
          next: (user: UserDto) => {
              var userId = user.id;
              this.usersClient.getUserStatistics(userId)
                  .subscribe(s => this.userStatistics = s,
                             _ => this.toastr.error('Cannot get user statistics'));
          }
      })
  }
}
