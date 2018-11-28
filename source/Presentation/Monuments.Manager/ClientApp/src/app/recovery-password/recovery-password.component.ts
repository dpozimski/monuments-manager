import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ChangePasswordByRecoveryKeyCommand, RecoveryClient } from '../api/monuments-manager-api';
import { AuthenticationService } from '../api/authentication.service';
import { ChangePasswordByRecoveryKeyFactory } from '../api/security/changepasswordbyrecoverykeycommand.factory';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-recovery-password',
  templateUrl: './recovery-password.component.html',
  styleUrls: [
    './recovery-password.component.css',
    './../styles/forms.css'
  ]
})
export class RecoveryPasswordComponent implements OnInit {
  private readonly toastTitle = 'Recovery password';

  submitted: boolean;
  severRejectedCommand: boolean;

  model: ChangePasswordByRecoveryKeyCommand = new ChangePasswordByRecoveryKeyCommand();

  constructor(private route: ActivatedRoute,
              private router: Router,
              private recoveryClient: RecoveryClient,
              private authenticationService: AuthenticationService,
              private changePasswordByRecoveryKeyFactory: ChangePasswordByRecoveryKeyFactory,
              private toastr: ToastrService) { }

  ngOnInit() {
    this.authenticationService.logout();
    this.route.queryParams
      .subscribe(params => {
        this.model.recoveryKey = params["recoveryKey"];

        if(!this.model.recoveryKey) {
          this.router.navigate(['/home']);
        }
      });
  }

  resetPassword() {
    this.submitted = false;
    this.severRejectedCommand = false;

    var command = this.changePasswordByRecoveryKeyFactory.create(this.model.recoveryKey, this.model.password);
    this.recoveryClient.changePasswordByRecoveryKey(command)
      .subscribe(_ => this.handleSuccessResult(),
                 _ => this.handleFailResult());
  }

  private handleFailResult() {
    this.submitted = false;
    this.severRejectedCommand = true;
    this.toastr.error('Password has not been resetted', this.toastTitle);
  }

  private handleSuccessResult() {
    this.router.navigate(['/login']);
    this.toastr.success('Password has been resetted', this.toastTitle);
  }
}
