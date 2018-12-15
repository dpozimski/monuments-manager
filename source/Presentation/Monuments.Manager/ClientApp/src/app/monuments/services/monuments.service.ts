import { Injectable, Output, EventEmitter } from '@angular/core';
import { MonumentsListFilterParameters } from '../models/monuments-list-filter-parameters';
import { MonumentPreviewDto } from './../../api/monuments-manager-api';

@Injectable({
  providedIn: 'root'
})
export class MonumentsService {
  listFilterParameters: MonumentsListFilterParameters = new MonumentsListFilterParameters();
  @Output() listFilterParametersChanged: EventEmitter<MonumentsListFilterParameters> = new EventEmitter();

  selectedMonumentPreview: MonumentPreviewDto = null;
  @Output() selectedMonumentPreviewChanged: EventEmitter<MonumentPreviewDto> = new EventEmitter();

  listFilterParametersChangedCommand() {
    this.listFilterParametersChanged.emit(this.listFilterParameters);
  }

  monumentDetailChangedCommand(monumentDetail: MonumentPreviewDto) {
    this.selectedMonumentPreview = this.selectedMonumentPreview === monumentDetail ? null : monumentDetail;
    this.selectedMonumentPreviewChanged.emit(this.selectedMonumentPreview);
  }
}
