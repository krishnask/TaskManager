import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import{HttpClientModule} from '@angular/common/http';

import { AlertModule } from 'ngx-bootstrap';
import {MatDatepickerModule} from '@angular/material/datepicker'; 
import { NativeDateAdapter, DateAdapter }  from '@angular/material';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

import { AppComponent } from './app.component';
import { UpdateTaskComponent } from './update-task/update-task.component';
import { ViewTaskComponent } from './view-task/view-task.component';
import { SearchTaskComponent } from './search-task/search-task.component';
import {FilterPipe} from './Shared/tasks.pipe';

@NgModule({
  declarations: [
    AppComponent,
    UpdateTaskComponent,
    ViewTaskComponent,
    SearchTaskComponent,
    FilterPipe
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AlertModule.forRoot(),
    BsDatepickerModule.forRoot(),
    MatDatepickerModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
