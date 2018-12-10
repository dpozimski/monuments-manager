import { Component, OnInit } from '@angular/core';
import { MonumentsClient, MonumentPreviewDto } from './../../api/monuments-manager-api';

@Component({
  selector: 'app-monuments-list',
  templateUrl: './monuments-list.component.html',
  styleUrls: ['./monuments-list.component.css']
})
export class MonumentsListComponent implements OnInit {
  source: MonumentPreviewDto[];

  constructor(private monumentsClient: MonumentsClient) { }

  ngOnInit() {
  }

}
