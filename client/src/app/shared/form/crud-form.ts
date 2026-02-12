import { HttpErrorResponse } from "@angular/common/http";
import { EventEmitter, inject, Injectable, Output } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { Observable, take } from "rxjs";
import { AlertService } from "../alert/alert.service";
import { Command } from "../global/command";
import { HttpEvent } from "../http/http-event";
import { LoadingService } from "../loading/loading.service";
import { SessionService } from "../session/session.service";
import { FooterFormBtn } from "./footer-form/footer-form-btn";
import { Form } from "./form";

@Injectable({
  providedIn: 'root'
})
export class CrudForm<T> { 
  
  code!: string | null;
  module!: string;
  submitted: boolean = false;
  sessionKey!: string;

  @Output() dataChange = new EventEmitter();
  footerBtn: FooterFormBtn = new FooterFormBtn();

  protected loading = inject(LoadingService);
  private session = inject(SessionService);
  private http = inject(HttpEvent);
  public form = new Form();

  private msgAdd: string[] = ["Registro incluído com sucesso!"];
  private msgUpdate: string[] = ["Registro alterado com sucesso!"];
  private msgDelete: string[] = ["Registro excluído com sucesso!"];
  private msgConfirm: string = "O registro {code} será excluído, você deseja continuar ?";

  constructor(
    protected command: Command,
    protected alert: AlertService
  ){}

  /**
   * * Método que inicia o crud.
   */
  ngInitForm() {
    this.loading.show = true; 
    this.http.loadByCode(this.code, this.module).subscribe({
      next: (model:T) => this.loadByCodeSuccess(model), 
      error: (error: any) => this.loadByCodeError(error),
    });
  }
  /**
   * * Esse método ira apresentar uma mensagem com o erro ocorrido. 
   * @param error 
   */
  private loadByCodeError(error: any): void {
    const message = this.http.codigoHttpStatus(error.status, error.message || error.error); 
    this.alert.showAlertError([message]).pipe(take(1)).subscribe(() => this.onBack());
  }
  /**
   * * Esse método prepara a informação para ser apresentado na tela
   * @param model 
   */
  private loadByCodeSuccess(model:T):void { 
    this.dataChange.emit(model);
    this.form.setInputForm(model).then(() => this.setInputFormSubscribe());
  }
  /**
   * * Esse método é chamado depois de colocar os valores no formulário
   * * para reiniciar o form. 
   */
  private setInputFormSubscribe(): void  {
    if (this.code != '0') this.form.disable(); 
    this.form.reset();
    this.submitted = false;
    this.footerBtn.updateFooterBtnShow(this.code, true); 
    this.loading.show = false;
  }
  /**
   * * Esse método é usado para navegar para a Lista.
   * * Chamando um endpoint onde se inicia o modulo.
   */
  public onBack():void {
    this.loading.show = false;
    this.command.navigate(this.module, [true]);
  }
  /**
   * * Esse método é usado para enviar as informações para o servidor.
   */
  public onSubmit():void {
    if(this.alert.message.length > 0) {
      this.alert.close(false);
      return;
    }
    if(this.loading.show == true) return;
    this.submitted = true; 
    this.loading.show = true; 
    this.form.validateForm().then( 
      () => this.validateFormSuccess(), 
      (error: string[]) => this.validateFormError(error)
    )  
  }
  /**
   * * Esse método é chamado para apresentar o erro e para a tela de loading.
   * @param error 
   */
  private validateFormError(error: string[]): void { 
    this.alert.showAlertError(error).pipe(take(1)).subscribe(() => this.loading.show = false);
  }
  /**
   * * Este método é chamado para enviar o formulário para ser gravado no servidor.
   */
  private validateFormSuccess(): void {
    this.save(this.form.formGroup, this.code).subscribe({ 
      next: () => this.saveSuccess(), 
      error: (httpError: HttpErrorResponse) => this.saveError(httpError)
    });
  }
  /**
   * * Esse método é chamado caso tenha tido algum problema de validação no server.
   * @param httpError 
   */
  private saveError(httpError: HttpErrorResponse):void {
    this.form.validateServerForm(httpError.error).then(  
      () => console.log("nenhum erro reportado na lista!"),
      (error: string[]) => this.ValidateServerFormError(error)
    )
  }
  /**
   * * Esse código é responsável por apresentar a tela de erro e remover o loading.
   * @param error 
   */
  private ValidateServerFormError(error: string[]): void {
    this.alert.showAlertError(error).pipe(take(1)).subscribe(() => this.loading.show = false);
  }
  /**
   * * Esse método é chamado se o retorno do server for positivo.
   */
  private saveSuccess(): void {
    this.alert.showAlertSuccess( this.code != '0' ? this.msgUpdate : this.msgAdd).pipe(take(1)).subscribe(() => this.ngInitForm());
  }
  /**
   * * Esse método serve para chamar o método de Update ou Create. 
   * @param form 
   * @param code 
   * @returns Observable
   */
  private save(form: FormGroup, code: string | null): Observable<any> {
    return code != '0' ? this.http.update(form, this.module) : this.http.create(form, this.module);
  }
  /**
   * * Esse método é chamado pelo botão de editar.
   * @returns 
   */
  public onEdit() : void {
    this.form.enable();
    this.footerBtn.updateFooterBtnShow(this.code, false);
    let storage = this.session.Get(this.sessionKey);
    storage.session = JSON.stringify(this.form.values());
    this.session.Set(this.sessionKey, storage);
  }
  /**
   * * Esse método é chamado pelo botão de cancelar.
   */
  public onCancel(): void {
    this.form.reset(JSON.parse(this.session.Get(this.sessionKey).session));
    this.form.disable();
    this.footerBtn.updateFooterBtnShow(this.code, true);
  }
  /**
   * * Esse método é responsável por toda a parte de exclusão de uma registro.
   */
  public onDelete():void {
    let msg = [this.msgConfirm.replace('{code}',this.code?.toString() ?? '0')];
    this.alert.showAlertConfirm(msg).pipe(take(1)).subscribe({
      next:() => this.deleteConfirmed(),
      error:() => {}
    });
  }
  /**
   * * Esse método é chamado para fazer a exclusão do registro.
   */
  private deleteConfirmed():void {
    this.loading.show = true;
    this.http.delete(this.code, this.module).subscribe({
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
    this.alert.showAlertSuccess(this.msgDelete).pipe(take(1)).subscribe(() => this.onBack());
  }

  public checkInputError(nome: string): boolean {
    return this.form.getControl(nome).invalid && (this.submitted || this.form.getControl(nome).touched);
  }
}