import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree} from "@angular/router";
import jwtDecode from "jwt-decode";
import {Observable} from "rxjs";
import {AuthHelperService} from "../auth-helper.service";

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService implements CanActivate{

  constructor(private authHelper: AuthHelperService) { }

  canActivate(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    let decodedToken = this.authHelper.getDecodedToken();
    let currentDate = new Date();
    if (decodedToken){
      if (decodedToken.exp){
        let expiry = new Date(decodedToken.exp*1000);
        if (currentDate>expiry){
          return false;
        }
      }
    }
    return true;
  }
}


