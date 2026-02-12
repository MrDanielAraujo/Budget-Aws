import { CommonModule } from '@angular/common';
import { Component, inject, Input, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { CrudList } from 'src/app/shared/form/crud-list';
import { FooterTableComponent } from 'src/app/shared/table/footer-table/footer-table.component';
import { HeaderTableComponent } from 'src/app/shared/table/header-table/header-table.component';
import { ContaContabilClassificacao } from '../conta-contabil-classificacao';

@Component({
  selector: 'app-conta-contabil-classificacao-lista',
  standalone: true,
  imports: [CommonModule, HeaderTableComponent, FooterTableComponent, ReactiveFormsModule],
  templateUrl: './conta-contabil-classificacao-lista.component.html',
  styleUrls: ['./conta-contabil-classificacao-lista.component.scss']
})
export class ContaContabilClassificacaoListaComponent implements OnInit {
  private fb = inject(FormBuilder);
  protected crud = inject(CrudList);
  protected dataList?: ContaContabilClassificacao[];
  protected idsList?: string[];
  @Input() cache: boolean = true;
  /**
   * Esse é o método usado para iniciar o componente.
   * Obs. Todas as funções estão concentradas na classe CRUD.
   */
  ngOnInit(): void {
    this.crud.module = this.crud.sessionKey = "contaContabilClassificacao";
    this.crud.form.formGroup = this.fb.group({
      Nome: [null],
      Id: [null],
      Codigo:[null],
      PageNow: [0],
      PageSize: [this.crud.pageSize],
      Pagination: [true],
      Sort: [''] 
    });
    this.crud.ngInitList(this.cache).then(() => this.actionAfterInitList());
  }
  private actionAfterInitList() {
    this.crud.dataChange.subscribe((value: ContaContabilClassificacao[]) => this.setDataList(value))
  }
  private setDataList(value: ContaContabilClassificacao[]) {
    this.dataList = value;
    this.idsList = this.dataList.map(x => x.Id);
  }
}
