import { Component, OnInit } from '@angular/core';
import { NotesApiService } from '../notes-api.service';
import Note from '../models/note';
import { HttpErrorResponse } from '@angular/common/http';
import { FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.css']
})
export class NotesComponent implements OnInit {
  notes: Note[] = []
  error: string | undefined;

  createNoteForm = this.formBuilder.group({
    text: ['', Validators.required]
  });

  // the ctor is for DI and for any setup that doesn't need the DOM ready
  constructor(
    private notesApi: NotesApiService,
    private formBuilder: FormBuilder
  ) { }

  // any setup that expects data binding to be wired up, etc.
  // needs to be in here.
  // ngOnInit is a "lifecycle hook"
  ngOnInit(): void {
    // once the DOM is ready, i want to send my http requests
    // and eventually put the notes into the property and thus
    // via data binding, the DOM.
    this.getNotes();
  }

  getNotes() {
    return this.notesApi.getNotes()
      .then(
        notes => {
          this.notes = notes;
          this.resetError();
        }, // success
        error => {
          this.handleError(error);
        } // error
      );
  }

  handleError(error: HttpErrorResponse) {
    if (error.error instanceof ErrorEvent) {
      // A client-side or network error occurred. Handle it accordingly.
      this.error = `An error occurred: ${error.error.message}`;
    } else {
      // The backend returned an unsuccessful response code.
      // The response body may contain clues as to what went wrong,
      this.error = `Backend returned code ${error.status}, body was: ${error.error}`;
    }
    // return an observable with a user-facing error message
    // this.error = 'Something bad happened; please try again later.';
  };

  resetError() {
    this.error = undefined;
  }

  createNote() {
    const newNote: Note = {
      isPublic: true,
      text: this.createNoteForm.get('text')?.value
    };
    this.notesApi.createNote(newNote)
      .then(
        note => {
          if (this.error) {
            this.getNotes();
          } else {
            this.notes.unshift(note);
            this.resetError();
          }
        },
        error => this.handleError(error)
      );
  }

}
