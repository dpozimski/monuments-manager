import { Component, OnInit } from '@angular/core';
import { MonumentsService } from '../services/monuments.service';
import { MonumentDto, MonumentsClient } from './../../../app/api/monuments-manager-api';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-monuments-list-detail',
  templateUrl: './monuments-list-detail.component.html',
  styleUrls: ['./monuments-list-detail.component.css']
})
export class MonumentsListDetailComponent implements OnInit {
  constructor(private monumentsService: MonumentsService,
              private monumentsClient: MonumentsClient,
              private toastr: ToastrService) { }

  ngOnInit() {
    this.monumentsService.selectedMonumentPreviewChanged
        .subscribe(selected => {
          if(selected == null) {
            this.monumentsService.selectedMonumentChangedCommand(null);
          } else {
            this.monumentsClient.get(selected.id)
                .subscribe(result => this.monumentsService.selectedMonumentChangedCommand(result),
                       _ => this.toastr.error('Cannot retrieve detail of monument ' + selected.name));
          }
        })
  }
}
