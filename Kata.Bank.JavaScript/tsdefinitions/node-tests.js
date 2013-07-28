var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var assert = require("assert");
var fs = require("fs");
var events = require("events");

assert(1 + 1 - 2 === 0, "The universe isn't how it should.");

assert.deepEqual({ x: { y: 3 } }, { x: { y: 3 } }, "DEEP WENT DERP");

assert.equal(3, "3", "uses == comparator");

assert.notStrictEqual(2, "2", "uses === comparator");

assert.throws(function () {
    throw "a hammer at your face";
}, undefined, "DODGED IT");

assert.doesNotThrow(function () {
    if (false) {
        throw "a hammer at your face";
    }
}, undefined, "What the...*crunch*");

fs.writeFile("thebible.txt", "Do unto others as you would have them do unto you.", assert.ifError);

fs.writeFile("Harry Potter", "\"You be wizzing, Harry,\" jived Dumbledore.", {
    encoding: "ascii"
}, assert.ifError);

var Networker = (function (_super) {
    __extends(Networker, _super);
    function Networker() {
        _super.call(this);

        this.emit("mingling");
    }
    return Networker;
})(events.EventEmitter);

//@ sourceMappingURL=node-tests.js.map
