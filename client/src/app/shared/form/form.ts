import { inject, Injectable } from "@angular/core";
import { FormControl, FormGroup } from "@angular/forms";
import { ErrorMessage } from "../error/error-message-event";
import { ValidatorError, ValidatorMessageForm } from "../error/validator-message-form";

@Injectable({
  providedIn: 'root'
})
export class Form {
  
  public errorMessage = inject(ErrorMessage);

  formGroup!: FormGroup;

  /**
   * * Esse método coloca os valores de um modelo dentro de um form.
   * @param model 
   * @param form 
   */
  public setInputForm(model: any ):Promise<void> {
    return new Promise(resolve => { 
      this.formGroup.enable();
      Object.keys(model).forEach((key: string) => this.setInput(key,model[key]));
      resolve();
    });
  }
  /**
   * 
   * @param inputName 
   */
  public setInputErros(inputName: string){ 
    this.formGroup.controls[inputName].setErrors({'incorrect': true});
  }
  /**
   * * Já esse método é usado para apresentar os erros do formulário, verificados no front.
   * @returns Observable
   */
  public validateForm(): Promise<string[]> {
    return new Promise((resolve, reject) => {
      let msg: string[] = [];
      Object.keys(this.formGroup.controls).forEach((key: string) => {
        const abstractControl = this.formGroup.controls[key];
        console.log(abstractControl.errors);
        if (abstractControl.errors != null) {
          Object.keys(abstractControl.errors).forEach((erro: string) => 
            msg.push(this.errorMessage.GetMessageError(key,erro))
          )
        }
      });
      (msg.length <= 0) ? resolve([]) : reject(msg);
    });
  }
  /**
   * * Esse método é usado para setar os itens do formulário como o erro que veio do servidor.
   * @param error 
   * @returns Observable
   */
  public validateServerForm(error: ValidatorMessageForm): Promise<string[]>{
    return new Promise((resolve, reject) => {
      let msg: string[] = [];
      error.Errors.forEach((value: ValidatorError) => {
        if (value.InputName?.trim() != "" && value.InputName != null) this.setInputErros(value.InputName);
        msg.push(this.errorMessage.GetMessageError(value.InputName,value.TypeError))
      });
      (msg.length <= 0) ? resolve([]) : reject(msg);
      return {unsubscribe(){},};
    }); 
  }
  /**
   * 
   */
  public disable(): void {
    this.formGroup.disable();
  }
  /**
   * 
   */
  public enable(): void {
    this.formGroup.enable();
  }
  /**
   * 
   */
  public reset(content: string | undefined = undefined): void {
    (content != undefined) ? 
    this.formGroup.reset(content) : 
    this.formGroup.reset(JSON.parse(JSON.stringify(this.values())));
  }
  /**
   * 
   */
  public values(): any {
    return this.formGroup.value; 
  }
  /**
   * 
   */
  public setInput(inputName: string, value: any): void {
    this.formGroup.get(inputName)?.setValue(value)
  }
  /**
   * 
   */
  public getInput(inputName: string): any {
    return this.formGroup.get(inputName)?.value;
  }

  /**
   * 
   * @param name 
   * @returns 
   */
  public getControl(name: string) : FormControl {
    return this.formGroup.get(name) as FormControl;
  }
}