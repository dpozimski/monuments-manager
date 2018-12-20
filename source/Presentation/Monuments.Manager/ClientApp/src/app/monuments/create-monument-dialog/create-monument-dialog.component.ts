import { Component, OnInit, ViewChild } from '@angular/core';
import { DialogComponent, DialogService } from 'ng2-bootstrap-modal';
import { MonumentDto, MonumentsClient, CreateMonumentCommand, MonumentPreviewDto } from './../../api/monuments-manager-api';
import { ToastrService } from 'ngx-toastr';
import { MonumentsDetailFormComponent } from '../monuments-detail-form/monuments-detail-form.component';

@Component({
  selector: 'app-create-monument-dialog',
  templateUrl: './create-monument-dialog.component.html',
  styleUrls: [
    './create-monument-dialog.component.css',
    './../../styles/forms.css'
  ]
})
export class CreateMonumentDialogComponent extends DialogComponent<CreateMonumentDialogComponent, MonumentPreviewDto> {
  readonly serverErrorMessage: string = 'Cannot add monument. Check your data';
  submitted: boolean;
  serverRejectedCommand: boolean;

  @ViewChild('detailForm') 
  detailForm: MonumentsDetailFormComponent;

  constructor(dialogService: DialogService,
              private toastr: ToastrService,
              private monumentsClient: MonumentsClient) {
    super(dialogService);
  }

  confirm() {
    this.submitted = true;
    this.serverRejectedCommand = false;

    var command = new CreateMonumentCommand();
    command.address = this.detailForm.monument.address;
    command.constructionDate = this.detailForm.monument.constructionDate;
    command.formOfProtection = this.detailForm.monument.formOfProtection;
    command.name = this.detailForm.monument.name;

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
}
