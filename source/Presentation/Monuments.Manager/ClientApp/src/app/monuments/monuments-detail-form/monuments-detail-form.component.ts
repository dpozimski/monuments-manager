import { Component, OnInit, Input, SimpleChanges, OnChanges, ViewChild } from '@angular/core';
import { MonumentDto, AddressDto } from './../../api/monuments-manager-api';
import { Form } from '@angular/forms';

@Component({
  selector: 'app-monuments-detail-form',
  templateUrl: './monuments-detail-form.component.html',
  styleUrls: ['./monuments-detail-form.component.css']
})
export class MonumentsDetailFormComponent implements OnInit {
  @Input()
  public monument: MonumentDto;

  @ViewChild('containerForm')
  containerForm: Form;

  ngOnInit() {
    this.monument = new MonumentDto();
    this.monument.address = new AddressDto();
  }
}
