import { ILoginResponse, ICulture } from "domain/Interfaces";
import * as JwtDecode from "jwt-decode";

export class AppState {
  public readonly baseUrl = 'https://localhost:5001/api/v1/';
  public readonly mapUrl = 'http://{s}.tile.osm.org/{z}/{x}/{y}.png';

  
  // get culture(): ICulture | null {
  //   return this.getValue('culture');
  // }

  // set culture(value: ICulture | null) {
  //   this.setValue('culture', value);
  // }

  // get token(): string | null {
  //   return this.getValue('token');
  // }

  // set token(value: string | null) {
  //   this.setValue('token', value);
  //   let userId = null;
  //   if (value !== null) {
  //     const decoded = JwtDecode<Record<string, string>>(value.token);
  //     userId = decoded['http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier'];
  //   }
  //   this.setValue('userId', userId);
  // }

  // get userId(): string | null {
  //   return this.getValue('userId');
  // }
  // private getValue(key: string): string {
  //   const token = localStorage.getItem(key);
  //   return token === null ? token : JSON.parse(token);
  // }

  // private setValue(key: string, value: Record<string, string> | null): void {
  //   if (value) {
  //     localStorage.setItem(key, JSON.stringify(value));
  //   } else {
  //     localStorage.removeItem(key);
  //   }
  // }
  
 
}
