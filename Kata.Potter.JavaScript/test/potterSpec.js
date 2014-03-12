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

  describe('When the user want to buy just one book', function () {
    it('Should return the full price for one book', function () {
      expect(basket.calculate([ 1 ])).toBe(8);
    });
  });

  describe('When the user wants to buy a book twice', function () {
    it('Should just multiply the price of two books', function () {
      expect(basket.calculate([ 2 ])).toBe(16);
    });
  });

  describe('When the user wants to buy two different books', function () {
    it('Should give the user the expected discount', function () {
      expect(basket.calculate([ 1, 1 ])).toBe(15.2);
    });
  });

  describe('When the user wants to buy three books but just two different books', function () {
    it('Should pay the complete price for the third book', function () {
      expect(basket.calculate([ 2, 1 ])).toBe(23.2);
    });
  });

  describe('When the user wants to buy some more books', function () {
    it('should get the best price', function () {
      var books = [ 2, 2, 2, 1, 1 ];
      expect(basket.calculate(books)).toBe(51.2);
    });
  });
});
