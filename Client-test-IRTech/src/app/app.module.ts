import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { TestCardComponent } from './components/test-card/test-card.component';
import { HomeComponent } from './components/home/home.component';
import { TestComponent } from './components/test/test.component';
import { TestLabelComponent } from './components/test-label/test-label.component';
import {DialogOverviewStatsTest} from './components/test/test.component';
import {MatDialogModule} from "@angular/material/dialog";
import {MatButtonModule} from "@angular/material/button";

@NgModule({
  declarations: [
    AppComponent,
    TestCardComponent,
    HomeComponent,
    TestComponent,
    TestLabelComponent,
    DialogOverviewStatsTest
  ],
  imports: [
    BrowserModule,
    MatDialogModule,
    MatButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
