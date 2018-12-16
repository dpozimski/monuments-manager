import { Component, OnInit, AfterViewInit, Input } from '@angular/core';
import { MonumentsService } from '../services/monuments.service';
import { MonumentsClient, MonumentPreviewDto, MonumentDto } from './../../../app/api/monuments-manager-api';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-monuments-list-detail',
  templateUrl: './monuments-list-detail.component.html',
  styleUrls: ['./monuments-list-detail.component.css']
})
export class MonumentsListDetailComponent implements AfterViewInit {
  @Input()
  monumentPreview: MonumentPreviewDto;
  monument: MonumentDto = new MonumentDto();
    

  constructor(private monumentsService: MonumentsService,
              private monumentsClient: MonumentsClient,
              private toastr: ToastrService) { }

  ngAfterViewInit() {
    this.monumentsService.selectedMonumentPreviewChanged
        .subscribe(selected => {
          if(this.monumentPreview == selected) {
            this.monumentsClient.get(selected.id)
                .subscribe(result => this.monument = result,
                           _ => this.toastr.error('Cannot retrieve detail of monument ' + selected.name));
          }
        })
  }
}
