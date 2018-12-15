import { Injectable } from '@angular/core';
import { MonumentDto, MonumentsClient, MonumentPreviewDto } from '../../api/monuments-manager-api';
import { DataSource } from '@angular/cdk/table';
import { Observable, BehaviorSubject, of } from 'rxjs';
import { CollectionViewer } from '@angular/cdk/collections';
import { MonumentsListFilterParameters } from '../models/monuments-list-filter-parameters';
import { catchError, finalize } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MonumentsPreviewDataSource implements DataSource<MonumentPreviewDto> {
  private monumentsSubject = new BehaviorSubject<MonumentPreviewDto[]>([]);
  private loadingSubject = new BehaviorSubject<boolean>(false);
  private monumentsCountSubject = new BehaviorSubject<number>(1);

  loading = this.loadingSubject.asObservable();
  monumentsPreviewCount = this.monumentsCountSubject.asObservable();

  constructor(private monumentsClient: MonumentsClient) {
    this.monumentsClient.getMonumentsStats()
        .subscribe(result => this.monumentsCountSubject.next(result.monumentsCount));
  }

  loadMonuments(parameters: MonumentsListFilterParameters) {
    this.loadingSubject.next(true);
    this.monumentsClient.getAll(
      parameters.descSortOrder,
      parameters.pageNumber,
      parameters.pageSize,
      parameters.filter || "").pipe(
        catchError(() => of([])),
        finalize(() => this.loadingSubject.next(false))
      )
      .subscribe(monuments => this.monumentsSubject.next(monuments));
  }

  connect(_: CollectionViewer): Observable<MonumentDto[]> {
    console.log("Connecting data source");
    return this.monumentsSubject.asObservable();
  }

  disconnect(_: CollectionViewer) {
    this.monumentsSubject.complete();
    this.loadingSubject.complete();
  }
}