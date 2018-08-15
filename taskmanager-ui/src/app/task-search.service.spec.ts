import { TestBed, inject } from '@angular/core/testing';

import { TaskSearchService } from './task-search.service';

describe('TaskSearchService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [TaskSearchService]
    });
  });

  it('should be created', inject([TaskSearchService], (service: TaskSearchService) => {
    expect(service).toBeTruthy();
  }));
});
