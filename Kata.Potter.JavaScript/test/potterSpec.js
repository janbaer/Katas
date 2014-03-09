/* globals Basket */
'use strict';

describe('Kata.Potter', function () {
  var basket;

  beforeEach(function () {
    basket = new Basket();
  });

  describe('When Basket contains no books', function () {
    it('Should return 0', function () {
      var price = basket.calculate();
      expect(price).toBe(0);
    });
  });

  describe('When basket contains just one book', function () {
    it('Should return the price of the book', function () {
      var price = basket.calculate([ { id: 1, count: 1} ]);
      expect(price).toBe(8);
    });
  });

  describe('When the user wants to buy a book twice', function () {
    it('Should just return the sum of two books', function () {
      var price = basket.calculate([ { id: 1, count: 2} ]);
      expect(price).toBe(16);
    });
  });

  describe('When the user wants to buy two different books', function () {
    it('Should give the user the expected discount', function () {
      var price = basket.calculate([ { id: 1, count: 1}, { id: 2, count: 1} ]);
      expect(price).toBe(15.2);
    });
  });

  describe('When the user wants to buy a book twice and also another book', function () {
    it('Should give the user the discount for two books', function () {
      var books = [ { id: 1, count: 2}, { id: 2, count: 1} ];
      var price = basket.calculate(books);
      expect(price).toBe(23.2);
    });
  });

  describe('When the user wants buy more books', function () {
    it('Should return the user the best price combination', function () {
      var books = [
        { id: 1, count: 2},
        { id: 2, count: 2},
        { id: 3, count: 2},
        { id: 4, count: 1},
        { id: 5, count: 1},
      ];
      var price = basket.calculate(books);
      expect(price).toBe(51.20);
    });
  });
});
