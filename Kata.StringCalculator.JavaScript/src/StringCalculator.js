'use strict';

var calculator = function () {
  var add = function (input) {
    if (input === '') {
      return 0;
    }

    input = input.replace('\n', ',');

    var sum = 0;

    var tokens = input.split(',');
    tokens.forEach(function (token) {
      var number = parseInt(token);
      if (number <= 0) {
        throw new Error('negatives not allowed');
      }
      else if (number <= 1000) {
        sum += number;
      }
    })

    return sum;
  }

  return {
    add: add
  };
}();
