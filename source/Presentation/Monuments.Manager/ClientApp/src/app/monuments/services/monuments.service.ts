import { Injectable, Output, EventEmitter } from '@angular/core';
import { MonumentsListFilterParameters } from '../models/monuments-list-filter-parameters';
import { MonumentDto } from 'src/app/api/monuments-manager-api';

@Injectable({
  providedIn: 'root'
})
export class MonumentsService {
  listFilterParameters: MonumentsListFilterParameters = new MonumentsListFilterParameters();
  @Output() listFilterParametersChanged: EventEmitter<MonumentsListFilterParameters> = new EventEmitter();

  monumentDetail: MonumentDto = null;
  @Output() monumentDetailChanged: EventEmitter<MonumentDto> = new EventEmitter();

  listFilterParametersChangedCommand() {
    this.listFilterParametersChanged.emit(this.listFilterParameters);
  }

  monumentDetailChangedCommand(monumentDetail: MonumentDto) {
    this.monumentDetail = this.monumentDetail === monumentDetail ? null : monumentDetail;
    this.monumentDetailChanged.emit(this.monumentDetail);
  }
}
