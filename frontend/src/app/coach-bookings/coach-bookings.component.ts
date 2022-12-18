import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../services/http.service";
import * as http from "http";

@Component({
  selector: 'app-coach-bookings',
  templateUrl: './coach-bookings.component.html',
  styleUrls: ['./coach-bookings.component.css']
})
export class CoachBookingsComponent implements OnInit {
  bookings: any;
  startTime: any;
  endTime: any;

  constructor(private http: HttpService) { }

  ngOnInit(): void {
  }

  async updateWorkingHours() {
    let dto = {
      startTime: this.startTime,
      endTime: this.endTime
    }
    await this.http.updateWorkingHours(dto);
  }
}
