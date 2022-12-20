import {Injectable} from '@angular/core';
import jwtDecode from "jwt-decode";

@Injectable({
  providedIn: 'root'
})
export class AuthHelperService {

  constructor() {
  }

  getDecodedToken() {
    let token = localStorage.getItem('token');
    if (token) {
      return jwtDecode(token) as Token;
    }
    return null;
  }

}

class Token {
  exp?: number;
  role?: string;
  email?: string
}
