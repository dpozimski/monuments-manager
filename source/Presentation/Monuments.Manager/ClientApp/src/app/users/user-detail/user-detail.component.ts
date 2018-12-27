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
  userContext: UserDto = new UserDto();
  userStatistics: UserStatisticsResult = new UserStatisticsResult();

  constructor(private usersService: UsersService,
    private usersClient: UsersClient,
    private toastr: ToastrService) {
  }

  ngOnInit() {
    this.usersService.userStatsContextChanged
      .subscribe(user => {
        if(this.userContext.id === 0 || this.userContext.id === user.id) {
          return;
        }
        this.userContext = new UserDto();
        this.userStatistics = new UserStatisticsResult();
        this.usersClient.getUserStatistics(user.id)
          .subscribe(s => {
            this.userContext = user;
            this.userStatistics = s;
          }, _ => this.toastr.error('Cannot get user statistics'));
      });
}
}
