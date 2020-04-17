import { TestBed } from '@angular/core/testing';

import { NotesApiService } from './notes-api.service';
import { HttpClient } from '@angular/common/http';

describe('NotesApiService', () => {
  let service: NotesApiService;

  beforeEach(() => {
    const httpClientSpy = jasmine.createSpyObj('HttpClient', ['get', 'post']);

    TestBed.configureTestingModule({
      providers: [
        { provide: HttpClient, useValue: httpClientSpy }
      ]
    });
    service = TestBed.inject(NotesApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
