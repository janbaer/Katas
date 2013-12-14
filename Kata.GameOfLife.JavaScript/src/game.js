'use strict';

function Cell(x, y) {
  this.x = x;
  this.y = y;

  return this;
}
Cell.prototype.equals = function (otherCell) {
  return this.x === otherCell.x && this.y === otherCell.y;
}

function Grid() {
  this.aliveCells = Array.prototype.slice.call(arguments);
}

Grid.prototype.isAlive = function (cell) {
  var isAlive = false;

  this.aliveCells.forEach(function (aliveCell) {
    if (aliveCell.equals(cell)) {
      isAlive = true;
    }
  })
  return isAlive;
}

Grid.prototype.newGeneration = function () {
  var aliveCandidates = this.getAliveCandidates(this.aliveCells);
  var reviveCandidates = this.getReviveCandidates(this.aliveCells);

  this.aliveCells = aliveCandidates.concat(reviveCandidates);
}

Grid.prototype.getAliveCandidates = function (aliveCells) {
  var that = this;
  var candidates = [];

  aliveCells.forEach(function (aliveCell) {
    var countOfAliveNeighbors = that.getCountOfAliveNeighbors(aliveCell);
    if (countOfAliveNeighbors === 2 || countOfAliveNeighbors === 3) {
      candidates.push(aliveCell);
    }
  });
  return candidates;
};

Grid.prototype.getCountOfAliveNeighbors = function (cell) {
  var that = this;
  var aliveNeighbors = that.getNeighborsOf(cell, function (neighbor) {
    return that.isAlive(neighbor);
  });
  return aliveNeighbors.length;
};

Grid.prototype.getReviveCandidates = function (aliveCells) {
  var that = this;
  var candidates = [];

  aliveCells.forEach(function (aliveCell) {
    var deadNeighbors = that.getNeighborsOf(aliveCell, function (neighbor) {
      return !that.isAlive(neighbor);
    })
    deadNeighbors.forEach(function (neighbor) {
      if (that.getCountOfAliveNeighbors(neighbor) === 3) {
        candidates.push(neighbor);
      }
    })
  })

  return candidates;
};

Grid.prototype.getNeighborsOf = function (cell, filter) {
  var neighbors = [];

  for(var x=-1; x < 2; x++) {
    for (var y=-1; y<2; y++) {
      var neighbor = new Cell(cell.x + x, cell.y +y);
      if (!neighbor.equals(cell)) {
        if (filter === undefined || filter(neighbor)) {
          neighbors.push(neighbor);
        }
      }
    }
  }
  return neighbors;
};

