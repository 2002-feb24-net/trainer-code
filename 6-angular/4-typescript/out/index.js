"use strict";
// 1. create folder for this node stuff
// 2. make package.json with `npm init -y`
// 3. make sure typescript is globally installed so we can use tsc.
// 4. run tsc init to get a tsconfig.json file.
// 5. write some typescript.
// 6. run `tsc` to convert it to JS.
var __importDefault = (this && this.__importDefault) || function (mod) {
    return (mod && mod.__esModule) ? mod : { "default": mod };
};
Object.defineProperty(exports, "__esModule", { value: true });
var lowercase_string_helper_1 = __importDefault(require("./lowercase-string-helper"));
// in TS, any variable without an explicit type
// is "any" type. this disables all compile-time type checking.
// if you don't specify a type, TS behaves kind of like "var" in C#.
// const helper = new LowercaseStringHelper();
// if the JS result of this TS is going to go to the client rather than run on the server...
// then i can use browser APIs like DOM.
document.addEventListener('DOMContentLoaded', function () {
    // const element: HTMLParagraphElement = document.createElement('p');
    var element = document.createElement('p');
    var helper = new lowercase_string_helper_1.default();
    element.textContent = helper.formatString("Hello TS");
    document.body.appendChild(element);
});
