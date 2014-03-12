/* globals Basket */
'use strict';

describe('Kata.Potter', function () {
  var basket;

  beforeEach(function () {
    basket = new Basket();
  });

  describe('When the basket is empty', function () {
    it('Should return 0', function () {
      expect(basket.calculate([])).toBe(0);
    });
  });

  describe('When the basket contains just one book', function () {
    it('Should return the full price for this book', function () {
      expect(basket.calculate([1])).toEqual(8);
    });
  });

  describe('When the basket contains the same book twice', function () {
    it('Should return the full price for both books', function () {
      expect(basket.calculate([2])).toBe(16);
    });
  });

  describe('When the basket contains two different books', function () {
    it('Should give the user the expected discount', function () {
      expect(basket.calculate([1, 1])).toBe(15.2);
    });
  });

  describe('When the basket contains three book and one book twice', function () {
    it('Should give the user just a discount for 2 books', function () {
      expect(basket.calculate([2, 1])).toBe(23.2);
    });
  });

  describe('When the user wants to buy more books', function () {
    it('Should give the user the best price', function () {
      expect(basket.calculate([2, 2, 2, 1, 1])).toBe(51.2);
    });
  });
});
