import { Component, OnInit, Input } from '@angular/core';
import { MonumentPreviewDto } from './../../api/monuments-manager-api';
import { DialogService } from 'ng2-bootstrap-modal';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-recent-card',
  templateUrl: './recent-card.component.html',
  styleUrls: ['./recent-card.component.css']
})
export class RecentCardComponent implements OnInit {
  @Input()
  monument: MonumentPreviewDto;

  constructor(private dialogService: DialogService,
              private toastrService: ToastrService) { }

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

  }

  editDialog() {

  }
}
