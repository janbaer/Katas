'use strict';

var Basket = function () {
  this.discounts = [1, 0.95, 0.9, 0.8, 0.75];
  this.bookPrice = 8;
};

Basket.prototype.clone = function (books) {
  return JSON.parse(JSON.stringify(books));
};

Basket.prototype.buildPackages = function (books, maxCount) {
  var count = 0;

  books.forEach(function (book) {
    if (count <= maxCount && book.count > 0) {
      book.count--;
      count++;
    }
  });
  return count;
};

Basket.prototype.calculatePackagePrice = function (books, maxCount) {
  var totalPrice = 0;

  var count;

  do {
    count = this.buildPackages(books, maxCount);
    if (count > 0) {
      totalPrice += (count * this.bookPrice * this.discounts[count - 1]);
    }
  } while (count > 0);

  return totalPrice;
};

Basket.prototype.calculateBestPrice = function (books) {
  var maxPackageCount = 5;
  var bestPrice = 0;

  while (maxPackageCount > 0) {
    var price = this.calculatePackagePrice(this.clone(books), maxPackageCount);
    if (bestPrice === 0) {
      bestPrice = price;
    } else if (price > 0 && price <= bestPrice) {
      bestPrice = price;
    }
    maxPackageCount--;
  }

  return bestPrice;
};

Basket.prototype.calculate = function (books) {
  books = books || [];
  return this.calculateBestPrice(books);
};
