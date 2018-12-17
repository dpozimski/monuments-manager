import { Component, OnInit } from '@angular/core';
import { DialogService, DialogComponent } from 'ng2-bootstrap-modal';
import { CreatePictureDialogParameters } from './create-picture-dialog-parameters';
import { MonumentDto, PictureDto, PicturesClient, CreatePictureCommand } from './../../api/monuments-manager-api';
import { CreatePictureDialogItem } from './create-picture-dialog-item';
import { Observable, combineLatest, BehaviorSubject } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create-picture-dialog',
  templateUrl: './create-picture-dialog.component.html',
  styleUrls: [
    './create-picture-dialog.component.css',
    './../../styles/forms.css'
  ]
})
export class CreatePictureDialogComponent extends DialogComponent<CreatePictureDialogComponent, PictureDto[]> implements CreatePictureDialogParameters {
  monument: MonumentDto;
  submitted: boolean = false;
  files: CreatePictureDialogItem[] = [];

  constructor(dialogService: DialogService,
              private picturesClient: PicturesClient,
              private toastr: ToastrService) {
    super(dialogService);
  }

  onFilePick(files: any[]) {
    var tmp: any[] = [];
    tmp.push(files);
    tmp.forEach(s => {
      var item = new CreatePictureDialogItem();
      item.fileName = s.name;
      item.content = s.content;
      this.files.push(item);
    });
  }

  upload() {
    this.submitted = true;
    var observables: Observable<PictureDto>[] = this.files.map(s => {
      var command = new CreatePictureCommand();
      command.monumentId = this.monument.id;
      command.data = s.content;
      command.description = s.description;
      return this.picturesClient.create(command);
    });
    combineLatest(observables)
      .subscribe(s => {
        this.result = s;
        this.close();
      }, _ => {
        this.toastr.error('Critical error while adding pictures', 'Add pictutre');
        this.submitted = false;
      });
  }
}
