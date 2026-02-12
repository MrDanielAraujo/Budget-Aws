import { CommonModule } from '@angular/common';
import { Component, inject, Input, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { CrudList } from 'src/app/shared/form/crud-list';
import { FooterTableComponent } from 'src/app/shared/table/footer-table/footer-table.component';
import { HeaderTableComponent } from 'src/app/shared/table/header-table/header-table.component';
import { CentroCategoria } from '../centro-categoria';

@Component({
  selector: 'app-centro-categoria-lista',
  standalone: true,
  imports: [CommonModule, HeaderTableComponent, FooterTableComponent, ReactiveFormsModule],
  templateUrl: './centro-categoria-lista.component.html',
  styleUrls: ['./centro-categoria-lista.component.scss']
})
export class CentroCategoriaListaComponent implements OnInit {
  private fb = inject(FormBuilder);
  protected crud = inject(CrudList);
  protected dataList?: CentroCategoria[];
  protected idsList?: string[];
  @Input() cache: boolean = true;
  /**
   * * Esse é o método usado para iniciar o componente.
   * * Obs. Todas as funções estão concentradas na classe CRUD.
   */
  ngOnInit(): void {
    this.crud.module = this.crud.sessionKey = "centroCategoria";
    this.crud.form.formGroup = this.fb.group({
      Nome: [null],
      Id: [null],
      PageNow: [0],
      PageSize: [this.crud.pageSize],
      Pagination: [true],
      Sort: [''] 
    });    
    this.crud.ngInitList(this.cache).then(() => this.actionAfterInitList());
  }
  private actionAfterInitList() {
    this.crud.dataChange.subscribe((value: CentroCategoria[]) => this.setDataList(value))
  }
  private setDataList(value: CentroCategoria[]) {
    this.dataList = value;
    this.idsList = this.dataList.map(x => x.Id);
  }
}