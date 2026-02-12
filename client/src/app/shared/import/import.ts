import { inject, Injectable } from "@angular/core";
import { Observable, Subscriber, take } from "rxjs";
import { AlertService } from "../alert/alert.service";
import { HttpEvent } from "../http/http-event";
import { LoadingService } from "../loading/loading.service";

@Injectable({
  providedIn: 'root'
})
export class ImportFile {

  public loading = inject(LoadingService);
  private http = inject(HttpEvent);
  protected alert = inject(AlertService);

  /**
   * 
   * @param data 
   * @returns 
   */
  public file(data: any, module:string): Observable<any> {
    return new Observable(observer => {
      const files = data.target.files as File[];
      if(files.length <= 0) return;
      //this.loading.show = true;
      let formData = new FormData();
      formData.append('files', files[0], files[0].name);
      this.http.import(formData, module).subscribe({
        next: () => this.importSuccess(observer),
        error: (error: any) => this.importError(error, observer)
      })
    return {unsubscribe() {},};
    }).pipe(take(1));
  }
  /**
   * 
   */
  private importSuccess(observer: Subscriber<null>): void {
    this.alert.showAlertSuccess(['Import concluído com Sucesso!!']).pipe(take(1)).subscribe(() => {
      observer.next();
    })
  }
  /**
   * 
   * @param error 
   */
  private importError(error: any, observer: Subscriber<null>): void {
    this.alert.showAlertError(['Erro ao fazer a importação']).pipe(take(1)).subscribe(() => {
      observer.error();
    });
  }
}