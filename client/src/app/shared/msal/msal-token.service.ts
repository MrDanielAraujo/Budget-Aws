import { Injectable } from "@angular/core";
import { AccountInfo } from "@azure/msal-browser";
import jwt_code from "jwt-decode";
import { MsalTokenDecode } from "./msal-token-decode";
import { MsalTokenKeys } from "./msal-token-keys";
import { MsalTokenKeysIdToken } from "./msal-token-keys-id-token";

@Injectable({
  providedIn: 'root'
})
export class MsalToken {
  private _token: string | null = null; 
  private _tokenDecode: MsalTokenDecode = new MsalTokenDecode;

  getToken(): string | null {
    return this._token;
  }

  getTokenDecode(): MsalTokenDecode {
    return this._tokenDecode;
  }

  setToken(accountInfo: AccountInfo ): void{
    this._token = null;
    let msalTokenKeys = localStorage.getItem(`msal.token.keys.${accountInfo.idTokenClaims?.aud}`)
    if(!msalTokenKeys) return;
    const tokenKeys = JSON.parse(msalTokenKeys) as MsalTokenKeys ;

    let idToken = tokenKeys.idToken;
    let objToken = localStorage.getItem(idToken);
    if(!objToken) return;
    const token = JSON.parse(objToken) as MsalTokenKeysIdToken;

    this._tokenDecode = jwt_code(token.secret) as MsalTokenDecode;
    this._token = token.secret;
  }
}
