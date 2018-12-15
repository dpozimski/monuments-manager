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
  selectedMonument: MonumentDto;

  constructor(private monumentsService: MonumentsService,
              private monumentsClient: MonumentsClient,
              private toastr: ToastrService) { }

  ngOnInit() {
    this.monumentsService.selectedMonumentPreviewChanged
        .subscribe(selected => {
          if(selected == null) {
            this.selectedMonument = null;
          } else {
            this.monumentsClient.get(selected.id)
                .subscribe(result => this.selectedMonument = result,
                       _ => this.toastr.error('Cannot retrieve detail of monument ' + s.name));
          }
        })
  }
}
