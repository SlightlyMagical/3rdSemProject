import { Injectable } from '@angular/core';
import axios from 'axios';

export const customAxios = axios.create({
  baseURL: 'https://localhost:5000',
  headers: {
    Authorization: `Bearer ${localStorage.getItem('token')}`
  }
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

  async register(dto: {name: string; email: string; password: string; usertype: string}){
    const token = await customAxios.post("/auth/register", dto);
    return token.data;
  }

  async login(dto: { password: string; email: string }) {
    const token = await customAxios.post("/auth/login", dto);
    return token.data;
  }

  async updateWorkingHours(dto: {startTime: string; endTime: string}) {
    await customAxios.put('/managebooking/coach', dto);
  }
}
