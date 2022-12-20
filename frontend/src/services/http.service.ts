import { Injectable } from '@angular/core';
import axios from 'axios';
import {AuthHelperService} from "./auth-helper.service";

export const customAxios = axios.create({
  baseURL: 'http://localhost:5001',
  headers: {
    Authorization: `Bearer ${localStorage.getItem('token')}`
  }
})

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor(private authHelper: AuthHelperService) { }

  async getCoaches() {
    const httpResponse = await customAxios.get('/home');
    return httpResponse.data;
  }

  async register(dto: {name: string; email: string; password: string; usertype: string}){
    const token = await customAxios.post("/auth/register", dto);
    return token.data;
  }

  async login(dto: { password: string; email: string }) {
    const token = await customAxios.post("/auth/login", dto);
    return token.data;
  }

  async updateWorkingHours(startTime: string, endTime: string) {
  let dto = {
    startTime: startTime,
    endTime: endTime,
    email: this.authHelper.getDecodedToken()?.email
  }
    await customAxios.put('/booking', dto);
  }
}
