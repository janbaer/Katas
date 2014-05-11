'use strict';

var Cell = function (x, y) {
  this.x = x;
  this.y = y;
};

Cell.prototype.equals = function (otherCell) {
  return this.x === otherCell.x && this.y === otherCell.y;
};


var Grid = function () {
  var aliveCells = [].slice.call(arguments);

  var isAlive = function (cell) {
    return aliveCells.some(function (aliveCell) {
      return aliveCell.equals(cell);
    });
  };

  var getNeighborsOf = function (cell, filter) {
    var neighbors = [];

    for (var x = -1; x < 2; x++) {
      for (var y = -1; y < 2; y++) {
        var neighbor = new Cell(cell.x + x, cell.y + y);
        if (!neighbor.equals(cell)) {
          neighbors.push(neighbor);
        }
      }
    }

    if (filter) {
      neighbors = neighbors.filter(filter);
    }
    return neighbors;
  };

  var getAliveNeighborsOf = function (cell) {
    return getNeighborsOf(cell, function (neighbor) {
      return isAlive(neighbor);
    });
  };

  var getDeadNeighborsOf = function (cell) {
    return getNeighborsOf(cell, function (neighbor) {
      return !isAlive(neighbor);
    });
  };

  var getAliveCandidates = function () {
    return aliveCells.filter(function (aliveCell) {
      var count = getAliveNeighborsOf(aliveCell).length;
      return (count === 2 || count === 3);
    });
  };

  var getReviveCandidates = function () {
    var reviveCandidates = [];

    aliveCells.forEach(function (aliveCell) {
      var deadNeighbors = getDeadNeighborsOf(aliveCell);

      deadNeighbors.forEach(function (neighbor) {
        if (getAliveNeighborsOf(neighbor).length === 3) {
          reviveCandidates.push(neighbor);
        }
      });
    });
    return reviveCandidates;
  };

  var newGeneration = function () {
    aliveCells = getAliveCandidates().concat(getReviveCandidates());
  };

  return {
    isAlive: isAlive,
    newGeneration: newGeneration
  };
};
