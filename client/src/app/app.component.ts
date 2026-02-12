import { CommonModule } from '@angular/common';
import { Component, inject, OnDestroy, OnInit } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MsalBroadcastService, MsalService } from '@azure/msal-angular';
import { EventMessage, EventType, InteractionStatus } from '@azure/msal-browser';
import { filter, Subject, takeUntil } from 'rxjs';
import { AlertComponent } from './shared/alert/alert.component';
import { FooterComponent } from './shared/footer/footer.component';
import { HeaderComponent } from './shared/header/header.component';
import { HeaderService } from './shared/header/header.service';
import { LoadingComponent } from './shared/loading/loading.component';
import { MenuPrincipalComponent } from './shared/menu/menu-principal/menu-principal.component';
import { MenuPrincipalService } from './shared/menu/menu-principal/menu-principal.service';
import { MsalToken } from './shared/msal/msal-token.service';
import { UserService } from './shared/user/user.service';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, HeaderComponent, FooterComponent, MenuPrincipalComponent, LoadingComponent, AlertComponent],
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit, OnDestroy {
  
  title = 'client';
  isIframe = false;
  loginDisplay = false;
  

  private readonly _destroying$ = new Subject<void>();

  private authService = inject(MsalService);
  private msalToken = inject(MsalToken);
  private userService = inject(UserService);
  private msalBroadcastService = inject(MsalBroadcastService);
  protected headerService = inject(HeaderService);
  protected menuPrincipalService = inject(MenuPrincipalService);


  constructor() { }

  ngOnInit(): void {
    this.authService.handleRedirectObservable().subscribe();
    this.setLoginDisplay();

    this.authService.instance.enableAccountStorageEvents();
    this.msalBroadcastService.msalSubject$
    .pipe(
      filter((msg: EventMessage) => msg.eventType === EventType.ACCOUNT_ADDED || msg.eventType === EventType.ACCOUNT_REMOVED),
    )
    .subscribe((result: EventMessage) => {
      if (this.authService.instance.getAllAccounts().length === 0)
        window.location.pathname = "/";
      else
        this.setLoginDisplay();
    });

    this.msalBroadcastService.inProgress$
      .pipe(
        filter((status: InteractionStatus) => status === InteractionStatus.None),
        takeUntil(this._destroying$)
      )
      .subscribe(() => {
        this.setLoginDisplay();
        this.checkAndSetActiveAccount();
      })
  }
  
  setLoginDisplay() {
    this.loginDisplay = this.authService.instance.getAllAccounts().length > 0;
  }

  checkAndSetActiveAccount(){
    let activeAccount = this.authService.instance.getActiveAccount();

    if (!activeAccount && this.authService.instance.getAllAccounts().length > 0) {
      let accounts = this.authService.instance.getAllAccounts();
      this.authService.instance.setActiveAccount(accounts[0]);
      activeAccount = this.authService.instance.getActiveAccount();
    }

    if(activeAccount != null) {
      if(!this.msalToken.getToken()) this.msalToken.setToken(activeAccount);
      if(!this.userService.currentUser()) this.userService.getCurrentUser(activeAccount);
      if(!this.userService.currentUserPic()) this.userService.getCurrentUserPic(activeAccount);
    }
  }

  logout() {
      this.authService.logoutRedirect();
  }

  ngOnDestroy(): void {
    this._destroying$.next(undefined);
    this._destroying$.complete();
  }

  onBodyClick() {
    this.headerService.onUserInfoHide();
    this.menuPrincipalService.onMenuLateralHide();
  }

  onStopPropagation(e: Event) {
    e.stopPropagation();
  }
}
