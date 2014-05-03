'use strict';

var Cell = function (x, y) {
  this.x = x;
  this.y = y;
};

Cell.prototype.equals = function (otherCell) {
  return this.x === otherCell.x && this.y === otherCell.y;
};

var Grid = function () {
  this.aliveCells = [].slice.call(arguments);

  this.isAlive = function (cell) {
    return this.aliveCells.some(function (aliveCell) {
      return aliveCell.equals(cell);
    });
  };

  this.getNeighborsOf = function (cell, filter) {
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
      return neighbors.filter(filter);
    }
    return neighbors;
  };

  this.getAliveNeighborsOf = function (cell) {
    return this.getNeighborsOf(cell, function (neighbor) {
      return this.isAlive(neighbor);
    }.bind(this));
  };

  this.getDeadNeighborsOf = function (cell) {
    return this.getNeighborsOf(cell, function (neighbor) {
      return !this.isAlive(neighbor);
    }.bind(this));
  };

  this.getAliveCandidates = function (aliveCells) {
    return aliveCells.filter(function (aliveCell) {
      var aliveNeighbors = this.getAliveNeighborsOf(aliveCell);
      return aliveNeighbors.length === 3 || aliveNeighbors.length === 4;
    }.bind(this));
  };

  this.getReviveCandidates = function (aliveCells) {
    var candidates = [];

    aliveCells.forEach(function (aliveCell) {
      var deadNeighbors = this.getDeadNeighborsOf(aliveCell);
      candidates = candidates.concat(deadNeighbors.filter(function (deadNeighbor) {
        return this.getAliveNeighborsOf(deadNeighbor).length === 3;
      }.bind(this)));
    }.bind(this));

    return candidates;
  };

  this.newGeneration = function () {
    var aliveCandidates = this.getAliveCandidates(this.aliveCells);
    var reviveCandidates = this.getReviveCandidates(this.aliveCells);

    this.aliveCells = aliveCandidates.concat(reviveCandidates);
  };
};
