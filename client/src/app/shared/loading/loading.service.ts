import { EventEmitter, Injectable, Output } from "@angular/core";


@Injectable({
  providedIn: 'root'
})
export class LoadingService {

  private _show: boolean = false;

  @Output() eventClose = new EventEmitter();
  
  
  get show():boolean {
    return this._show;
  }

  set show(value: boolean) {
    this._show = value;
    if(!value) this.eventClose.emit();
  }
  
}