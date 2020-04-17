import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Note from './models/note';
import { environment } from 'src/environments/environment';

// the providedIn line makes this global singleton by default
// ...but every injectable needs at least @Injectable()
@Injectable({
  providedIn: 'root'
})
export class NotesApiService {
  baseUrl = environment.notesApiBaseUrl;

  constructor(private http: HttpClient) { }

  getNotes() {
    return this.http.get<Note[]>(`${this.baseUrl}api/notes`)
      .toPromise();
  }

  createNote(note: Note) {
    return this.http.post<Note>(`${this.baseUrl}api/notes`, note)
      .toPromise();
  }
}
