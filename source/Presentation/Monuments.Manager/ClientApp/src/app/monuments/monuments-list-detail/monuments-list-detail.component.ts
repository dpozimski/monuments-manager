import { Component, OnInit, AfterViewInit, Input } from '@angular/core';
import { MonumentsService } from '../services/monuments.service';
import { MonumentsClient, MonumentPreviewDto } from './../../../app/api/monuments-manager-api';
import { ToastrService } from 'ngx-toastr';
import { throttleTime, debounceTime } from 'rxjs/operators';

@Component({
  selector: 'app-monuments-list-detail',
  templateUrl: './monuments-list-detail.component.html',
  styleUrls: ['./monuments-list-detail.component.css']
})
export class MonumentsListDetailComponent implements AfterViewInit {
  @Input()
  model: MonumentPreviewDto;

  constructor(private monumentsService: MonumentsService,
              private monumentsClient: MonumentsClient,
              private toastr: ToastrService) { }

  ngAfterViewInit() {
    this.monumentsService.selectedMonumentPreviewChanged
        .subscribe(selected => {
          if(selected == null) {
            this.monumentsService.selectedMonumentChangedCommand(null);
          } else if(this.model == selected) {
            this.monumentsClient.get(selected.id)
                .subscribe(result => this.monumentsService.selectedMonumentChangedCommand(result),
                           _ => this.toastr.error('Cannot retrieve detail of monument ' + selected.name));
          }
        })
  }
}
