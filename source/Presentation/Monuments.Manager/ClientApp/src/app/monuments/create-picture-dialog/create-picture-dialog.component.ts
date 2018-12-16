import { Component, OnInit } from '@angular/core';
import { DialogService, DialogComponent } from 'ng2-bootstrap-modal';
import { CreatePictureDialogParameters } from './create-picture-dialog-parameters';
import { MonumentDto, PictureDto } from 'src/app/api/monuments-manager-api';

@Component({
  selector: 'app-create-picture-dialog',
  templateUrl: './create-picture-dialog.component.html',
  styleUrls: ['./create-picture-dialog.component.css']
})
export class CreatePictureDialogComponent extends DialogComponent<CreatePictureDialogComponent, PictureDto> implements CreatePictureDialogParameters {
  monument: MonumentDto;

  constructor(dialogService: DialogService) {
    super(dialogService);
  }
}
