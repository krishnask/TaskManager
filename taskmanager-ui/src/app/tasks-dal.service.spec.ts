import { TestBed, inject } from '@angular/core/testing';

import { TasksDalService } from './tasks-dal.service';

describe('TasksDalService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TasksDalService]
    });
  });

  it('should be created', inject([TasksDalService], (service: TasksDalService) => {
    expect(service).toBeTruthy();
  }));
});
