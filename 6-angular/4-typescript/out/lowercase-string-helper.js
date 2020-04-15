"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var LowercaseStringHelper = /** @class */ (function () {
    function LowercaseStringHelper() {
    }
    LowercaseStringHelper.prototype.formatString = function (s) {
        // string interpolation, a JS feature from ES6.
        return " ---- " + s.toLowerCase() + " ---- ";
    };
    return LowercaseStringHelper;
}());
exports.default = LowercaseStringHelper;
