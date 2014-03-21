'use strict';

var tryReadDelimiterFromInput = function (input) {
  var delimiter = '';

  if (input.indexOf('\\') === 0) {
    delimiter = [input.substr(1, 1)];
    input = input.substr(3);
  }
  return {
    delimiter: delimiter,
    input: input
  };
};

var readStringWithDifferentDelimiters = function (input, delimiter) {
  var allowedDelimiters = [delimiter, '\n'];

  for (var i = 1; i < allowedDelimiters.length; i++) {
    input = input.replace(allowedDelimiters[i], allowedDelimiters[0]);
  }
  return input;
};

var calculate = function (input) {
  if (input.length === 0) {
    return 0;
  }

  var result = tryReadDelimiterFromInput(input);
  var delimiter = result.delimiter;
  input = result.input;

  if (delimiter.length === 0) {
    delimiter = ',';
    input = readStringWithDifferentDelimiters(input, delimiter);
  }

  var sum = 0;
  var numbers = input.split(delimiter);

  numbers.forEach(function (number) {
    var parsedNumber = parseInt(number);
    if (parsedNumber < 0) {
      throw new Error('Invalid number ' + parsedNumber);
    } else if (parsedNumber <= 1000) {
      sum += parseInt(number);
    }
  });
  return sum;
};
