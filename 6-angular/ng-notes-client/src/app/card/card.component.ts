import { Component } from "@angular/core";
import CardService from '../card-service';
import Card from '../models/card';

// in angular, a component manages one part of the page (a view)
// with (1) a typescript class for the logic & data, and (2) an HTML template
// for the presentation.
@Component({
  // the CSS selector defining which elements
  // on the page are this component
  selector: 'app-card',
  template: `
    <button (click)="newDeck()">New Deck</button>
    <button (click)="drawCard()">Draw Card</button>
    <div>
      <img *ngFor="let card of cards" [src]="card.image" [alt]="card.code">
    </div>
  `,
  providers: []
})
export default class CardComponent {
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
