'use strict';

var normalizeInputWithDifferentDelimiters = function (input) {
  var allowedDelimiters = [',', '\n'];

  for (var i = 1; i < allowedDelimiters.length; i++) {
    input = input.replace(allowedDelimiters[i], allowedDelimiters[0]);
  }
  return input;
};

var tryReadDelimiterDefinitionFromInput = function (input) {
  var delimiter = '';

  if (input.indexOf('\\') === 0) {
    delimiter = input.substr(1, 1);
    input = input.substr(3);
  }
  return {
    delimiter: delimiter,
    input: input
  };
};

var parseAndVerifyThatNumberIsPositive = function (number) {
  var parsedNumber = parseInt(number);
  if (parsedNumber < 0) {
    throw new Error('invalid number ' + parsedNumber);
  }
  return parsedNumber;
};

var calculate = function (input) {
  if (input.length === 0) {
    return 0;
  }

  var delimiter = ',';

  var result = tryReadDelimiterDefinitionFromInput(input);
  console.log(result);
  if (result.delimiter.length !== 0) {
    delimiter = result.delimiter;
    input = result.input;
  } else {
    input = normalizeInputWithDifferentDelimiters(input);
  }

  var sum = 0;
  var numbers = input.split(delimiter);

  numbers.forEach(function (number) {
    var parsedNumber = parseAndVerifyThatNumberIsPositive(number);
    if (parsedNumber <= 1000) {
      sum += parsedNumber;
    }
  });
  return sum;
};
