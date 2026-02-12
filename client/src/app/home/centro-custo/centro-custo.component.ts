import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { CrudList } from 'src/app/shared/form/crud-list';
import { HomeCentroCusto } from './centro-custo';

@Component({
  selector: 'app-centro-custo',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './centro-custo.component.html',
  styleUrls: ['./centro-custo.component.scss']
})
export class CentroCustoComponent implements OnInit {
  private fb = inject(FormBuilder);
  protected crud = inject(CrudList);
  protected dataList?: HomeCentroCusto[];
  ngOnInit(): void {
    this.crud.module = this.crud.sessionKey = "home";
    this.crud.form.formGroup = this.fb.group({
      CentroCodigo: [null],
      CentroNome: [null],
      Usuario: [null],
      NivelAtual: [null],
      NivelTotal: [null],
      Situacao: [null],
      CentroTipo: ['centroCusto'],
      PageNow: [0],
      PageSize: [this.crud.pageSize],
      Pagination: [true],
      Sort: [''] 
    });
    this.crud.ngInitList(false).then(() => this.crud.dataChange.subscribe((value: HomeCentroCusto[]) => this.dataList = value));
  }
  /**
   * 
   */
  onSubmitCusto(): void {
    
  }
}
