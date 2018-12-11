import { Component, OnInit } from '@angular/core';
import { MonumentsClient, MonumentDto, GetMonumentsQueryResult } from './../../api/monuments-manager-api';
import { MonumentsService } from '../monuments.service';
import { MonumentsListFilterParameters } from '../models/monuments-list-filter-parameters';
import { ToastrService } from 'ngx-toastr';

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
  pagesCount: number = 1;
  datasource: MonumentDto[];

  constructor(private monumentsClient: MonumentsClient,
              private monumentsService: MonumentsService,
              private toastr: ToastrService) {

  }

  ngOnInit() {
    this.monumentsService.listFilterParametersChanged
        .subscribe(s => this.callForData(s));
  }

  callForData(parameters: MonumentsListFilterParameters) {
    this.monumentsClient.get2(
      parameters.descSortOrder,
      parameters.pageNumber,
      parameters.pageSize,
      parameters.filter)
        .subscribe(result => this.fillDataSet(result),
                   _ => this.toastr.error('Cannot retrieve monuments', 'Monuments manager'));
  }

  fillDataSet(result: GetMonumentsQueryResult): void {
    this.pagesCount = result.pagesCount;

    
  }
}
