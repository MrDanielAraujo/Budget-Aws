import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { CrudList } from 'src/app/shared/form/crud-list';
import { HomeCentroLucro } from './centro-lucro';

@Component({
  selector: 'app-centro-lucro',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './centro-lucro.component.html',
  styleUrls: ['./centro-lucro.component.scss']
})
export class CentroLucroComponent implements OnInit {
  private fb = inject(FormBuilder);
  protected crud = inject(CrudList);
  protected dataList?: HomeCentroLucro[];
  ngOnInit(): void {
    this.crud.module = this.crud.sessionKey = "home";
    this.crud.form.formGroup = this.fb.group({
      CentroCodigo: [null],
      CentroNome: [null],
      Usuario: [null],
      NivelAtual: [null],
      NivelTotal: [null],
      Situacao: [null],
      CentroTipo: ['centroLucro'],
      PageNow: [0],
      PageSize: [this.crud.pageSize],
      Pagination: [true],
      Sort: [''] 
    });
    this.crud.ngInitList(false).then(() => this.crud.dataChange.subscribe((value: HomeCentroLucro[]) => this.dataList = value));
  }
  /**
   * 
   */
  onSubmitCusto(): void {
    
  }
}
