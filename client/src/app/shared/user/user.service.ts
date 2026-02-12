import { HttpClient } from "@angular/common/http";
import { inject, Injectable, signal } from "@angular/core";
import { DomSanitizer, SafeResourceUrl } from "@angular/platform-browser";
import { AccountInfo } from "@azure/msal-browser";
import { catchError, of, take } from "rxjs";
import { environment } from "src/environments/environment";
import { MsalToken } from "../msal/msal-token.service";
import { User } from "./user";

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private http = inject(HttpClient);
  public readonly currentUser = signal<User | null>(null);
  public readonly currentUserPic = signal<SafeResourceUrl | null>(null);
  private domSanitizer = inject(DomSanitizer);
  private tokenService = inject(MsalToken);

  getCurrentUser(accountInfo: AccountInfo): void {
    if (!this.currentUser()){
      const localStorageKey = `user.info.${accountInfo.idTokenClaims?.aud}`;
      var userInfo = localStorage.getItem(localStorageKey);
      (userInfo != null) 
      ? this.setCurrentUser(JSON.parse(userInfo) as User , localStorageKey) 
      : this.http.get<User>(environment.apiConfig.uri).pipe(take(1)).pipe(
          catchError(_ => of(this.msalTokenToUserInfo()))
        ).subscribe(user => {
          this.setCurrentUser(user , localStorageKey);
        });
    }  
  }

  private setCurrentUser(user: User, localStorageKey: string ):void { 
    localStorage.setItem(localStorageKey, JSON.stringify(user));
    this.currentUser.set(user)
  }

  private msalTokenToUserInfo(): User {
    const tokenDecode = this.tokenService.getTokenDecode();
    const givenName = tokenDecode.preferred_username.split('.')[0];
    const surname = tokenDecode.preferred_username.split('.')[1].split('@')[0];
    
    var user = new User();
        user.userPrincipalName = tokenDecode.preferred_username;
        user.givenName = `${givenName.charAt(0).toUpperCase()}${givenName.slice(1)}`;
        user.surname = `${surname.charAt(0).toUpperCase()}${surname.slice(1)}`;
        user.mail = tokenDecode.preferred_username;
    
    return user;
  }

  getCurrentUserPic(accountInfo: AccountInfo): void {
    if (!this.currentUserPic()){
      const localStorageKey = `user.info.pic.${accountInfo.idTokenClaims?.aud}`;
      var userInfoPic = localStorage.getItem(localStorageKey);
      
      (userInfoPic != null) ?
        this.currentUserPic.set(this.getUrlPic(this.dataURItoBlob(userInfoPic), localStorageKey)) :
        this.http.get(environment.apiConfig.picUri, { responseType: 'blob' }).pipe(take(1)).pipe(
          catchError(_ => of(null))
        ).subscribe((response) => {
          this.currentUserPic.set(this.getUrlPic(response, localStorageKey));
        });
    }  
  }

  //Todo levar esse método para o arquivo common.
  /**
   * 
   * @param dataURI 
   * @returns 
   */
  dataURItoBlob(dataURI: string): Blob {
    var byteString = (dataURI.split(',')[0].indexOf('base64') >= 0) ? atob(dataURI.split(',')[1]) : unescape(dataURI.split(',')[1]);
    var mimeType = dataURI.split(',')[0].split(':')[1].split(';')[0];
    var typedArray = new Uint8Array(byteString.length);

    for (var i = 0; i < byteString.length; i++) {
        typedArray[i] = byteString.charCodeAt(i);
    }
    return new Blob([typedArray], {type: mimeType});
  }

  //Todo Levar esse método para uma classe common.
  /**
   * 
   * @param blob 
   * @param localStorageKey 
   * @returns 
   */
  private getUrlPic(blob: Blob | null, localStorageKey: string): SafeResourceUrl | null {
    if(blob == null) return null;
    const reader = new FileReader();
          reader.onload = (e) => localStorage.setItem(localStorageKey, e.target!.result!.toString());
          reader.readAsDataURL(blob);
    var urlCreator = window.URL || window.webkitURL;
    return this.domSanitizer.bypassSecurityTrustResourceUrl( urlCreator.createObjectURL(blob));
  }
}