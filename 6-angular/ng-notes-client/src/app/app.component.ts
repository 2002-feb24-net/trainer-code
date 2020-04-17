import { Component } from '@angular/core';

@Component({
  // the selector (think CSS selector) tells Angular
  // what elements on the page to replace with this component & its template
  selector: 'app-root',

  // a component needs a template... you can provide it inline
  //template: '<p class="something">the {{title}} template</p>',
  // or in a separate file
  templateUrl: './app.component.html',

  // a component can have styles
  // styles on a component can be written as though the component is the
  // only thing that exists.
  // styles can be inline
  // styles: [
  //   'p { font-size: 14pt; };'
  // ]
  // styles can instead be in separate files
  styleUrls: ['./app.component.css'],

  // also, the entire app gets the CSS in src/styles.css

  providers: [], // services provided at component-scope

  animations: [] // configure CSS animations
})
export class AppComponent {
  title = 'ng-notes-client';
}
