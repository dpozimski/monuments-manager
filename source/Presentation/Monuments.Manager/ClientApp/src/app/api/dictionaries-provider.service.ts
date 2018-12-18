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
    else {
      return this.dictionariesClient.getDistricts(province)
        .pipe(map(s => this.saveAndReturnEntry(key, s)));
    }
  }

  getCommunes(province: string, district: string): Observable<DictionaryValueDto[]> {
    var key = this.createKey(province, district);
    if (this.cache.has(key))
      return of(this.cache.get(key));
    else {
      return this.dictionariesClient.getCommunes(province, district)
        .pipe(map(s => this.saveAndReturnEntry(key, s)));
    }
  }

  getCities(province: string, district: string, commune: string): Observable<DictionaryValueDto[]> {
    var key = this.createKey(province, district, commune);
    if (this.cache.has(key))
      return of(this.cache.get(key));
    else {
      return this.dictionariesClient.getCities(province, district, commune)
        .pipe(map(s => this.saveAndReturnEntry(key, s)));
    }
  }

  getStreets(province: string, district: string, commune: string, streets: string): Observable<DictionaryValueDto[]> {
    var key = this.createKey(province, district, commune, streets);
    if (this.cache.has(key))
      return of(this.cache.get(key));
    else {
      return this.dictionariesClient.getStreets(province, district, commune, streets)
        .pipe(map(s => this.saveAndReturnEntry(key, s)));
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
