import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../api/authentication.service';
import { ToastrService } from 'ngx-toastr';
import { CreateUserCommand, UsersClient, UserRoleDto } from '../api/monuments-manager-api';
import { Router } from '@angular/router';
import { CryptoService } from '../api/security/crypto.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: [
    './register.component.css',
    './../styles/forms.css',
    './../styles/cards.css'
  ]
})
export class RegisterComponent {
  errorMessage: string;
  submitted: boolean;
  model: CreateUserCommand = new CreateUserCommand();

  constructor(private toastr: ToastrService,
              private router: Router,
              private usersClient: UsersClient,
              private cryptoService: CryptoService) { }

  register() {
    this.submitted = true;
    this.errorMessage = undefined;

    var command = new CreateUserCommand();
    command.password = this.cryptoService.encrypt(this.model.password);
    command.email = this.model.email;
    command.jobTitle = this.model.jobTitle;

    this.usersClient.create(command)
      .subscribe(_ => this.handleSuccessResult(),
                 _ => this.handleFailResult());
  }

  private handleFailResult() {
    this.submitted = false;
    this.errorMessage = 'Cannot create account. The e-mail can be invalid or currently in use.';

    this.toastr.error(this.errorMessage, 'Login');
  }

  private handleSuccessResult() {
    this.toastr.success('Account has been succesfully created!', 'Login');

    this.router.navigate(['/login']);
  }
}
