import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NotesComponent } from './notes.component';
import { ReactiveFormsModule } from '@angular/forms';
import { NotesApiService } from '../notes-api.service';

describe('NotesComponent', () => {
  let component: NotesComponent;
  let fixture: ComponentFixture<NotesComponent>;

  // stub service which pretends to fetch a list of 0 notes
  let notesApiStub = { getNotes: () => Promise.resolve([]) };

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [
        NotesComponent
      ],
      imports: [
        ReactiveFormsModule
      ],
      providers: [
        { provide: NotesApiService, useValue: notesApiStub }
      ]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NotesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
