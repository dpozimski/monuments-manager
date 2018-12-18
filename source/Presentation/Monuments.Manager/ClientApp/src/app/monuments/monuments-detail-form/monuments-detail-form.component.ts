import { Component, OnInit, Input } from '@angular/core';
import { MonumentDto, AddressDto, DictionaryValueDto } from './../../api/monuments-manager-api';
import { DictionariesProviderService } from './../../api/dictionaries-provider.service';

@Component({
  selector: 'app-monuments-detail-form',
  templateUrl: './monuments-detail-form.component.html',
  styleUrls: ['./monuments-detail-form.component.css']
})
export class MonumentsDetailFormComponent implements OnInit  {
  @Input()
  monument: MonumentDto;

  provinces: DictionaryValueDto[] = [];
  districts: DictionaryValueDto[] = [];
  communes: DictionaryValueDto[] = [];
  cities: DictionaryValueDto[] = [];
  streets: DictionaryValueDto[] = [];

  constructor(private dictionariesProviderService: DictionariesProviderService){

  }

  ngOnInit() {
    this.monument = new MonumentDto();
    this.monument.address = new AddressDto();
    this.dictionariesProviderService.getProvinces()
        .subscribe(s => this.provinces = s);
  }
}
