import { EventEmitter, inject, Injectable, Output } from "@angular/core";
import { Observable, take } from 'rxjs';
import { Command } from 'src/app/shared/global/command';
import { AlertService } from "../alert/alert.service";
import { HttpEvent } from '../http/http-event';
import { ImportFile } from "../import/import";
import { LoadingService } from '../loading/loading.service';
import { SessionStorage } from "../session/session-storage";
import { SessionService } from '../session/session.service';
import { Table } from '../table/table';
import { FooterTable } from './../table/footer-table/footer-table';
import { FooterFormBtn } from "./footer-form/footer-form-btn";
import { Form } from "./form";

@Injectable({
  providedIn: 'root'
})
export class CrudList {

  public module!: string;
  public sessionKey!: string;
  public table: Table = new Table();
  public pageSize: number = 5;
  public code!: string | null;
  public deleteList: string[] | undefined = [];

  private msgDelete: string[] = ["Registros excluídos com sucesso!"];
  private msgConfirm: string[] = ["Os registros selecionados serão excluídos, você deseja continuar ?"];
  private msgDeleteNull: string[] = ["Nenhum registro selecionado para exclusão!"];

  public loading = inject(LoadingService);
  private session = inject(SessionService);
  public http = inject(HttpEvent);
  //public formulario = inject(Form);
  public importFile = inject(ImportFile);
  public form = new Form();

  @Output() dataChange!:EventEmitter<any>;
  footerBtn: FooterFormBtn = new FooterFormBtn();

  constructor(
    protected command: Command,
    public alert: AlertService
    // protected tokenService: TokenService,
  ) {}
  /**
   * 
   * @param cache 
   */
  public ngInitList( cache: boolean): Promise<void> {
    return new Promise( resolve => {
      this.dataChange = new EventEmitter();
      this.loading.show = true;
      if(!cache) this.session.Clean(this.sessionKey);
      let storage = this.session.Get(this.sessionKey);
      if(storage.filtros == null) storage.filtros = JSON.stringify(this.form.values());
      this.form.setInputForm( JSON.parse(storage.filtros) ).then(() => this.setInputFormSubscribe(storage));
      resolve();
    });
  }
  /**
   * 
   * @param storage 
   */
  private setInputFormSubscribe(storage: SessionStorage): void {
    this.session.Set(this.sessionKey, storage);
    this.setIconSort();
    this.ngLoadList();
  }
  /**
   * 
   */
  private ngLoadList(): void {
    this.loading.show = true;
    console.log(this.form.formGroup.value);
    this.http.listFilter(this.form.formGroup.controls, this.module).subscribe( {
      next: (data: Table): void => this.listFilterSuccess(data),
      error: (error: any) => this.listFilterError(error),
    });
  }
  /**
   * 
   * @param error 
   */
  private listFilterError(error: any): void {
    this.alert.showAlertError(error).pipe(take(1)).subscribe(() => this.loading.show = false)
  }
  /**
   * 
   * @param data 
   */
  private listFilterSuccess(data: Table): void {
    this.table = data;
    this.dataChange.emit(this.table.Data);
    let storage = this.session.Get(this.sessionKey);
    storage.filtros = JSON.stringify(this.form.values());
    this.session.Set(this.sessionKey, storage);
    this.loading.show = false;
  }
  /**
   * 
   * @param page 
   */
  public onPagination(e: Event, value: any): void {
    let page = value as number;
    this.form.setInput('PageNow',page);
    this.onCheckedCleanAll();
    this.ngLoadList();
  }
  /**
   * Esse método é chamado quando clicado em um item da lista.
   * @param code : string => código de identificação do registro.
   */
  public onSelectItem(e: Event, value: any, path: string | undefined = undefined): void {
    console.log(value);
    let code = value as string | string[];
    this.loading.show = true;
    let parm: string[] = [];
    (typeof code == "number") ? parm.push(code) : parm = [...code];
    if(path == undefined) path = `${this.module}/view`;
    this.command.navigate(path, parm);
  }
  /**
   * Esse é um método para trabalhar os itens da lista 
   * @param search 
   * @param event 
   */
  public onSetSortField(search: string, event: Event):void {
    event.stopPropagation();
    this.setSortField(search).pipe(take(1)).subscribe(() => this.ngLoadList());
  }
  /**
   * 
   * @param search 
   * @returns 
   */
  private setSortField(search: string ) : Observable<any> {
    return new Observable(observer => {
      let search1 = `+${search}`;
      let search2 = `-${search}`;
      let valor = this.form.getInput('Sort').split(",");
      let novo = valor.filter( (key: string) => key != search && key != search1 && key != search2 && key.trim() != '');
      var selector = `i[data-icon="${search}"]`;
      const target = document.querySelector(selector) as Element;
      if(valor.indexOf(search1) >= 0) {
        novo.push(search2);
        target.className = "fa-solid fa-arrow-up-long";
      }
      else if(valor.indexOf(search2) >= 0) {
        target.className = "fa-solid fa-arrow-down-up-across-line";
      }
      else {
        novo.push(search1);
        target.className = "fa-solid fa-arrow-down-long";
      }
      this.form.setInput('Sort', novo.join(","));
      observer.next();
      return {unsubscribe() {},};
    });
  }
  /**
   * 
   * @param form 
   * @returns 
   */
  private setIconSort(): void {
    if(this.form.getInput('Sort') == undefined || this.form.getInput('Sort') == null) return;
    let columns = this.form.getInput('Sort').split(",");
    for (const i in columns) {
      let title = columns[i].substring(1);
      var selector = `i[data-icon="${title}"]`;
      const target = document.querySelector(selector) as Element;
      if(columns[i].startsWith("+")) target.className = "fa-solid fa-arrow-down-long"; 
      if(columns[i].startsWith("-")) target.className = "fa-solid fa-arrow-up-long";
    }
  }
  /**
   * 
   * @param data 
   */
  public onImportFile(e: Event, value: any): void {
    this.loading.show = true;
    this.importFile.file(e, this.module).subscribe({
      next: (): void => this.ngLoadList(),
      error: () => this.loading.show = false,
    })
  }
  /**
   * * Esse método é responsável por toda a parte de exclusão de uma registro.
   */
  public onDelete(e: Event, value: any):void {
    let ids = this.deleteList!;
    this.loading.show = true; 
    (ids.length <= 0) ? 
    this.alert.showAlertError(this.msgDeleteNull).pipe(take(1)).subscribe(() => this.loading.show = false) :
    this.alert.showAlertConfirm(this.msgConfirm).pipe(take(1)).subscribe(() => this.deleteConfirmed(ids));
  }
  
