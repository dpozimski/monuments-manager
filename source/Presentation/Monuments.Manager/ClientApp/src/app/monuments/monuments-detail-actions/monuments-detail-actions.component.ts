import { Component, OnInit, Input } from '@angular/core';
import { MonumentDto, MonumentsClient, UpdateMonumentCommand } from './../../api/monuments-manager-api';
import { DialogService } from 'ng2-bootstrap-modal';
import { MonumentsPreviewDataSource } from '../services/monuments-preview-datasource';
import { UserConfirmationDialogComponent } from './../../layout/user-confirmation-dialog/user-confirmation-dialog.component';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-monuments-detail-actions',
  templateUrl: './monuments-detail-actions.component.html',
  styleUrls: ['./monuments-detail-actions.component.css']
})
export class MonumentsDetailActionsComponent {
  @Input()
  monument: MonumentDto;

  constructor(private dialogService: DialogService,
              private monumentsClient: MonumentsClient,
              private monumentsDataSource: MonumentsPreviewDataSource,
              private toastr: ToastrService) { }

  updateMonument() {
    this.dialogService.addDialog(
          UserConfirmationDialogComponent,
          {title: 'Update monument', message: 'Do you want to save changes? Previous data will be replaced.'})
        .subscribe(x => {
          if(x) {
            var command = new UpdateMonumentCommand();
            command.monumentId = this.monument.id;
            command.name = this.monument.name;
            command.address = this.monument.address;
            command.formOfProtection = this.monument.formOfProtection;
            command.constructionDate = this.monument.constructionDate;
            this.monumentsClient.update(command)
                .subscribe(result => {
                  this.toastr.success('Monument has been updated', 'Update monument');
                  this.monumentsDataSource.updateMonument(result);
                }, _ => this.toastr.error('Monument has not been updated', 'Update monument'));
          }
        })
  }

  deleteMonument() {
    this.dialogService.addDialog(
      UserConfirmationDialogComponent,
      {title: 'Delete monument', message: 'Do you really want to delete monument?'})
    .subscribe(x => {
      if(x) {
        this.monumentsClient.delete(this.monument.id)
            .subscribe(_ => {
              this.toastr.success('Monument has been deleted', 'Delete monument');
              this.monumentsDataSource.deleteMonument(this.monument.id);
            }, _ => this.toastr.error('Monument has not been deleted', 'Delete monument'));
      }
    })
  }
}
