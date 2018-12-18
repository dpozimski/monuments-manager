import { Component, OnInit, Input, SimpleChanges, OnChanges } from '@angular/core';
import { MonumentDto, AddressDto } from './../../api/monuments-manager-api';

@Component({
  selector: 'app-monuments-detail-form',
  templateUrl: './monuments-detail-form.component.html',
  styleUrls: ['./monuments-detail-form.component.css']
})
export class MonumentsDetailFormComponent implements OnInit {
  @Input()
  monument: MonumentDto;

  ngOnInit() {
    this.monument = new MonumentDto();
    this.monument.address = new AddressDto();
  }
}
