import { Component, OnInit } from '@angular/core';
import { DialogService, DialogComponent } from 'ng2-bootstrap-modal';
import { CreatePictureDialogParameters } from './create-picture-dialog-parameters';
import { MonumentDto, PictureDto, PicturesClient } from './../../api/monuments-manager-api';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-create-picture-dialog',
  templateUrl: './create-picture-dialog.component.html',
  styleUrls: [
    './create-picture-dialog.component.css',
    './../../styles/forms.css'
  ]
})
export class CreatePictureDialogComponent extends DialogComponent<CreatePictureDialogComponent, PictureDto> implements CreatePictureDialogParameters {
  monument: MonumentDto;
  
  files: string[] = [];
  private filesSubject: BehaviorSubject<string[]> = new BehaviorSubject([]);

  constructor(dialogService: DialogService,
              private picturesClient: PicturesClient) {
    super(dialogService);
  }

  onFilePick(file: any) {
    console.log(file);
  }

  upload() {
    console.log(this.files);
  }
}
