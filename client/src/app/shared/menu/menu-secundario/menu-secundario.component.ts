import { CommonModule } from "@angular/common";
import { Component, EventEmitter, inject, OnInit, Output } from "@angular/core";
import { FormBuilder } from "@angular/forms";
import { take } from "rxjs";
import { ComboSeparador } from "src/app/combo-separador/combo-separador";
import { AlertService } from "../../alert/alert.service";
import { Form } from "../../form/form";
import { Command } from "../../global/command";
import { HttpEvent } from "../../http/http-event";
import { Table } from "../../table/table";

@Component({
  selector: 'app-menu-secundario',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './menu-secundario.component.html',
  styleUrls: ['./menu-secundario.component.scss']
})
export class MenuSecundarioComponent implements OnInit {
  
  private http = inject(HttpEvent);
  public module!: string;
  public form = inject(Form);
  private fb = inject(FormBuilder);

  constructor(
    protected command: Command,
    protected alert: AlertService
    // protected tokenService: TokenService,
  ) {}

  public menuSecundario: ComboSeparador[] = [];   

  @Output() eventClick: EventEmitter<any> = new EventEmitter<any>();

  ngOnInit(): void {
    this.module = "ComboSeparador";
    this.form.formGroup = this.fb.group({
      Nome: [null],
      Id: [null],
      PageNow: [0],
      PageSize: [100],
      Pagination: [true],
      Sort: [''] 
    });
    this.http.listFilter(this.form.formGroup.controls, this.module).subscribe( {
      next: (data: Table): void => this.listFilterSuccess(data.Data),
      error: (error: any) => this.listFilterError(error),
    });
  }
  public click(id: string, nome: string): void {
    this.eventClick.emit({id, nome});
  }
  /**
   * 
   * @param error 
   */
  private listFilterError(error: any): void {
    this.alert.showAlertError(error).pipe(take(1)).subscribe()
  }
  /**
   * 
   * @param data 
   */
  private listFilterSuccess(data: ComboSeparador[] ): void {
    this.menuSecundario = data;
  }

}