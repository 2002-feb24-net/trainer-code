import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import AppModule from './app/app.module';

// angular startup step 1: bootstrap the root module
platformBrowserDynamic().bootstrapModule(AppModule)
  .catch(err => console.error(err));
