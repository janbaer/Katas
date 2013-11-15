'use strict';

describe('StringCalculator specs', function () {
  describe('When String is empty', function () {
    it('Should return 0', function () {
      expect(calculator.add('')).toEqual(0);
    });
  });

  describe('When string contains a single number', function () {
    it('Should return the value of it', function () {
      expect(calculator.add('1')).toEqual(1);
    });
  });

  describe('When string contains more than one number', function () {
    it('Should return the sum of it', function () {
      expect(calculator.add('1,2,3')).toEqual(6);
    });
  });

  describe('When string contains more than one delimiter', function () {
    it('Should return the sum of it', function () {
      expect(calculator.add('1\n2,3')).toEqual(6);
    });
  });

  describe('When a number is greater than 1000', function () {
    it('Should ignore it', function () {
      expect(calculator.add('1001,2')).toEqual(2);
    });
  });

  describe('When a number is negative', function () {
    it('Should should throw an error', function () {
      expect(function () {
        calculator.add('-1');
      }).toThrow(new Error('negatives not allowed'));
    });
  });
});
