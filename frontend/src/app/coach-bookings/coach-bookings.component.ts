import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../services/http.service";

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
    console.log(this.startTime)
    await this.http.updateWorkingHours(this.startTime, this.endTime);
  }
}
