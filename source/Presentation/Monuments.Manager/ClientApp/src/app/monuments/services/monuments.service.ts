import { Injectable, Output, EventEmitter } from '@angular/core';
import { MonumentsListFilterParameters } from '../models/monuments-list-filter-parameters';
import { MonumentPreviewDto, MonumentDto } from './../../api/monuments-manager-api';

@Injectable({
  providedIn: 'root'
})
export class MonumentsService {
  listFilterParameters: MonumentsListFilterParameters = new MonumentsListFilterParameters();
  @Output() listFilterParametersChanged: EventEmitter<MonumentsListFilterParameters> = new EventEmitter();

  selectedMonumentPreview: MonumentPreviewDto = null;
  @Output() selectedMonumentPreviewChanged: EventEmitter<MonumentPreviewDto> = new EventEmitter();

  selectedMonument: MonumentDto = null;
  @Output() selectedMonumentChanged: EventEmitter<MonumentDto> = new EventEmitter();

  listFilterParametersChangedCommand() {
    this.listFilterParametersChanged.emit(this.listFilterParameters);
  }

  selectedMonumentPreviewChangedCommand(selectedMonumentPreview: MonumentPreviewDto) {
    this.selectedMonumentPreview = this.selectedMonumentPreview === selectedMonumentPreview ? null : selectedMonumentPreview;
    this.selectedMonumentPreviewChanged.emit(this.selectedMonumentPreview);
  }

  selectedMonumentChangedCommand(selectedMonument: MonumentDto) {
    this.selectedMonument = selectedMonument;
    this.selectedMonumentChanged.emit(this.selectedMonument);
  }
}
