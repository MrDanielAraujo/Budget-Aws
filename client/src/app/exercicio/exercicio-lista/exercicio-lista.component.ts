import { CommonModule } from '@angular/common';
import { Component, inject, Input, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { take } from 'rxjs';
import { AlertService } from 'src/app/shared/alert/alert.service';
import { CrudList } from 'src/app/shared/form/crud-list';
import { Command } from 'src/app/shared/global/command';
import { HttpEvent } from 'src/app/shared/http/http-event';
import { LoadingService } from 'src/app/shared/loading/loading.service';
import { AbertoFechadoPipe } from 'src/app/shared/pipe/AbertoFechado';
import { FooterTableComponent } from 'src/app/shared/table/footer-table/footer-table.component';
import { HeaderTableComponent } from 'src/app/shared/table/header-table/header-table.component';
import { Exercicio } from '../exercicio';

@Component({
  selector: 'app-exercicio-lista',
  standalone: true,
  imports: [CommonModule, AbertoFechadoPipe, HeaderTableComponent, FooterTableComponent, ReactiveFormsModule, FormsModule],
  templateUrl: './exercicio-lista.component.html',
  styleUrls: ['./exercicio-lista.component.scss']
})
export class ExercicioListaComponent implements OnInit, OnDestroy{
  private fb = inject(FormBuilder);
  protected crud = inject(CrudList);
  public loading = inject(LoadingService);
  private http = inject(HttpEvent);

  protected dataList?: Exercicio[];
  protected idsList?: string[];

  private msgConfirm: string = "Você deseja realmente alterar esses Exercicio {ano}?";
  private msgUpdateSuccess = "O Exercicio {ano} foi alterado com Sucesso!";
  private msgUpdateError = "Erro ao tentar alterar o Exercicio {ano}";

  @Input() cache: boolean = true;

  constructor(protected alert:AlertService, protected command:Command) {}
  
  /**
   * Esse é o método usado para iniciar o componente.
   * Obs. Todas as funções estão concentradas na classe CRUD.
   */
  ngOnInit(): void {
    this.crud.module = this.crud.sessionKey = "exercicio";
    this.crud.form.formGroup = this.fb.group({
      Aberto: [null],
      Ano: [null],
      Id: [null],
      PageNow: [0],
      PageSize: [this.crud.pageSize],
      Pagination: [true],
      Sort: [''] 
    });    
    this.crud.ngInitList(this.cache).then(() => this.actionAfterInitList());
  }
  private actionAfterInitList() {
    this.crud.dataChange.subscribe((value: Exercicio[]) => this.setDataList(value))
  }
  private setDataList(value: Exercicio[]) {
    this.dataList = value;
    this.idsList = this.dataList.map(x => x.Id);
  }
  /**
   * 
   * @param model 
   */
  public onChangeStatus(model:Exercicio) { 
    let msg = [this.msgConfirm.replace('{ano}',model.Ano)];
    this.alert.showAlertConfirm(msg).pipe(take(1)).subscribe({
      next: () => this.confirmed(model),
      error: () => {}
    });
  }
  /**
   * * Esse método é chamado para validar a opção escolhida no alert de Confirmação de deleção.
   * @param retorno 
   */
  private confirmed(model: Exercicio): void {
    this.loading.show = true;
    let modelUpdate = this.command.clone(model);
    modelUpdate.Aberto = !modelUpdate.Aberto;
    this.http.update(modelUpdate, this.crud.module).subscribe({
      next: () => this.updateSuccess(model.Ano),
      error: () => this.updateError(model.Ano)
    });
  }

  /**
   * * Esse método é chamado se o retorno do server for positivo.
   */
  private updateSuccess(ano:string): void {
    this.loading.show = false;
    let msg = [this.msgUpdateSuccess.replace('{ano}',ano)];
    this.alert.showAlertSuccess(msg).pipe(take(1)).subscribe(() => this.ngOnInit());
  }
  
  /**
   * * Esse método é chamado caso tenha tido algum problema de validação no server.
   * @param httpError 
   */
  private updateError(ano:string):void {
    this.loading.show = false;
    let msg = [this.msgUpdateError.replace('{ano}', ano)];
    this.alert.showAlertError(msg).pipe(take(1)).subscribe();
  }
  
  ngOnDestroy(): void {
    this.crud.dataChange.unsubscribe();
  }
}
