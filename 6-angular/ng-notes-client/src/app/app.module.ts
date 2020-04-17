import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NotesComponent } from './notes/notes.component';
import { NavbarComponent } from './navbar/navbar.component';
import CardComponent from './card/card.component';
import CardService from './card-service';

// we divide up the app into several angular modules
// based on features / parts of the website
// for separation of concerns, but also because
// angular supports lazy loading of modules

// this is a decorator, decorator syntax is an experimental typescript feature
// angular provides 3 or 4 decorators that we use to mark
// typescript classes an having some special meaning in angular:
//   NgModule: angular module
//   Component: component
//   Injectable: service
//   Directive: directive

// https://angular.io/guide/ngmodule-api
//
@NgModule({
  // every component, directive, or pipe needs to be declared in one module
  declarations: [
    AppComponent,
    NotesComponent,
    NavbarComponent,
    CardComponent
  ],
  // if anything declared by this module needs anything declared by or provided by another module...
  // you need to import that other module here. this is *sort-of* like a project- or package-reference in .NET
  // we have TS imports to connect TS modules (e.g. at the top of this file)
  // here we have NG import to connect NG modules
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule
  ],
  // things declared in a module are not visible to other modules by default
  // if you want e.g. some component declared in this module to be used in another module...
  // you'd need to export that component here.
  exports: [
  ],
  // we can register services here, scoped to the module
  providers: [
    CardService
  ],
  // specifically for the root module, it should reference the root component
  // here in the bootstrap array
  bootstrap: [AppComponent]
})
export class AppModule { }
