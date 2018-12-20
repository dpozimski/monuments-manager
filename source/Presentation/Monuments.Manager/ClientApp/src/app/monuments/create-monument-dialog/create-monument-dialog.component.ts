import { Component, OnInit } from '@angular/core';
import { DialogComponent, DialogService } from 'ng2-bootstrap-modal';
import { MonumentDto, MonumentsClient, CreateMonumentCommand, MonumentPreviewDto } from './../../api/monuments-manager-api';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create-monument-dialog',
  templateUrl: './create-monument-dialog.component.html',
  styleUrls: [
    './create-monument-dialog.component.css',
    './../../styles/forms.css'
  ]
})
export class CreateMonumentDialogComponent extends DialogComponent<CreateMonumentDialogComponent, MonumentPreviewDto> implements OnInit {
  readonly serverErrorMessage: 'Cannot add monument. Check your data';
  monument: MonumentDto;
  submitted: boolean;
  serverRejectedCommand: boolean;

  constructor(dialogService: DialogService,
              private toastr: ToastrService,
              private monumentsClient: MonumentsClient) {
    super(dialogService);
  }

  confirm() {
    this.submitted = true;
    this.serverRejectedCommand = false;

    var command = new CreateMonumentCommand();
    command.address = this.monument.address;
    command.constructionDate = this.monument.constructionDate;
    command.formOfProtection = this.monument.formOfProtection;
    command.name = this.monument.name;

    this.monumentsClient.create(command)
        .subscribe(x => {
          this.result = x;
          this.toastr.success('Monument has been added', 'Add monument');
          this.close();
        }, _ => {
          this.serverRejectedCommand = true;
          this.submitted = false;
          this.toastr.error(this.serverErrorMessage, 'Add monument');
        })
  }

  ngOnInit() {
    this.monument = new MonumentDto();
    this.monument.address = new MonumentDto();
  }
}
