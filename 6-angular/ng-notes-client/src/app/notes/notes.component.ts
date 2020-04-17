import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Note from '../models/note';

@Component({
  selector: 'app-notes',
  templateUrl: './notes.component.html',
  styleUrls: ['./notes.component.css']
})
export class NotesComponent implements OnInit {
  notes: Note[] = []

  // the ctor is for DI and for any setup that doesn't need the DOM ready
  constructor(private http: HttpClient) { }

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
    return this.http.get<Note[]>('https://localhost:44308/api/notes')
      .toPromise()
      .then(notes => this.notes = notes);
  }

}
