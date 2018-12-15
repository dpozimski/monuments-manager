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

  selectedMonumentPreviewChangedCommand(selectedMonumentPreview: MonumentPreviewDto) {
    this.selectedMonumentPreview = this.selectedMonumentPreview === selectedMonumentPreview ? null : selectedMonumentPreview;
    this.selectedMonumentPreviewChanged.emit(this.selectedMonumentPreview);
  }
}
