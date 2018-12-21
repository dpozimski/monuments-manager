import { Component, OnInit } from '@angular/core';
import { MonumentsClient, MonumentPreviewDto } from './../../api/monuments-manager-api';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-recent',
  templateUrl: './recent.component.html',
  styleUrls: [
    './recent.component.css',
    './../../styles/cards.css'
  ]
})
export class RecentComponent implements OnInit {
  private readonly recentCount: number = 6;
  monuments: MonumentPreviewDto[];

  constructor(private monumentsClient: MonumentsClient,
              private toastr: ToastrService) { }

  ngOnInit() {
    this.monumentsClient.getRecent(this.recentCount)
        .subscribe(result => this.monuments = result, 
                   _ => this.toastr.error('Cannot receive recent monuments', 'Recent monuments'));
  }
}
