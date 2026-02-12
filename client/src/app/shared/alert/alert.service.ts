import { EventEmitter, Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  type!: "success" | "danger" | "primary";
  title: string = "Teste";
  message: string[] = [];
  confirmar: boolean = false;
  private eventClose!:EventEmitter<void>;

  /**
   * 
   * @param msg 
   * @returns 
   */
  public showAlertConfirm(message: string[]): EventEmitter<void> {
    this.eventClose = new EventEmitter<void>();
    this.config("danger", "Informação do Sistema!", message, true);
    return this.eventClose;
  }

  /**
   * 
   * @param message 
   * @returns 
   */
  public showAlertSuccess(message: string[]):EventEmitter<void> {
    this.eventClose = new EventEmitter<void>();
    this.config("success", "Informação do Sistema!", message, false);
    return this.eventClose;
  }

  /**
   * 
   * @param message 
   * @returns 
   */
  public showAlertPrimary(message: string[]):EventEmitter<void> {
    this.eventClose = new EventEmitter<void>();
    this.config("primary", "Informação do Sistema!", message, false);
    return this.eventClose;
  }

  /**
   * 
   * @param httpError 
   * @param alert 
   * @returns 
   */
  public showAlertError(message: string[]):EventEmitter<void> {
    this.eventClose = new EventEmitter<void>();
    console.log(message[0]);
    this.config("danger", "Informação do Sistema!", message, false);
    return this.eventClose;
  }

  private config(type: "success" | "danger" | "primary", title: string, message: string[], confirmar: boolean = false): void {
    this.type = type;
    this.title = title;
    this.message = message;
    this.confirmar = confirmar;
  }

  add(message: string[]) : void {
    this.message = message;
  }

  cancelar(e: Event) {
    e.stopPropagation();
    this.close(false);
  }

  concordar(e: Event) {
    e.stopPropagation();
    this.close(true);
  }

  public close(accept:boolean) {
    this.message = [];
    !this.confirmar ? this.eventClose.next() : accept ? this.eventClose.next(): this.eventClose.error(null);
    this.eventClose.complete();
  }
}