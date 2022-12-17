import { Injectable } from '@angular/core';
import axios from 'axios';

export const customAxios = axios.create({
  baseURL: 'https://localhost:5000'
})

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  constructor() { }

  async getCoaches() {
    const httpResponse = await customAxios.get('/home');
    return httpResponse.data;
  }

  async createNewUser(dto: {name: string; email: string; password: string; usertype: string}){
    const httpResponse = await customAxios.post("/auth/register", dto);
    return httpResponse.data;
  }

  async login(dto: { password: string; email: string }) {
    const httpResponse = await customAxios.post("/auth/login", dto);
    return httpResponse.data;
  }
}
