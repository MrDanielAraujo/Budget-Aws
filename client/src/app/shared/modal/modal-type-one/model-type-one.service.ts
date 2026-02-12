import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root'
})
export class ModelTypeOneService {

  title!: string;
  content: string[] = [];

  onGetInformacoes(filtro: string) : string[] {
    if (this.content.length === 0 || filtro === undefined || filtro.trim() === '') return this.content;
    return this.content.filter((v) => {
      return (v.toLowerCase().indexOf(filtro.toLowerCase()) >= 0);
    })
  }

  onClose() {
    this.content = [];
  }

  onStopPropagation(e: Event) {
    e.stopPropagation();
  }
}