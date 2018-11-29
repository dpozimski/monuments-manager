import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../api/authentication.service';
import { ToastrService } from 'ngx-toastr';
import { CreateUserCommand } from '../api/monuments-manager-api';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: [
    './register.component.css',
    './../styles/forms.css'
  ]
})
export class RegisterComponent {
  cannotCreateAccount: boolean;
  errorMessage: string;
  submitted: boolean;

  model: CreateUserCommand = new CreateUserCommand();

  constructor(private authenticationService: AuthenticationService,
              private toastr: ToastrService) { }

  register() {
    this.submitted = true;
  }
}
