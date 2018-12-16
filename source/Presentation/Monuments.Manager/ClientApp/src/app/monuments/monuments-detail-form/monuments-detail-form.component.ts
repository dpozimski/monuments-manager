import { Component, OnInit, Input, OnChanges } from '@angular/core';
import { MonumentDto } from './../../api/monuments-manager-api';

@Component({
  selector: 'app-monuments-detail-form',
  templateUrl: './monuments-detail-form.component.html',
  styleUrls: ['./monuments-detail-form.component.css']
})
export class MonumentsDetailFormComponent {
  @Input()
  monument: MonumentDto = new MonumentDto();

  constructor() { }
}
