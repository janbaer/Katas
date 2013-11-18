'use strict';

describe('StringCalculator specs', function () {
  describe('When string is empty', function () {
    it('Should return 0', function () {
      expect(calculator.add('')).toEqual(0);
    });
  });

  describe('When string contains a single number', function () {
    it('Should return its value', function () {
      expect(calculator.add('1')).toEqual(1);
    });
  });

  describe('When string contains multiple numbers', function () {
    describe('And they are separated with a comma', function () {
      it('Should return the sum of all numbers', function () {
        expect(calculator.add('1,2,3')).toEqual(6);
      });
    });
    describe('And they are separated with mulitple seperators', function () {
      it('Should return the sum of all numbers', function () {
        expect(calculator.add('1\n2,3')).toEqual(6);
      });
    });
  });
  describe('When the delimiter is part of the string', function () {
    it('Should should parse the delimiter and use it', function () {
      expect(calculator.add('//[;]\n1;2;3')).toEqual(6);
    });
  });
  describe('When string contains a negative number', function () {
    it('Should throw an exception', function () {
      expect(function () {
        calculator.add('-1,2')
      }).toThrow(new Error('negatives not allowed'))
    });
  });
  describe('When a number is greater than 1001', function () {
    it('Should ignore this numbers', function () {
      expect(calculator.add('1001,2')).toEqual(2);
    });
  });
});
