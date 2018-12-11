import { Component, OnInit } from '@angular/core';
import { MonumentsClient, MonumentDto } from './../../api/monuments-manager-api';
import { MonumentsService } from '../monuments.service';

@Component({
  selector: 'app-monuments-list',
  templateUrl: './monuments-list.component.html',
  styleUrls: [
    './monuments-list.component.css',
    './../../styles/tables.css'
  ]
})
export class MonumentsListComponent implements OnInit {
  displayedColumns: string[] = [
    'picture',
    'name', 
    'constructionDate',
    'ownerName',
    'modifiedDate',
    'modifiedBy',
  ];
  datasource: MonumentDto[];

  constructor(private monumentsClient: MonumentsClient,
              private monumentsService: MonumentsService) {

  }

  ngOnInit() {
    this.monumentsService.listFilterParametersChanged
        .subscribe(s => console.log(s));
  }

}
