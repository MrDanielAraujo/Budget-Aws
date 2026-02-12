import { Injectable } from "@angular/core";
import { SessionStorage } from "./session-storage";

@Injectable({
  providedIn: 'root'
})
export class SessionService {

 
    /**
     * This method creates a session object based on the module name it is accessing. 
     * @param modulo => Name of the module being accessed at the moment. 
     */
    New (modulo: string) {
      let storage = new SessionStorage();
      sessionStorage.setItem(modulo, JSON.stringify(storage));
    };
    /**
     * This method returns the session object that the current module is using.
     * @returns => A Storage Object.
     */
    Get (modulo: string): SessionStorage {  
      let objeto = sessionStorage.getItem(modulo);
      if(!objeto) return new SessionStorage();
      var storage = JSON.parse(objeto) as SessionStorage;
      return storage;
    };
    /**
     * Removes the object from the session 
     */
    Clean (modulo: string): void {
      sessionStorage.removeItem(modulo);
    }
    /**
     * Change the value of the object stored in the session.
     * @param modulo => Name of the module being accessed at the moment.
     * @param storage => Object to change in the session.
     */
    Set (modulo: string, storage: SessionStorage): void {
      sessionStorage.setItem(modulo, JSON.stringify(storage));
    }
  
}