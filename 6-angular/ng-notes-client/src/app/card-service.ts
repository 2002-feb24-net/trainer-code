
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Card from './models/card';

// communicates with Deck of Cards API (https://deckofcardsapi.com/)
// to implement some card operations
@Injectable()
export default class CardService {
  currentDeckId: string | null = null;

  constructor(private http: HttpClient) { }

  newDeck(): Promise<void> {
    return this.http.get<{ deck_id: string }>('https://deckofcardsapi.com/api/deck/new/')
      .toPromise()
      .then(responseObj => {
        this.currentDeckId = responseObj.deck_id;
        console.log(this.currentDeckId);
      });
  }

  drawCard(): Promise<Card> {
    if (!this.currentDeckId) {
      throw new Error('No deck found');
    }
    return this.http.get<{ cards: Card[] }>(`https://deckofcardsapi.com/api/deck/${this.currentDeckId}/draw/?count=1`)
      .toPromise()
      .then(responseObj => responseObj.cards[0]);
  }
}
