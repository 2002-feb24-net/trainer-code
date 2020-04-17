import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Note from './models/note';

// the providedIn line makes this global singleton by default
// ...but every injectable needs at least @Injectable()
@Injectable({
  providedIn: 'root'
})
export class NotesApiService {

  constructor(private http: HttpClient) { }

  getNotes() {
    return this.http.get<Note[]>('https://localhost:44308/api/notes')
      .toPromise();
  }

  createNote(note: Note) {
    return this.http.post<Note>('https://localhost:44308/api/notes', note)
      .toPromise();
  }
}
