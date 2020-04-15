"use strict";
// in TS, any variable without an explicit type
// is "any" type. this disables all compile-time type checking.
var LowercaseStringHelper = /** @class */ (function () {
    function LowercaseStringHelper() {
    }
    LowercaseStringHelper.prototype.formatString = function (s) {
        // string interpolation, a JS feature from ES6.
        return " ---- " + s.toLowerCase() + " ---- ";
    };
    return LowercaseStringHelper;
}());
// if you don't specify a type, TS behaves kind of like "var" in C#.
// const helper = new LowercaseStringHelper();
// if the JS result of this TS is going to go to the client rather than run on the server...
// then i can use browser APIs like DOM.
document.addEventListener('DOMContentLoaded', function () {
    // const element: HTMLParagraphElement = document.createElement('p');
    var element = document.createElement('p');
    var helper = new LowercaseStringHelper();
    element.textContent = helper.formatString("Hello TS");
    document.body.appendChild(element);
});
