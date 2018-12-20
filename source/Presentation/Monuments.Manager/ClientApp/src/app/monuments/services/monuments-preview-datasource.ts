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

  loading = this.loadingSubject.asObservable();
  monumentsPreviewCount = 5;

  constructor(private monumentsClient: MonumentsClient) {
    this.monumentsClient.getMonumentsStats()
        .subscribe(result => this.monumentsPreviewCount = result.monumentsCount);
  }

  updateMonument(result: MonumentPreviewDto) {
    var updatedMonuments = this.monumentsSubject.value.filter(s => s.id != result.id);
    updatedMonuments.push(result);
    this.monumentsSubject.next(updatedMonuments);
  }

  deleteMonument(monumentId: number) {
    var updatedMonuments = this.monumentsSubject.value.filter(s => s.id != monumentId);
    this.monumentsSubject.next(updatedMonuments);
  }

  addMonument(monumentPreview: MonumentPreviewDto) {
    var monuments = this.monumentsSubject.value;
    monuments.push(monumentPreview);
    this.monumentsSubject.next(monuments);
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
      .subscribe(monuments => {
        this.monumentsSubject.next(monuments);
      });
  }

  connect(_: CollectionViewer): Observable<MonumentDto[]> {
    return this.monumentsSubject.asObservable();
  }

  disconnect(_: CollectionViewer) {
    this.monumentsSubject.complete();
    this.loadingSubject.complete();
  }
}
