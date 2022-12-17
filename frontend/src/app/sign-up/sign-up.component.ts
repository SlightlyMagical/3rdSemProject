import { Component, OnInit } from '@angular/core';
import {HttpService} from "../../services/http.service";

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  name: string = '';
  email: string = '';
  password: string = '';
  usertype: string = '';
  hide = true;

  constructor(private http: HttpService) { }

  ngOnInit(): void {
  }

  async signup() {
    let dto = {
      name: this.name,
      email: this.email,
      password: this.password,
      usertype: this.usertype
    }
    const result = await this.http.createNewUser(dto);
  }
}
