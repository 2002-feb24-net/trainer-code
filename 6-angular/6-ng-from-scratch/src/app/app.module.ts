import { NgModule } from "@angular/core";
import { BrowserModule } from '@angular/platform-browser';
import AppComponent from "./app.component";
import { CommonModule } from "@angular/common";

// typescript decorator syntax (like attributes in C#)
@NgModule({
  // every component needs to be declared in one angular module
  declarations: [
    AppComponent
  ],
  // if anything in this angular module needs anything from
  // a different one, you have to import that other angular module.
  imports: [
    BrowserModule, // to run in the browser
    CommonModule   // to use NgFor directive
  ],
  // angular startup step 2: bootstrap the root component in the root module
  bootstrap: [AppComponent]
})
export default class AppModule { }
