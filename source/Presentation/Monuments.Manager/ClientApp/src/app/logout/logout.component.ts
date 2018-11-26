import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from '../api/authentication.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent {

  constructor(private auhenticationService: AuthenticationService) { }
}
