import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../api/authentication.service';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticateUserViewModel } from '../api/monuments-manager-api';
import { DialogService } from 'ng2-bootstrap-modal';
import { RecoveryPasswordDialogComponent } from '../recovery-password/recovery-password-dialog/recovery-password-dialog.component';
import { ToastrService } from 'ngx-toastr';
import { CryptoService } from '../api/security/crypto.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: [
    './login.component.css',
    './../styles/forms.css',
    './../styles/cards.css'
  ]
})
export class LoginComponent implements OnInit {
  private returnUrl: string;

  model: AuthenticateUserViewModel = new AuthenticateUserViewModel();

  errorMessage: string;
  submitted: boolean;

  constructor(private authenticationService: AuthenticationService,
              private cryptoService: CryptoService,
              private route: ActivatedRoute,
              private router: Router,
              private dialogService: DialogService,
              private toastr: ToastrService) {
  }

  ngOnInit() {
    this.route.queryParams
      .subscribe(params => {
        this.returnUrl = params["returnUrl"] || "/recent";
      });
  }

  login() {
    this.submitted = true;
    this.errorMessage = undefined;

    var viewModel = new AuthenticateUserViewModel();
    viewModel.password = this.cryptoService.encrypt(this.model.password);
    viewModel.email= this.model.email;

    this.authenticationService.login(viewModel)
      .subscribe(_ => this.handleSuccessResult(),
                 _ => this.handleFailResult());
  }

  recoveryPassword() {
    this.dialogService.addDialog(RecoveryPasswordDialogComponent).subscribe();
  }

  private handleFailResult() {
    this.submitted = false;
    this.errorMessage = 'Invalid email or password';

    this.toastr.error(this.errorMessage, 'Login');
  }

  private handleSuccessResult() {
    this.router.navigate([this.returnUrl]);
  }
}
