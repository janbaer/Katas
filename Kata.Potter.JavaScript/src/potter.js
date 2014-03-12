'use strict';

var Basket = function () {
  this.bookPrice = 8;
  this.discounts = [0, 1, 0.95, 0.9, 0.8, 0.75];
};

Basket.prototype.clone = function (books) {
  return JSON.parse(JSON.stringify(books));
};

Basket.prototype.buildPackages = function (books, maxCount) {
  var count = 0;

  for (var i = 0; i < books.length; i++) {
    if (books[i] > 0 && count < maxCount) {
      count++;
      books[i]--;
    }
  }

  return count;
};

Basket.prototype.calculatePackage = function (books, maxCount) {
  var totalPrice = 0;

  if (books.length > 0) {
    var count = 0;
    do {
      count = this.buildPackages(books, maxCount);
      totalPrice += count * this.bookPrice * this.discounts[count];
    } while (count > 0);
  }

  return totalPrice;
};


Basket.prototype.calculate = function (books) {
  books = books || [];
  var bestPrice = 0;
  var maxCount = 5;

  do {
    var price = this.calculatePackage(this.clone(books), maxCount);
    if (price > 0 && (bestPrice === 0 || price < bestPrice)) {
      bestPrice = price;
    } else {
      break;
    }
    maxCount--;
  } while (maxCount > 0);

  return bestPrice;
};
