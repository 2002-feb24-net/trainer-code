import { Component } from "@angular/core";
import Card from "./card";
import CardService from "./card-service";

// in angular, a component manages one part of the page (a view)
// with (1) a typescript class for the logic & data, and (2) an HTML template
// for the presentation.
@Component({
  // the CSS selector defining which elements
  // on the page are this component
  selector: 'app',
  template: `
    <button (click)="newDeck()">New Deck</button>
    <button (click)="drawCard()">Draw Card</button>
    <div>
      <img *ngFor="let card of cards" [src]="card.image" [alt]="card.code">
    </div>
  `,
  providers: [
    CardService
  ]
})
export default class AppComponent {
  // component data/logic goes here

  cards: Card[] = []

  constructor(private cardService: CardService) {
  }

  newDeck() {
    this.cardService.newDeck().then();
  }

  drawCard() {
    this.cardService.drawCard().then(card => this.cards.push(card));
  }
}
