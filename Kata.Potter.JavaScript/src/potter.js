'use strict';

var Basket = function () {
  this.discounts = [0, 1, 0.95, 0.9, 0.8, 0.75];
  this.bookPrice = 8;
};

Basket.prototype.clone = function (books) {
  return books.slice(0);
};

Basket.prototype.buildPackages = function (books, maxCount) {
  var count = 0;

  for (var i = 0; i < books.length; i++) {
    if (count === maxCount) {
      break;
    }

    if (books[i] > 0) {
      books[i]--;
      count++;
    }
  }
  return count;
};

Basket.prototype.calculatePrice = function (books, maxCount) {
  var totalPrice = 0;
  var count;

  do {
    count = this.buildPackages(books, maxCount);
    totalPrice += (count * this.bookPrice * this.discounts[count]);
  } while (count > 0);

  return totalPrice;
};

Basket.prototype.calculate = function (books) {
  books = books || [];
  var bestPrice = 0;

  if (books.length > 0) {
    for (var maxCount = 5; maxCount > 0; maxCount--) {
      var price = this.calculatePrice(this.clone(books), maxCount);
      if (price > 0 && (bestPrice === 0 || bestPrice > price)) {
        bestPrice = price;
      } else {
        break;
      }
    }
  }

  return bestPrice;
};
