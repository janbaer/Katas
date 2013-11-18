'use strict';

var calculator = function () {
  var add = function (input) {
    if (input === '') {
      return 0;
    }

    var delimiter = /,|\n/;
    var matches = new RegExp('//\\[(.)\\]\n(.+)').exec(input);
    if (matches !== null) {
      delimiter = matches[1];
      input = matches[2];
    }

    var sum = 0;

    var tokens = input.split(delimiter);
    tokens.forEach(function (token) {
      var number = parseInt(token);
      if (number < 0) {
        throw new Error('negatives not allowed');
      } else if (number < 1001) {
        sum += number;
      }
    })
    return sum;
  }

  return {
    add: add
  };
}();
