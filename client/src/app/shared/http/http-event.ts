import { HttpClient, HttpErrorResponse, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { FormGroup } from "@angular/forms";
import { catchError, Observable, take, throwError } from "rxjs";
import { Command } from "../global/command";
import { Table } from "../table/table";
import httpCode from "./http-code.json";

@Injectable({
  providedIn: 'root'
})
export class HttpEvent {
  
  constructor(
    public http: HttpClient,
    protected command: Command,
  ) {
  
  }

  private headersJson = new HttpHeaders({
    // 'Authorization' : 'Bearer ' + this.tokenService.getToken(),
    'Content-Type' : 'application/json'
  });

  private headersStream = new HttpHeaders({
    // 'Authorization' : 'Bearer ' + this.tokenService.getToken(),
    'Content-Type' : 'application/octet-stream'
  });

  private headersOffice = new HttpHeaders({
    // 'Authorization' : 'Bearer ' + this.tokenService.getToken(),
    'Content-Type' : 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet'
  });
  

  public options = { headers: this.headersJson };
  
  /**
   * Esse método é utilizado para buscar no servidor, utilizando um parâmetro de código (chave primaria). 
   * @param code 
   * @param module
   * @returns 
   */
  public loadByCode(code: string | null, module: string): Observable<any> {
    let url = (code == '0') ? `${this.command.UrlPathApi}/${module}` : `${this.command.UrlPathApi}/${module}/${code}`;
    return this.http.get<any>(url, this.options).pipe(take(1), catchError(this.handleError));
  }
  /**
   * 
   * @param form 
   * @param module 
   * @returns 
   */
  public update(form: any, module: string): Observable<any> {
    let value = (form instanceof FormGroup) ? form.value : form;
    return this.http.put(`${this.command.UrlPathApi}/${module}`, value, this.options).pipe(take(1), catchError(this.handleError));
  }

  /**
   * 
   * @param form 
   * @param module 
   * @returns 
   */
  public updateAll(module: string): Observable<any> {
    return this.http.put(`${this.command.UrlPathApi}/${module}`, null, this.options).pipe(take(1), catchError(this.handleError));
  }
  /**
   * 
   * @param form 
   * @param module 
   * @returns 
   */
  public create(form: FormGroup, module: string): Observable<any> {
    return this.http.post(`${this.command.UrlPathApi}/${module}`, form.value, this.options).pipe(take(1), catchError(this.handleError));
  }
  /**
   * 
   * @param code 
   * @param module 
   * @returns 
   */
  public delete(code: string | null, module: string) {
    return this.http.delete(`${this.command.UrlPathApi}/${module}/${code}`, this.options).pipe(take(1), catchError(this.handleError));
  }
  /**
   * 
   * @param code 
   * @param module 
   * @returns 
   */
  public deleteMultiple(code: number[] | null, module: string) {
    this.options
    return this.http.delete(`${this.command.UrlPathApi}/${module}`, this.options).pipe(take(1), catchError(this.handleError));
  }
  /**
   * 
   * @param form 
   * @param module 
   * @returns 
   */
  public import(form: FormData, module: string): Observable<any> {
    return this.http.post(`${this.command.UrlPathApi}/${module}/import`, form).pipe(take(1), catchError(this.handleError));
  }
  /**
   * 
   * @returns 
   */
  public list(module: string) {
    return this.http.get<Table>(`${this.command.UrlPathApi}/${module}/lista`, this.options).pipe(take(1), catchError(this.handleError));
  }
  /**
   * 
   * @param lista 
   * @param module 
   * @returns 
   */
  public listFilter(lista: any, module: string) {
    return this.http.get<Table>(`${this.command.UrlPathApi}/${module}/Filtrar?${this.querySelect(lista)}`, this.options).pipe(take(1), catchError(this.handleError));
  }

  /**
   * 
   * @param lista 
   * @param module 
   * @returns 
   */
  public listFilterGeneric(lista: any, module: string, method: string) {
    return this.http.get<any>(`${this.command.UrlPathApi}/${module}/${method}?${this.querySelect(lista)}`, this.options).pipe(take(1), catchError(this.handleError));
  }
  /**
   * Esse método é utilizado para buscar no servidor, utilizando um parâmetro de código (chave primaria). 
   * @param code 
   * @param module
   * @returns 
   */
  public exportExcel(module: string): string {
    return `${this.command.UrlPathApi}/${module}/ExportToExcel`
  }
  /**
   * 
   * @param lista 
   * @returns 
   */
  private querySelect(lista: any): string {
    return Object.keys(lista).filter(function(key) {
      return (lista[key].value != null);
    }).map(function(key) {
      return `${key}=${lista[key].value}`;
    }).join("&");
  }
  /**
   * 
   * @param codigo 
   * @param mensagem 
   * @returns 
   */
  public codigoHttpStatus(codigo:number, mensagem: string | any): string {
    let result = httpCode.find(({code}) => code == codigo);
    return (result) ? result.description : mensagem;
  }
  /**
   * Esse código serve para levantar o erro e enviar para ser mostrado no fronte.
   * @param httpError 
   * @returns 
   */
  private handleError(httpError: HttpErrorResponse) {
    return throwError(() => httpError);
  } 
}