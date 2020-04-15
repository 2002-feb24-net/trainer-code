import StringHelper from "./string-helper";

export default class LowercaseStringHelper implements StringHelper {
    formatString(s: string): string {
        // string interpolation, a JS feature from ES6.
        return ` ---- ${s.toLowerCase()} ---- `;
    }
}
