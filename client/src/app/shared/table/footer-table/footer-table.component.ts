import { CommonModule } from '@angular/common';
import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Table } from '../table';
import { FooterTable } from './footer-table';

@Component({
  selector: 'app-footer-table',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './footer-table.component.html',
  styleUrls: ['./footer-table.component.scss']
})
export class FooterTableComponent {

  //@Input() pages: number[] = [];
  //@Input() pageNow!: number;
  //@Input() pageCount!: number;
  //@Input() regCount!: number;

  @Output() eventReset = new EventEmitter<void>();

  @Input() table!: Table;

  @Output() btn = new EventEmitter<FooterTable>();
  retorno: FooterTable = new FooterTable();

  onExcel(e: Event) {
    
    this.retorno.e = e;
    this.retorno.type = "onExportExcel";
    this.retorno.value = true;
    this.btn.emit(this.retorno);
  }

  onPagination(e: Event, page: number) {

    this.retorno.e = e;
    this.retorno.type = "onPagination";
    this.retorno.value = page;
    this.btn.emit(this.retorno);
  }

  onCreate(e: Event): void {

    this.retorno.e = e;
    this.retorno.type = "onSelectItem";
    this.retorno.value = 0;
    this.btn.emit(this.retorno);
  }

  onDelete(e: Event): void {

    this.retorno.e = e;
    this.retorno.type = "onDelete";
    this.retorno.value = true;
    this.btn.emit(this.retorno);
  }

  onImport(e: Event): void {

    this.retorno.e = e;
    this.retorno.type = "onImportFile";
    this.retorno.value = true;
    this.btn.emit(this.retorno);
  }

  onReset(e: Event): void {
    this.eventReset.emit();
  }


}
