import {Component, OnInit} from '@angular/core';
import jwtDecode from "jwt-decode";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Game Coaching Today';
  loggedIn = false;
  usertype = '';

  ngOnInit(): void {
    let token = localStorage.getItem('token');
    if(token) {
      this.loggedIn = true;
      let decodedToken = jwtDecode(token) as Token;
      if (decodedToken.usertype){
        this.usertype = decodedToken.usertype;
        }
    }
  }

  logout() {
    localStorage.removeItem('token');
    this.loggedIn = false;
  }
}

class Token{
  usertype?: string;
}
