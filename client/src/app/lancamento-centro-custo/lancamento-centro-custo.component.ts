import { CommonModule } from '@angular/common';
import { Component, inject, Input, OnInit } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { take } from 'rxjs';
import { ComboInformacoes } from '../combo-informacoes/combo-informacoes';
import { AlertService } from '../shared/alert/alert.service';
import { CrudList } from '../shared/form/crud-list';
import { Form } from '../shared/form/form';
import { HeaderFormComponent } from '../shared/form/header-form/header-form.component';
import { Command } from '../shared/global/command';
import { HttpEvent } from '../shared/http/http-event';
import { LoadingService } from '../shared/loading/loading.service';
import { MenuSecundarioComponent } from '../shared/menu/menu-secundario/menu-secundario.component';
import { ModalTypeOneComponent } from '../shared/modal/modal-type-one/modal-type-one.component';
import { ModelTypeOneService } from '../shared/modal/modal-type-one/model-type-one.service';
import { Table } from '../shared/table/table';
import { LancamentoCentroCustoView } from './lancamento-centro-custo';

@Component({
  selector: 'app-lancamento-centro-custo',
  standalone: true,
  imports: [CommonModule, HeaderFormComponent, MenuSecundarioComponent, ModalTypeOneComponent, ReactiveFormsModule, FormsModule],
  templateUrl: './lancamento-centro-custo.component.html',
  styleUrls: ['./lancamento-centro-custo.component.scss']
})
export class LancamentoCentroCustoComponent implements OnInit {
  
  private element!: Element | null;
  protected loading = inject(LoadingService);
  public modelTypeOneService = inject(ModelTypeOneService);
  private fb = inject(FormBuilder);
  private http = inject(HttpEvent);
  protected crud = inject(CrudList);
  public form = new Form();
  public classForLancamentoTipo = {
    real:"primary",
    forecast:"success",
    orçado: "black"
  }


  protected dataList?: [];
  public totalShow: boolean = true;
  public contaFixasShow: boolean = true;
  public contaVariaveisShow: boolean = true;
  public lancamentoShow = new Map();

  public LancamentoCentroCusto?: LancamentoCentroCustoView = new LancamentoCentroCustoView();

  @Input() centro!: string;
  @Input() ano!: string;

  constructor(
    protected command: Command,
    protected alert: AlertService
  ) {}

  ngOnInit(): void {
    this.loading.show = false;
    this.crud.form.formGroup = this.fb.group({
      IdLancamentoTipo: [3],
      IdCentroCusto: [1],
      IdExercicio:[8],
      Janeiro: [null],
      Fevereiro: [null],
      Marco: [null],
      Abril: [null],
      Maio: [null],
      Junho: [null],
      Julho: [null],
      Agosto: [null],
      Setembro: [null],
      Outubro: [null],
      Novembro: [null],
      Dezembro: [null],
      OrcadoReal: [null],
      OrcadoRealPorcento: [null],
      OrcadoForecast: [null],
      OrcadoForecastPorcento: [null],
      PageNow: [0],
      PageSize: [this.crud.pageSize],
      Pagination: [true],
      Sort: [''] 
    });    

    this.ngCentroCustoLancamentoList();
  }

  /**
   * 
   */
  private ngCentroCustoLancamentoList(): void {
    
    //this.loading.show = true;
    this.http.listFilterGeneric(this.crud.form.formGroup.controls, "CentroCustoLancamento", "Lancamentos").subscribe( {
      next: (data: LancamentoCentroCustoView): void => this.ngCentroCustoLancamentoListSuccess(data),
      error: (error: any) => console.log(error),
    });
  }

  private ngCentroCustoLancamentoListSuccess(data: LancamentoCentroCustoView): void {
    this.LancamentoCentroCusto = data;
    
    this.LancamentoCentroCusto.Fixas.forEach(x => {
      this.lancamentoShow.set(x.CodigoContaContabil, false);
    })

    this.LancamentoCentroCusto.Variaveis.forEach(x => {
      this.lancamentoShow.set(x.CodigoContaContabil, false);
    })

    console.log(this.lancamentoShow);

  }

  public lancamentoRowShow(codigoContaContabil:number, digito:number, tipo: string) {
    let value = this.lancamentoShow.get(codigoContaContabil) as boolean;
    return (value || (digito == 0 && tipo.toLocaleLowerCase() == 'orçado') ) ? true : false;
  }

  public getLancamentoShow(codigoContaContabil:number): boolean {
    return this.lancamentoShow.get(codigoContaContabil) as boolean; 
  }

  public setLancamentoShow(codigoContaContabil:number): void {
    let value = this.lancamentoShow.get(codigoContaContabil) as boolean; 
    this.lancamentoShow.set(codigoContaContabil, !value);
  }

  onScroll(event: any): void {
    this.element = event.target;
  }

  onVoltar(): void {
    this.loading.show = false;
    this.command.navigate('home', [true]);
  }

  onGetComboInformacoes(combo: {id:string, nome:string}) {
    this.modelTypeOneService.title = combo.nome;
    this.loading.show = true;
    this.form.formGroup = this.fb.group({
      IdCentroCusto: [this.centro],
      IdComboInformacoesSeparacao: [combo.id],
      PageNow: [0],
      PageSize: [100],
      Pagination: [false],
      Sort: [''] 
    });
    this.http.listFilter(this.form.formGroup.controls, "ComboInformacoes").subscribe( {
      next: (data: Table): void => this.listFilterSuccess(data),
      error: (error: any) => this.listFilterError(error),
    });
  }

  private listFilterSuccess(data: Table) {
    const comboInformacoesList = data.Data as ComboInformacoes[];
    this.modelTypeOneService.content = comboInformacoesList.length >= 1 ? comboInformacoesList.map( item => { return item.Nome }): ["Sem Informações para esse item"];
    this.loading.show = false;
  }

  private listFilterError(error: any) {
    this.alert.showAlertError(error).pipe(take(1)).subscribe(() => this.loading.show = false);
  }

  public contaFixaExpand() {
    this.totalShow = !this.totalShow;
    this.contaVariaveisShow = !this.contaVariaveisShow;
  }

  public contaVariaveisExpand() {
    this.totalShow = !this.totalShow;
    this.contaFixasShow = !this.contaFixasShow;
  }

  public tooltip(message: string[]) {
    this.alert.showAlertPrimary(message).pipe(take(1)).subscribe(() => this.loading.show = false);
  }

  public getClassByLancamentoTipo(tipo:string): string {
    if(tipo.toLocaleLowerCase() == 'real') return "primary";
    if(tipo.toLocaleLowerCase() == 'forecast') return "success";
    if(tipo.toLocaleLowerCase() == 'orçado') return  "black";
    return '';
  }
}
