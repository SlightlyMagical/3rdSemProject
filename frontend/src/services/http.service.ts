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
}
