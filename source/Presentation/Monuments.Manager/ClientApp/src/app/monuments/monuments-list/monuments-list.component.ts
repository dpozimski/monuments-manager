import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { MonumentsService } from '../services/monuments.service';
import { MonumentsDataSource } from '../services/monuments-datasource';
import { MatPaginator, MatSort } from '@angular/material';
import { merge } from "rxjs/observable/merge";
import { transition, state, trigger, style, animate } from '@angular/animations';
import { MonumentDto } from './../../api/monuments-manager-api';

@Component({
  selector: 'app-monuments-list',
  templateUrl: './monuments-list.component.html',
  styleUrls: [
    './monuments-list.component.css',
    './../../styles/tables.css'
  ],
  animations: [
    trigger('detailExpand', [
      state('collapsed, void', style({ height: '0px', minHeight: '0', display: 'none' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
      transition('expanded <=> void', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)'))
    ]),
  ]
})
export class MonumentsListComponent implements OnInit, AfterViewInit {
  readonly displayedColumns: string[] = [
    'picture',
    'name', 
    'constructionDate',
    'ownerName',
    'modifiedDate',
    'modifiedBy',
  ];

  expandedElement: MonumentDto | null;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;


  constructor(public monumentsDataSource: MonumentsDataSource,
              private monumentsService: MonumentsService) {
  }

  ngOnInit() {
    var filter = this.monumentsService.listFilterParameters;
    this.monumentsDataSource.loadMonuments(filter)
  }

  ngAfterViewInit() {
    this.sort.sortChange.subscribe(() => this.paginator.pageIndex = 0);
    this.monumentsService.listFilterParametersChanged
        .subscribe(filter => this.monumentsDataSource.loadMonuments(filter));

    merge(this.sort.sortChange, this.paginator.page)
        .subscribe(_ => {
          var descOrder = this.sort.direction == 'desc';
          var filter = this.monumentsService.listFilterParameters;
          filter.descSortOrder = descOrder;
          filter.pageNumber = this.paginator.pageIndex > 0 ? this.paginator.pageIndex : 1,
          filter.pageSize = this.paginator.pageSize;
          this.monumentsService.listFilterParametersChangedCommand();
        });
  }
}
