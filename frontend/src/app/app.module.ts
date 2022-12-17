import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatToolbarModule} from "@angular/material/toolbar";
import {MatIconModule} from "@angular/material/icon";
import {MatButtonToggleModule} from "@angular/material/button-toggle";
import {MatButtonModule} from "@angular/material/button";
import { CoachListComponent } from './coach-list/coach-list.component';
import {MatCardModule} from "@angular/material/card";
import {RouterModule, RouterOutlet, Routes} from "@angular/router";
import { SignUpComponent } from './sign-up/sign-up.component';
import {MatFormFieldModule} from "@angular/material/form-field";
import {MatInputModule} from "@angular/material/input";
import {FormsModule} from "@angular/forms";

const routes: Routes = [
  {
    path: '', component: CoachListComponent
  },
  {
    path: 'signup', component: SignUpComponent
  }
]

@NgModule({
  declarations: [
    AppComponent,
    CoachListComponent,
    SignUpComponent
  ],
  imports: [
    RouterModule.forRoot(routes),
    BrowserModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonToggleModule,
    MatButtonModule,
    MatCardModule,
    RouterOutlet,
    MatFormFieldModule,
    MatInputModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
