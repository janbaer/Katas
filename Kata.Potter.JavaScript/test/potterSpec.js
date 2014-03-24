/* global Basket */
'use strict';

describe('Kata.Potter spec', function () {
  var basket = new Basket();

  describe('When Basket is empty', function () {
    it('Should return 0', function () {
      expect(basket.calculate([])).toBe(0);
    });
  });
  describe('When Basket contains just one book', function () {
    it('Should calculate the full price for the book', function () {
      expect(basket.calculate([1])).toBe(8);
    });
  });
  describe('When Basket contains the same book twice', function () {
    it('Should pay the full price for both books', function () {
      expect(basket.calculate([2])).toBe(16);
    });
  });
  describe('When Basket contains two different books', function () {
    it('Should give the user 5 percent discount for each book', function () {
      expect(basket.calculate([1, 1])).toBe(15.2);
    });
  });
  describe('When Basket contains 3 books to one book twice', function () {
    it('Should give the user the discount for just two books', function () {
      expect(basket.calculate([2, 1])).toBe(23.2);
    });
  });
  describe('When Basket contains many book', function () {
    it('Should give the user the best price', function () {
      expect(basket.calculate([2, 2, 2, 1, 1])).toBe(51.2);
    });
  });
});
