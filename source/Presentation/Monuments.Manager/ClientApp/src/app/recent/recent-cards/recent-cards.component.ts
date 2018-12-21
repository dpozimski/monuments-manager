import { Component, OnInit, Input } from '@angular/core';
import { MonumentPreviewDto } from './../../api/monuments-manager-api';

@Component({
  selector: 'app-recent-cards',
  templateUrl: './recent-cards.component.html',
  styleUrls: ['./recent-cards.component.css']
})
export class RecentCardsComponent implements OnInit {
  @Input()
  monuments: MonumentPreviewDto[];

  constructor() { }

  ngOnInit() {
  }

}
