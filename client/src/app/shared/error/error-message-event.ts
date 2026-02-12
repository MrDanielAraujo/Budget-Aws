import { Injectable } from "@angular/core";
import { ValidatorMessageForm } from "./validator-message-form";

@Injectable({
  providedIn: 'root'
})
export class ErrorMessage {

  public validatorMessageForm!: ValidatorMessageForm;

  /**
   * 
   * @param key 
   * @param error 
   * @returns 
   */
  public GetMessageError(key: string | null, error: string): string {
    let result = this.validatorMessageForm.Errors.find(({ InputName , TypeError }) => InputName == key && TypeError.toLowerCase() == error.toLowerCase());
    return (result) ? result.Message : (key == '' || key == null) ? `O sistema está apresentando o seguinte error: ${error}` : `O campo ${key} contem o seguinte erro => "${error}".`
  }

}