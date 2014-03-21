/* globals calculate */
'use strict';

describe('StringCalculator spec', function () {
  describe('When string is empty', function () {
    it('Should return 0', function () {
      expect(calculate('')).toBe(0);
    });
  });
  describe('When string contains 1', function () {
    it('Should return 1', function () {
      expect(calculate('1')).toBe(1);
    });
  });
  describe('When string contains 2 numbers with a delimiter', function () {
    it('Should return the sum of it', function () {
      expect(calculate('1,2')).toBe(3);
    });
  });
  describe('When string contains different delimiters', function () {
    it('Should return the correct result', function () {
      expect(calculate('1\n2,3')).toBe(6);
    });
  });
  describe('When string begins with the definition of the delimiter', function () {
    it('Should use this delimiter', function () {
      expect(calculate('\\;\n1;2;3')).toBe(6);
    });
  });
  describe('When one of the numbers is negative', function () {
    it('Should throw an exception', function () {
      expect(function () { calculate('-1,2'); }).toThrow(new Error('Invalid number -1'));
    });
  });
  describe('When a number is greater than 1000', function () {
    it('Should ignore it', function () {
      expect(calculate('1000,1001,2')).toBe(1002);
    });
  });
});
