import { CommonModule } from "@angular/common";
import { Component, inject, Input, OnInit } from "@angular/core";
import { FormBuilder, ReactiveFormsModule } from "@angular/forms";
import { CrudList } from "src/app/shared/form/crud-list";
import { AbertoFechadoPipe } from "src/app/shared/pipe/AbertoFechado";
import { FooterTableComponent } from "src/app/shared/table/footer-table/footer-table.component";
import { HeaderTableComponent } from "src/app/shared/table/header-table/header-table.component";
import { LancamentoCentroCustoLista } from "./lancamento-centro-custo-lista";

@Component({
  selector: 'app-lancamento-centro-custo-lista',
  standalone: true,
  imports: [CommonModule, AbertoFechadoPipe, HeaderTableComponent, FooterTableComponent, ReactiveFormsModule],
  templateUrl: './lancamento-centro-custo-lista.component.html',
  styleUrls: ['./lancamento-centro-custo-lista.component.scss']
})
export class LancamentoCentroCustoListaComponent implements OnInit {
  private fb = inject(FormBuilder);
  protected crud = inject(CrudList);
  protected dataList?: LancamentoCentroCustoLista[];
  protected idsList?: string[];
  @Input() cache: boolean = true;
  /**
   * Esse é o método usado para iniciar o componente.
   * Obs. Todas as funções estão concentradas na classe CRUD.
   */
  ngOnInit(): void {
    this.crud.module = this.crud.sessionKey = "centroCustoLancamento";
    this.crud.form.formGroup = this.fb.group({
      Tipo: [null],
      CentroCusto: [null],
      ContaContabil: [null],
      Exercicio: [null],
      Id: [null],
      PageNow: [0],
      PageSize: [this.crud.pageSize],
      Pagination: [true],
      Sort: [''] 
    });
    this.crud.ngInitList(this.cache).then(() => this.actionAfterInitList());
  }
  private actionAfterInitList() {
    this.crud.dataChange.subscribe((value: LancamentoCentroCustoLista[]) => this.setDataList(value))
  }
  private setDataList(value: LancamentoCentroCustoLista[]) {
    this.dataList = value;
    this.idsList = this.dataList.map(x => x.Id);
  }
}