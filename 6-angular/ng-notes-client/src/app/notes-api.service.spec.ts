import { TestBed } from '@angular/core/testing';

import { NotesApiService } from './notes-api.service';

describe('NotesApiService', () => {
  let service: NotesApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NotesApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
