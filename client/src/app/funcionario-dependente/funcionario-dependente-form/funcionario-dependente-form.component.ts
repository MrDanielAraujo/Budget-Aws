import { CommonModule } from '@angular/common';
import { Component, inject, Input, OnInit } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { take } from 'rxjs';
import { AlertComponent } from 'src/app/shared/alert/alert.component';
import { CheckboxFormComponent } from 'src/app/shared/form/checkbox-form/checkbox-form.component';
import { ComboboxFormComponent } from 'src/app/shared/form/combobox-form/combobox-form.component';
import { CrudForm } from 'src/app/shared/form/crud-form';
import { FooterFormComponent } from 'src/app/shared/form/footer-form/footer-form.component';
import { HeaderFormComponent } from 'src/app/shared/form/header-form/header-form.component';
import { InputFormComponent } from 'src/app/shared/form/input-form/input-form.component';
import { Command } from 'src/app/shared/global/command';
import { FuncionarioDependente } from '../funcionario-dependente';
import funcionarioDependenteValidator from './funcionario-dependente-form-validator.json';

@Component({
  selector: 'app-funcionario-dependente-form',
  standalone: true,
  imports: [CommonModule, HeaderFormComponent, FooterFormComponent, InputFormComponent, CheckboxFormComponent, ComboboxFormComponent, ReactiveFormsModule, AlertComponent],
  templateUrl: './funcionario-dependente-form.component.html',
  styleUrls: ['./funcionario-dependente-form.component.scss']
})
export class FuncionarioDependenteFormComponent implements OnInit{
  private fb = inject(FormBuilder);
  protected command = inject(Command);
  protected crud = inject(CrudForm<FuncionarioDependente>);
  protected data?:FuncionarioDependente;
  @Input() code!: string;
  /**
   * Esse é o método usado para iniciar o componente.
   */
  ngOnInit(): void {
    this.crud.module = "funcionarioDependente";
    this.crud.form.errorMessage.validatorMessageForm = funcionarioDependenteValidator;
    this.crud.code = this.code;
    this.crud.dataChange.pipe(take(1)).subscribe((value) => this.data = value as FuncionarioDependente );
    this.crud.form.formGroup = this.fb.group({
      Id:[null],
      Nome:[null, [Validators.required]],
      IdFuncionario: [null],
      PlanoSaudeValor: [null]
    });
    this.crud.ngInitForm();
  }
}
