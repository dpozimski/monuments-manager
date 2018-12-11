import { Injectable, Output, EventEmitter } from '@angular/core';
import { MonumentsListFilterParameters } from './models/monuments-list-filter-parameters';

@Injectable({
  providedIn: 'root'
})
export class MonumentsService {
  listFilterParameters: MonumentsListFilterParameters = new MonumentsListFilterParameters();
  @Output() listFilterParametersChanged: EventEmitter<MonumentsListFilterParameters> = new EventEmitter();

  listFilterParametersChangedCommand() {
    this.listFilterParametersChanged.emit(this.listFilterParameters);
  }
}
