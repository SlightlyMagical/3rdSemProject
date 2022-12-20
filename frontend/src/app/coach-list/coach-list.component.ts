import {Component, OnInit} from '@angular/core';
import {HttpService} from "../../services/http.service";

@Component({
  selector: 'app-coach-list',
  templateUrl: './coach-list.component.html',
  styleUrls: ['./coach-list.component.css']
})
export class CoachListComponent implements OnInit {
  coaches: any;

  constructor(private http: HttpService) { }

  async ngOnInit() {
    await this.getCoaches();
  }

  async getCoaches(){
    this.coaches = await this.http.getCoaches();
  }

}
