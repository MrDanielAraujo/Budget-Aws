import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { AlertService } from "../alert/alert.service";

@Injectable({
  providedIn: 'root'
})
export class Command {
  constructor(
    private readonly router: Router, private alert: AlertService
  ) {}
  
  //variable control dev Mode.
  IsDevMode : boolean = window.location.hostname == "localhost";
  
  //variable control Url call the server.
  UrlPathApi: string = this.IsDevMode
  ? `http://${window.location.hostname}:3000/api`
  : `https://api.${window.location.hostname}/api`;
  
  //variable control load Screen 
  LoadScreen: boolean = false;

  //variable contro name storage of browser.
  Storage: string = "storage";
  
  Session = {
    /**
     * This method creates a session object based on the module name it is accessing. 
     * @param modulo => Name of the module being accessed at the moment. 
     */
    New : (modulo: string) => {
      let storage = new Storage();
      sessionStorage.setItem(modulo, JSON.stringify(storage));
    },
    /**
     * This method returns the session object that the current module is using.
     * @returns => A Storage Object.
     */
    //Get : (modulo: string): Storage => {
      //return JSON.parse(sessionStorage.getItem(modulo)) as Storage;
    //},
    /**
     * Removes the object from the session 
     */
    Clean: (modulo: string): void => {
      sessionStorage.removeItem(modulo);
    },
    /**
     * Change the value of the object stored in the session.
     * @param modulo => Name of the module being accessed at the moment.
     * @param storage => Object to change in the session.
     */
    Set: (modulo: string, storage: Storage): void => {
      sessionStorage.setItem(modulo, JSON.stringify(storage));
    }
  };

  clone<T>(model:T):T {
    return JSON.parse(JSON.stringify(model)) as T;
  }
  /**
   * 
   * @param path 
   * @param parameters 
   */
  navigate(path: string | null, parameters: any[] = []): void {
    const command = parameters.length === 0 ? [path] : [path, ...parameters];
    console.log("command => ", command);
    this.router.navigate(command, { skipLocationChange: true }).then();
  }

  /**
   * 
   * @param content 
   * @returns 
   */
  formatData(content: string | null): string | null {
    if (content == null) return content;
    const valor = content.split("T")[0].split("-");
    const result = " " + valor[2] + "/" + valor[1] + "/" + valor[0];
    return result;
  }

  /**
   * 
   * @param a 
   * @returns 
   */
  replaceDotForComa(a: number): string {
    return a.toString().replace(".", ",");
  }

  /**
   * 
   * @param a 
   * @returns 
   */
  replaceComaForDot(a: string): number {
    return +a.toString().replace(",", ".");
  }

  /**
   * 
   * @param value 
   * @returns 
   */
  isValidDataBrasil(value: any): boolean {
    const regex = /^(0[1-9]|[12][0-9]|3[01])\/(0[1-9]|1[0-2])\/\d{4}$/;
    return regex.test(value);
  }

  /**
   * 
   * @param dataBrasil 
   * @returns 
   */
  formatDataDb(dataBrasil: string): string {
    return dataBrasil.replace(/(\d{2})(\d{2})(\d{4})/, "$3-$2-$1");
  }

  /**
   * 
   * @param code 
   * @param message 
   * @param success 
   * @returns 
   */
  //modalResult( code: number, message: string[], success: boolean ): Observable<any> {
  //  return this.modal.showAlerta(code, message, success).asObservable();
  //}

  /**
   * 
   * @param inputDate 
   * @returns 
   */
  converterParaDataTime(inputDate: string) {
    var dateParts = inputDate.split("/");
    var convertedDate = new Date(+dateParts[2], +dateParts[1] - 1, +dateParts[0]);
    var formattedDate = convertedDate.toISOString().split("T")[0] + "T00:00:00";
    return formattedDate;
  }

  /**
   * 
   * @param data 
   * @returns 
   */
  formatarData(data: string | number | Date ): string {
    const dataFormatada = new Date(data).toLocaleDateString("pt-BR", {
      timeZone: "UTC",
    });
    return dataFormatada.toString();
  }

  /**
   * This method exchanges the point value for virgula, BR format of numeric value.
   * @param event
   */
  onConvertDotForComa(event: any): void {
    event.target.value = (event.target.value as string).replaceAll(".", ",");
  }

  
}
