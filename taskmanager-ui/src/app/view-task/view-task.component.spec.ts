import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewTaskComponent } from './view-task.component';
import {SearchTaskComponent} from '../search-task/search-task.component';
import {FilterPipe} from '../Shared/tasks.pipe';
import{FormsModule} from '@angular/forms'
import{HttpClientModule} from '@angular/common/http';
import{RouterTestingModule} from '@angular/router/testing';


describe('ViewTaskComponent', () => {
  let component: ViewTaskComponent;
  let fixture: ComponentFixture<ViewTaskComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports:[FormsModule,
        HttpClientModule,
        RouterTestingModule
      ],
      declarations: [ ViewTaskComponent, SearchTaskComponent, FilterPipe ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewTaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
