import { CommonModule } from '@angular/common';
import { Component, inject, Input, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { AlertComponent } from 'src/app/shared/alert/alert.component';
import { CheckboxFormComponent } from 'src/app/shared/form/checkbox-form/checkbox-form.component';
import { ComboboxFormComponent } from 'src/app/shared/form/combobox-form/combobox-form.component';
import { Combobox2FormComponent } from 'src/app/shared/form/combobox2-form/combobox2-form.component';
import { CrudForm } from 'src/app/shared/form/crud-form';
import { FooterFormComponent } from 'src/app/shared/form/footer-form/footer-form.component';
import { HeaderFormComponent } from 'src/app/shared/form/header-form/header-form.component';
import { InputDisplayFormComponent } from 'src/app/shared/form/input-display-form/input-display-form.component';
import { InputFormComponent } from 'src/app/shared/form/input-form/input-form.component';
import { Command } from 'src/app/shared/global/command';
import { CentroCustoSituacao } from '../centro-custo-situacao';
import centroCustoSituacaoValidator from './centro-custo-situacao-form-validator.json';

@Component({
  selector: 'app-centro-custo-situacao-form',
  standalone: true,
  imports: [CommonModule, HeaderFormComponent, FooterFormComponent, InputFormComponent, CheckboxFormComponent, ComboboxFormComponent, ReactiveFormsModule, AlertComponent, InputDisplayFormComponent, Combobox2FormComponent],
  templateUrl: './centro-custo-situacao-form.component.html',
  styleUrls: ['./centro-custo-situacao-form.component.scss']
})
export class CentroCustoSituacaoFormComponent  implements OnInit{
  private fb = inject(FormBuilder);
  protected command = inject(Command);
  protected crud = inject(CrudForm<CentroCustoSituacao>);
  protected data?:CentroCustoSituacao;
  @Input() code!: string;
  /**
   * Esse é o método usado para iniciar o componente.
   */
  ngOnInit(): void {
    this.crud.module = "centroCustoSituacao";
    this.crud.form.errorMessage.validatorMessageForm = centroCustoSituacaoValidator;
    this.crud.code = this.code;
    this.crud.dataChange.pipe(take(1)).subscribe((value) => this.data = value as CentroCustoSituacao );
    this.crud.form.formGroup = this.fb.group({
      Id:[''],
      IdExercicio:['', [Validators.required]],
      IdCentroCusto:['', [Validators.required]],
      IdCentroStatus:['', [Validators.required]],
      IdCentroCustoUsuario:[''],
      Janeiro:['', [Validators.required]],
      Fevereiro:['', [Validators.required]],
      Marco:['', [Validators.required]],
      Abril:['', [Validators.required]],
      Maio:['', [Validators.required]],
      Junho:['', [Validators.required]],
      Julho:['', [Validators.required]],
      Agosto:['', [Validators.required]],
      Setembro:['', [Validators.required]],
      Outubro:['', [Validators.required]],
      Novembro:['', [Validators.required]],
      Dezembro:['', [Validators.required]],
    });
    this.crud.ngInitForm();
  }
}
