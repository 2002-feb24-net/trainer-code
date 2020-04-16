import Card from "./card";

// communicates with Deck of Cards API (https://deckofcardsapi.com/)
// to implement some card operations
export default class CardService {
    currentDeckId: string | null = null;

    newDeck(): Promise<void> {
        return fetch('https://deckofcardsapi.com/api/deck/new/')
            .then(response => response.json())
            .then(responseObj => {
                this.currentDeckId = responseObj.deck_id;
                console.log(this.currentDeckId);
            });
    }

    drawCard(): Promise<Card> {
        if (!this.currentDeckId) {
            throw new Error('No deck found');
        }
        return fetch(`https://deckofcardsapi.com/api/deck/${this.currentDeckId}/draw/?count=1`)
            .then(response => response.json())
            .then(responseObj => responseObj.cards[0] as Card);
    }
}
