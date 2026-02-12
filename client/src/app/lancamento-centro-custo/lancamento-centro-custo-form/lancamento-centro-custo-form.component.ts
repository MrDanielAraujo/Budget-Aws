import { CommonModule } from "@angular/common";
import { Component, inject, Input, OnInit } from "@angular/core";
import { FormBuilder, ReactiveFormsModule, Validators } from "@angular/forms";
import { take } from "rxjs";
import { AlertComponent } from "src/app/shared/alert/alert.component";
import { CheckboxFormComponent } from "src/app/shared/form/checkbox-form/checkbox-form.component";
import { ComboboxFormComponent } from "src/app/shared/form/combobox-form/combobox-form.component";
import { CrudForm } from "src/app/shared/form/crud-form";
import { FooterFormComponent } from "src/app/shared/form/footer-form/footer-form.component";
import { HeaderFormComponent } from "src/app/shared/form/header-form/header-form.component";
import { InputFormComponent } from "src/app/shared/form/input-form/input-form.component";
import { Command } from "src/app/shared/global/command";
import { LancamentoCentroCusto } from "../lancamento-centro-custo";
import lancamentoCentroCustoValidator from "./lancamento-centro-custo-form-validator.json";

@Component({
  selector: 'app-exercicio-form',
  standalone: true,
  imports: [CommonModule, HeaderFormComponent, FooterFormComponent, InputFormComponent, CheckboxFormComponent, ReactiveFormsModule, AlertComponent, ComboboxFormComponent],
  templateUrl: './lancamento-centro-custo-form.component.html',
  styleUrls: ['./lancamento-centro-custo-form.component.scss']
})
export class LancamentoCentroCustoFormComponent implements OnInit {
  private fb = inject(FormBuilder);
  protected command = inject(Command);
  protected crud = inject(CrudForm<LancamentoCentroCusto>);
  protected data?:LancamentoCentroCusto;
  @Input() code!: string;

  /**
   * * Esse é o método usado para iniciar o componente.
   */
  ngOnInit(): void {
    this.crud.module = "centroCustoLancamento";
    this.crud.form.errorMessage.validatorMessageForm = lancamentoCentroCustoValidator;
    this.crud.code = this.code;
    this.crud.dataChange.pipe(take(1)).subscribe((value) => this.data = value as LancamentoCentroCusto );
    this.crud.form.formGroup = this.fb.group({
      Id: [''],
      IdLancamentoTipo: ['', [Validators.required]],
      IdCentroCusto: ['', [Validators.required]],
      IdContaContabil: ['', [Validators.required]],
      IdExercicio: ['', [Validators.required]],
      ValoresJaneiro: [''],
      ValoresFevereiro: [''],
      ValoresMarco: [''],
      ValoresAbril: [''],
      ValoresMaio: [''],
      ValoresJunho: [''],
      ValoresJulho: [''],
      ValoresAgosto: [''],
      ValoresSetembro: [''],
      ValoresOutubro: [''],
      ValoresNovembro: [''],
      ValoresDezembro: [''],
    },);    
    this.crud.ngInitForm();
  }
}