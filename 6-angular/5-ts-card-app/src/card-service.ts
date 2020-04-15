import Card from "./card";

// communicates with Deck of Cards API (https://deckofcardsapi.com/)
// to implement some card operations
// TODO: implement
export default class CardService {
    newDeck(): Promise<void> {
        throw new Error("Method not implemented.");
    }

    drawCard(): Promise<Card> {
        throw new Error("Method not implemented.");
    }
}
