import { inject, Injectable } from "@angular/core";
import { Router } from '@angular/router';
import { SessionStorage } from "../../session/session-storage";
import { SessionService } from "../../session/session.service";

@Injectable({
  providedIn: 'root'
})
export class MenuPrincipalService {

  private session = inject(SessionService);
  private router = inject(Router);
  public module!: string;

  onMenuLateralShow(e: Event): void {
    e.stopPropagation();
    const element = document.getElementById('menuPrincipal');
    element?.classList.contains('display-none')
      ? element?.classList.remove('display-none')
      : element?.classList.add('display-none');
  }

  onMenuLateralHide() {
    const element = document.getElementById('menuPrincipal');
    element?.classList.add('display-none');
  }

  onMenuLateralSubItem(e: Event): void {
    e.stopPropagation();
  }

  navigate(path: string, modulo?: string): void {
    if (modulo != undefined) {
      let storage = this.session.Get(modulo);
      Object.keys(storage).forEach(key => {
        type sessionStorageKey = keyof SessionStorage;
        if(key.toLowerCase() != "configTable".toLowerCase())  storage[key as sessionStorageKey] = null;
      });
      this.session.Set(modulo, storage);
    }
    this.router.navigate([path], { skipLocationChange: true }).then();

    this.onMenuLateralHide();
    //const sidenav = (<HTMLInputElement>document.getElementById("menuPrincipal")).classList;
    //sidenav.contains("sidenav-show") ? sidenav.remove("sidenav-show") : sidenav.add("sidenav-show");
  }
}