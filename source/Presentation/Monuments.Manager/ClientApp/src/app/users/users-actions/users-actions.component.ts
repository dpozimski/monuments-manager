import { Component, OnInit } from '@angular/core';
import { DialogService } from 'ng2-bootstrap-modal';
import { PromoteUserDialogComponent } from '../../promote-user-dialog/promote-user-dialog.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-users-actions',
  templateUrl: './users-actions.component.html',
  styleUrls: ['./users-actions.component.css']
})
export class UsersActionsComponent implements OnInit {

  constructor(private dialogService: DialogService,
              private router: Router) { }

  ngOnInit() {
  }

  showPromoteDialog() {
    this.dialogService.addDialog(PromoteUserDialogComponent).subscribe();
  }

  refreshPage() {
    this.router.navigate(['/users']);
  }
}
