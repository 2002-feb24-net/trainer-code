import { Component } from "@angular/core";

@Component({
  selector: 'app',
  template: `
    <button id="new-deck">New Deck</button>
    <button id="draw-card">Draw Card</button>
    <div id="card-container"></div>
  `
})
export default class AppComponent { }
