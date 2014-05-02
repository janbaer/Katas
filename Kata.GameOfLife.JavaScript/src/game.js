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
};

Grid.prototype.isAlive = function (cell) {
  return this.aliveCells.some(function (aliveCell) {
    return aliveCell.equals(cell);
  });
};

Grid.prototype.getNeighborsOf = function (cell) {
  var neighbors = [];
  for (var x = -1; x < 2; x++) {
    for (var y = -1; y < 2; y++) {
      var neighbor = new Cell(cell.x + x, cell.y + y);
      if (!neighbor.equals(cell)) {
        neighbors.push(neighbor);
      }
    }
  }
  return neighbors;
};

Grid.prototype.getAliveNeighborsOf = function (cell) {
  return this.getNeighborsOf(cell).filter(function (c) {
    return this.isAlive(c);
  }.bind(this));
};

Grid.prototype.getDeadNeighborsOf = function (cell) {
  return this.getNeighborsOf(cell).filter(function (c) {
    return !this.isAlive(c);
  }.bind(this));
};

Grid.prototype.getAliveCandidates = function (aliveCells) {
  return aliveCells.filter(function (aliveCell) {
    var aliveNeighbors = this.getAliveNeighborsOf(aliveCell);
    return (aliveNeighbors.length === 3 || aliveNeighbors.length === 4);
  }.bind(this));
};

Grid.prototype.getReviveCandidates = function (aliveCells) {
  var reviveCandidates = [];

  this.aliveCells.forEach(function (aliveCell) {
    var deadNeighbors = this.getDeadNeighborsOf(aliveCell);
    deadNeighbors.forEach(function (deadNeighbor) {
      if (this.getAliveNeighborsOf(deadNeighbor).length === 3) {
        reviveCandidates.push(deadNeighbor);
      }
    }.bind(this));
  }.bind(this));

  return reviveCandidates;
};

Grid.prototype.newGeneration = function () {
  var aliveCandidates = this.getAliveCandidates(this.aliveCells);
  var reviveCandidates = this.getReviveCandidates(this.aliveCells);

  this.aliveCells = aliveCandidates.concat(reviveCandidates);
};
