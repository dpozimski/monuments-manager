import { Component, OnInit } from '@angular/core';
import { MonumentsService } from '../services/monuments.service';
import { DialogService } from 'ng2-bootstrap-modal';
import { CreateMonumentDialogComponent } from '../create-monument-dialog/create-monument-dialog.component';

@Component({
  selector: 'app-monuments-header',
  templateUrl: './monuments-header.component.html',
  styleUrls: [
    './monuments-header.component.css',
    './../../styles/forms.css',
    './../../styles/cards.css'
  ]
})
export class MonumentsHeaderComponent {
  private interval;

  filterPhrase: string;

  constructor(private monumentsService: MonumentsService,
              private dialogService: DialogService) { }

  createMonument() {
    this.dialogService.addDialog(CreateMonumentDialogComponent)
        .subscribe(x => {
          if(x) {
            
          }
        })
  }

  filterPhraseChanged() {
    clearInterval(this.interval);
    this.interval = setInterval(() => this.notifyFilterChanged(), 1000);
  }

  private notifyFilterChanged() {
    clearInterval(this.interval);
    var listFilterParameters = this.monumentsService.listFilterParameters;
    listFilterParameters.filter = this.filterPhrase;
    this.monumentsService.listFilterParametersChangedCommand();
  }
}
