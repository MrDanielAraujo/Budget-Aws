import { CommonModule } from '@angular/common';
import { Component, inject, Input, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule } from '@angular/forms';
import { take } from 'rxjs';
import { CrudList } from 'src/app/shared/form/crud-list';
import { FooterTableComponent } from 'src/app/shared/table/footer-table/footer-table.component';
import { HeaderTableComponent } from 'src/app/shared/table/header-table/header-table.component';
import { CentroCustoSituacaoLista } from './centro-custo-situacao-lista';

@Component({
  selector: 'app-centro-custo-situacao-lista',
  standalone: true,
  imports: [CommonModule, HeaderTableComponent, FooterTableComponent, ReactiveFormsModule],
  templateUrl: './centro-custo-situacao-lista.component.html',
  styleUrls: ['./centro-custo-situacao-lista.component.scss']
})
export class CentroCustoSituacaoListaComponent implements OnInit {
  private fb = inject(FormBuilder);
  protected crud = inject(CrudList);
  protected dataList?: CentroCustoSituacaoLista[];
  protected idsList?: string[];
  @Input() cache: boolean = true;
  /**
   * Esse é o método usado para iniciar o componente.
   * Obs. Todas as funções estão concentradas na classe CRUD.
   */
  ngOnInit(): void { 
    this.crud.module = this.crud.sessionKey = "centroCustoSituacao";
    this.crud.form.formGroup = this.fb.group({
      Centro: [null],
      Exercicio: [null],
      Id: [null],
      PageNow: [0],
      PageSize: [this.crud.pageSize],
      Pagination: [true],
      Sort: [''] 
    });
    this.crud.ngInitList(this.cache).then(() => this.actionAfterInitList());
  }

  public onReset(): void {
    this.crud.loading.show = true;
    this.crud.http.updateAll(`${this.crud.module}/reset`).subscribe({
      next: () => this.onResetSuccess(),
      error: (error: any) => this.onResetError(error)
    });
  }

  private onResetSuccess(): void {
    this.crud.alert.showAlertSuccess(["Todos os centros foram resetados com Sucesso!"]).pipe(take(1)).subscribe(() => this.crud.loading.show = false);
  }

  private onResetError(error: any): void {
    this.crud.alert.showAlertError(error).pipe(take(1)).subscribe(() => this.crud.loading.show = false);
  }

  private actionAfterInitList() {
    this.crud.dataChange.subscribe((value: CentroCustoSituacaoLista[]) => this.setDataList(value))
  }
  private setDataList(value: CentroCustoSituacaoLista[]) {
    this.dataList = value;
    this.idsList = this.dataList.map(x => x.Id);
  }
}
