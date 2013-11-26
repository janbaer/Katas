'use strict';

var Cell = (function () {
  function Cell(x, y) {
    this.x = x;
    this.y = y;
  }
  Cell.prototype.equals = function (otherCell) {
    if (this.x === otherCell.x && this.y === otherCell.y) {
      return true;
    }
    return false;
  }
  return Cell;
})();

var Grid = (function () {
  function Grid() {
    this.aliveCells = Array.prototype.slice.call(arguments);
  }

  Grid.prototype.isAlive = function (x, y) {
    var result = false;
    var aliveCell = new Cell(x, y);

    this.aliveCells.forEach(function (cell) {
      if (aliveCell.equals(cell)) {
        result = true;
      }
    })
    return result;
  }

  Grid.prototype.getNeighboorsOf = function (cell, filter) {
    var neighboors = [];

    for (var x = -1; x < 2; x++) {
      for (var y = -1; y < 2; y++) {
        var neighboor = new Cell(cell.x + x, cell.y + y);
        if (!neighboor.equals(cell)) {
          if (filter === undefined || filter(neighboor)) {
            neighboors.push(neighboor);
          }
        }
      }
    }
    return neighboors;
  }

  Grid.prototype.getAliveNeighboorsOf = function (cell) {
    var that = this;

    return that.getNeighboorsOf(cell, function (neighboor) {
      return that.isAlive(neighboor.x, neighboor.y);
    });
  }

  Grid.prototype.getDeadNeighboorsOf = function (cell) {
    var that = this;

    return this.getNeighboorsOf(cell, function (neighboor) {
      return !that.isAlive(neighboor.x, neighboor.y);
    });
  }

  Grid.prototype.newGeneration = function () {
    var that = this;
    var aliveCandidates = [];
    var reviveCandidates = [];

    this.aliveCells.forEach(function (cell) {
      var countOfAliveNeightoors = that.getAliveNeighboorsOf(cell).length;
      if (countOfAliveNeightoors === 2 || countOfAliveNeightoors === 3) {
        aliveCandidates.push(cell);
      }

      var deadNeighboors = that.getDeadNeighboorsOf(cell);
      deadNeighboors.forEach(function (deadCell) {
        if (that.getAliveNeighboorsOf(deadCell).length === 3) {
          reviveCandidates.push(deadCell);
        }
      });
    })
    this.aliveCells = aliveCandidates.concat(reviveCandidates);
  }

  return Grid;
})();
