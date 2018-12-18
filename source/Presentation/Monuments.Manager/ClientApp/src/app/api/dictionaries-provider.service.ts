import { Injectable } from '@angular/core';
import { DictionariesClient, DictionaryValueDto } from './monuments-manager-api';
import { Observable, of } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable()
export class DictionariesProviderService {
  private cache: Map<string, DictionaryValueDto[]> = new Map<string, DictionaryValueDto[]>();

  constructor(private dictionariesClient: DictionariesClient) { }

  getProvinces(): Observable<DictionaryValueDto[]> {
    var key = 'provinces';
    if (this.cache.has(key))
      return of(this.cache.get(key));
    else {
      return this.dictionariesClient.getProvinces()
        .pipe(map(s => this.saveAndReturnEntry(key, s)));
    }
  }

  getDistricts(province: string): Observable<DictionaryValueDto[]> {
    var key = this.createKey(province);
    if (this.cache.has(key))
      return of(this.cache.get(key));
    else if(province) {
      return this.dictionariesClient.getDistricts(province)
        .pipe(map(s => this.saveAndReturnEntry(key, s)));
    } else {
      return of([]);
    }
  }

  getCommunes(province: string, district: string): Observable<DictionaryValueDto[]> {
    var key = this.createKey(province, district);
    if (this.cache.has(key))
      return of(this.cache.get(key));
    else if(province && district) {
      return this.dictionariesClient.getCommunes(province, district)
        .pipe(map(s => this.saveAndReturnEntry(key, s)));
    } else {
      return of([]);
    }
  }

  getCities(province: string, district: string, commune: string): Observable<DictionaryValueDto[]> {
    var key = this.createKey(province, district, commune);
    if (this.cache.has(key))
      return of(this.cache.get(key));
    else if(province && district && commune) {
      return this.dictionariesClient.getCities(province, district, commune)
        .pipe(map(s => this.saveAndReturnEntry(key, s)));
    } else {
      return of([]);
    }
  }

  getStreets(province: string, district: string, commune: string, street: string): Observable<DictionaryValueDto[]> {
    var key = this.createKey(province, district, commune, street);
    if (this.cache.has(key))
      return of(this.cache.get(key));
    else if(province && district && commune && street) {
      return this.dictionariesClient.getStreets(province, district, commune, street)
        .pipe(map(s => this.saveAndReturnEntry(key, s)));
    } else {
      return of([]);
    }
  }

  private createKey(...params: string[]): string {
    return params.join();
  }

  private saveAndReturnEntry(key: string, result: DictionaryValueDto[]): DictionaryValueDto[] {
    //this.cache.set(key, result);
    return result;
  }
}
