import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

import { SearchTaskComponent } from './search-task.component';

describe('SearchTaskComponent', () => {
  let component: SearchTaskComponent;
  let fixture: ComponentFixture<SearchTaskComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SearchTaskComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchTaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
