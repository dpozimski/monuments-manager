import { Component, OnInit, Input, SimpleChanges, OnChanges } from '@angular/core';
import { MonumentDto, AddressDto, DictionaryValueDto } from './../../api/monuments-manager-api';
import { DictionariesProviderService } from './../../api/dictionaries-provider.service';
import { BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-monuments-detail-form',
  templateUrl: './monuments-detail-form.component.html',
  styleUrls: ['./monuments-detail-form.component.css']
})
export class MonumentsDetailFormComponent implements OnInit, OnChanges {
  @Input()
  monument: MonumentDto;

  provinceSubject: BehaviorSubject<string> = new BehaviorSubject<string>('');
  provinces: DictionaryValueDto[] = [];

  districtSubject: BehaviorSubject<string> = new BehaviorSubject<string>('');
  districts: DictionaryValueDto[] = [];

  communeSubject: BehaviorSubject<string> = new BehaviorSubject<string>('');
  communes: DictionaryValueDto[] = [];

  citySubject: BehaviorSubject<string> = new BehaviorSubject<string>('');
  cities: DictionaryValueDto[] = [];

  streetSubject: BehaviorSubject<string> = new BehaviorSubject<string>('');
  streets: DictionaryValueDto[] = [];

  constructor(private dictionaries: DictionariesProviderService) {

  }

  ngOnInit() {
    this.monument = new MonumentDto();
    this.monument.address = new AddressDto();
  }

  ngOnChanges(changes: SimpleChanges): void {console.log(changes);
    if ((!changes.monument.previousValue  || 
          changes.monument.previousValue.id !== changes.monument.currentValue.id) &&
          this.monument.address)
    {
      console.log('www');

      this.provinceSubject.subscribe(x => this.dictionaries
        .getDistricts(x)
        .subscribe(x => this.districts = x));
      this.districtSubject.subscribe(x => this.dictionaries
        .getCommunes(this.provinceSubject.value, x)
        .subscribe(x => this.communes = x));
      this.communeSubject.subscribe(x => this.dictionaries
        .getCities(this.provinceSubject.value, this.districtSubject.value, x)
        .subscribe(x => this.cities = x));
      this.citySubject.subscribe(x => this.dictionaries
        .getStreets(this.provinceSubject.value, this.districtSubject.value, this.citySubject.value, x)
        .subscribe(x => this.cities = x));
    }
  }

  onDictionaryChange(dictionaryId: string, newValue: string) {
    console.log(dictionaryId + ' ' + newValue);
    console.log(this.monument);

    this.provinceSubject.next(this.monument.address.province);
    this.districtSubject.next(this.monument.address.district);
    this.communeSubject.next(this.monument.address.commune);
    this.citySubject.next(this.monument.address.city);
    this.streetSubject.next(this.monument.address.street);
  }
}