  /**
   * * Esse método é chamado para fazer a exclusão do registro.
   */
  private deleteConfirmed(ids: string[]):void {
    this.http.delete(ids.join(','), this.module).subscribe({
      next: () => this.deleteSuccess(),
      error: (error: any) => this.deleteError(error)
    });
  }
  /**
   * * Esse método é chamado caso tenha algum problema em apagar o registro.
   * * Ele ira apresentar uma janela de erro com o resultado que aconteceu.
   * @param error 
   */
  private deleteError(error: any) {
    this.alert.showAlertError(error).pipe(take(1)).subscribe(() => this.loading.show = false);
  }
  /**
   * * Esse método é chamado quando a deleção aconteceu com sucesso.
   * * Também irá apresentar uma janela com a mensagem que deu tudo certo e depois voltará para a lista.
   */
  private deleteSuccess(): void {
    this.alert.showAlertSuccess(this.msgDelete).pipe(take(1)).subscribe(() => this.ngLoadList());
  }

  //this.dataList?.map( m => m.Id)
  public onDeleteAll(dataList?: string[]){
    this.deleteList = (this.onCheckedAll(dataList?.length))? [] : dataList;
  }

  //this.dataList?.length
  public onCheckedAll(length?: number): boolean {
    var teste = this.deleteList?.length ?? 0;
    return ( teste <= 0) ? false : length == this.deleteList?.length;
  }

  public onCheckedCleanAll(): void {
    this.deleteList = [];
  }

  public onChecked(id: string): boolean {
    return this.deleteList?.find( currentValue =>  currentValue === id ) != undefined;
  }

  public onCheckboxChanged(id: string, event: Event):void {
    event.stopPropagation();
    this.deleteList?.find( currentValue =>  currentValue === id ) == undefined ? 
    this.deleteList?.push(id) :
    this.deleteList = this.deleteList.filter( (currentValue) => currentValue !== id);
  }

  public onExportExcel(e: Event, value: any): void {
    this.loading.show = true;
    let link = document.createElement('a');
    link.href = this.http.exportExcel(this.module);
    link.click();
    this.loading.show = false;
  }

  public onBtn(footerTable: FooterTable): void {
    this[footerTable.type](footerTable.e, footerTable.value);
  }
}