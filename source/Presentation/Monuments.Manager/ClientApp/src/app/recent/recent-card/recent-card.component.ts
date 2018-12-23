import { Component, OnInit, Input } from '@angular/core';
import { MonumentPreviewDto } from './../../api/monuments-manager-api';
import { DialogService } from 'ng2-bootstrap-modal';
import { RecentCardDetailsDialogComponent } from '../recent-card-details-dialog/recent-card-details-dialog.component';

@Component({
  selector: 'app-recent-card',
  templateUrl: './recent-card.component.html',
  styleUrls: ['./recent-card.component.css']
})
export class RecentCardComponent implements OnInit {
  @Input()
  monument: MonumentPreviewDto;

  constructor(private dialogService: DialogService) { }

  ngOnInit() {
  }

  getImageSource(): string {
    if (this.monument.picture) {
      return 'data:image/png;base64,' + this.monument.picture.small;
    } else {
      return './../../assets/no-photo-thumbnail.png';
    }
  }

  previewDialog() {
    this.dialogService.addDialog(
      RecentCardDetailsDialogComponent,
      { monumentPreview: this.monument })
      .subscribe();
  }
}
