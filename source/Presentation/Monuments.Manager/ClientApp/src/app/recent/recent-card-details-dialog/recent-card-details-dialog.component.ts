import { Component, OnInit } from '@angular/core';
import { DialogService, DialogComponent } from 'ng2-bootstrap-modal';
import { RecentCardDetailsDialogParameters } from './recent-card-details-dialog-parameters';
import { MonumentPreviewDto, MonumentsClient, MonumentDto, AddressDto } from './../../api/monuments-manager-api';

@Component({
  selector: 'app-recent-card-details-dialog',
  templateUrl: './recent-card-details-dialog.component.html',
  styleUrls: [
    './recent-card-details-dialog.component.css',
    './../../styles/forms.css'
  ]
})
export class RecentCardDetailsDialogComponent extends DialogComponent<RecentCardDetailsDialogParameters, boolean> implements RecentCardDetailsDialogParameters {
  monumentPreview: MonumentPreviewDto;
  monument: MonumentDto;
  dataReceived: boolean;

  constructor(dialogService: DialogService,
              private monumentsClient: MonumentsClient) { 
    super(dialogService);
  }

  ngOnInit() {
    this.monument = new MonumentDto();
    this.monument.address = new AddressDto();

    this.monumentsClient.get(this.monumentPreview.id)
        .subscribe(x => {
          this.monument = x;
          this.dataReceived = true;
        });
  }
}
