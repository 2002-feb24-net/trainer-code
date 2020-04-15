// single-page application
// it'll still just have one view pretty much, but

// import Page from "./page";
// import CardService from "./card-service";

// const cardService = new CardService();

// const page = new Page(cardService);

// page.run();

import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import AppModule from "./app.module";

platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
