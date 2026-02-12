import { CommonModule } from '@angular/common';
import { Component, inject, Input, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { CrudList } from 'src/app/shared/form/crud-list';
import { FooterTableComponent } from 'src/app/shared/table/footer-table/footer-table.component';
import { HeaderTableComponent } from 'src/app/shared/table/header-table/header-table.component';
import { LancamentoTipo } from '../lancamento-tipo';

@Component({
  selector: 'app-lancamento-tipo-lista',
  standalone: true,
  imports: [CommonModule, HeaderTableComponent, FooterTableComponent, ReactiveFormsModule],
  templateUrl: './lancamento-tipo-lista.component.html',
  styleUrls: ['./lancamento-tipo-lista.component.scss']
})
export class LancamentoTipoListaComponent implements OnInit {
  private fb = inject(FormBuilder);
  protected crud = inject(CrudList);
  protected dataList?: LancamentoTipo[];
  protected idsList?: string[];
  @Input() cache: boolean = true;
  /**
   * Esse é o método usado para iniciar o componente.
   * Obs. Todas as funções estão concentradas na classe CRUD.
   */
  ngOnInit(): void {
    this.crud.module = this.crud.sessionKey = "lancamentoTipo";
    this.crud.form.formGroup = this.fb.group({
      Nome: [null],
      Id: [null],
      Codigo: [null],
      PageNow: [0],
      PageSize: [this.crud.pageSize],
      Pagination: [true],
      Sort: [''] 
    });
    this.crud.ngInitList(this.cache).then(() => this.actionAfterInitList());
  }
  private actionAfterInitList() {
    this.crud.dataChange.subscribe((value: LancamentoTipo[]) => this.setDataList(value))
  }
  private setDataList(value: LancamentoTipo[]) {
    this.dataList = value;
    this.idsList = this.dataList.map(x => x.Id);
  }
}
