/* globals calculate */
'use strict';

describe('StringCalculator spec', function () {
  describe('When string is empty', function () {
    it('Should return 0', function () {
      expect(calculate('')).toBe(0);
    });
  });
  describe('When string contains a single number', function () {
    it('Should return the numeric value', function () {
      expect(calculate('1')).toBe(1);
    });
  });
  describe('When string contains two numbers', function () {
    it('Should return the sum of it', function () {
      expect(calculate('1,2')).toBe(3);
    });
  });
  describe('When string contains different delimiters', function () {
    it('Should should alreay the correct result', function () {
      expect(calculate('1\n2,3')).toBe(6);
    });
  });
  describe('When string begins with the definition of the delimiter', function () {
    it('Should use this delimiter', function () {
      expect(calculate('\\;\n1;2')).toBe(3);
    });
  });
  describe('When string contains a negative number', function () {
    it('Should throw an error', function () {
      expect(function () { calculate('1,-2'); }).toThrow(new Error('invalid number -2'));
    });
  });
  describe('When string contains a number greather 1000', function () {
    it('Should ignore this number', function () {
      expect(calculate('1000,1001,2')).toBe(1002);
    });
  });
});
