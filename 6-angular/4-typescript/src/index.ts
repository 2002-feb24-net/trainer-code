// 1. create folder for this node stuff
// 2. make package.json with `npm init -y`
// 3. make sure typescript is globally installed so we can use tsc.
// 4. run tsc init to get a tsconfig.json file.
// 5. write some typescript.
// 6. run `tsc` to convert it to JS.

import StringHelper from "./string-helper";
import LowercaseStringHelper from "./lowercase-string-helper";

// in TS, any variable without an explicit type
// is "any" type. this disables all compile-time type checking.


// if you don't specify a type, TS behaves kind of like "var" in C#.
// const helper = new LowercaseStringHelper();

// if the JS result of this TS is going to go to the client rather than run on the server...
// then i can use browser APIs like DOM.
document.addEventListener('DOMContentLoaded', () => {
    // const element: HTMLParagraphElement = document.createElement('p');
    const element = document.createElement('p');

    const helper: StringHelper = new LowercaseStringHelper();

    element.textContent = helper.formatString("Hello TS");

    document.body.appendChild(element);
});

// with local NPM installs (in package.json / node_modules)...
// you can't just run commands based on those packages.
// you need either NPM scripts (configured in package.json, run with "npm run ___")
//  ... or, "npx" command
