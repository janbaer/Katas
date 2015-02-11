class Cell {
  constructor(x = 0, y = 0) {
    this.x = x;
    this.y = y;
  }

  equals(otherCell) {
    return this.x === otherCell.x && this.y === otherCell.y;
  }
}

class Game {
  constructor(...aliveCells) {
    this.aliveCells = aliveCells;
  }

  isAlive(cell, aliveCells = this.aliveCells) {
    // aliveCells = aliveCells || this.aliveCells;
    // var isAlive = aliveCells.some(aliveCell => {
    //   return aliveCell.equals(cell);
    // });
    var isAlive = false;

    for(let aliveCell of aliveCells) {
      if (aliveCell.equals(cell)) {
        isAlive = true;
        break;
      }
    }

    return isAlive;
  }

  getNeighborsOf(cell) {
    var neighbors = [];

    var range = [-1,0,1];

    for (let x of range) {
      for (let y of range) {
        var neighbor = new Cell(cell.x + x, cell.y + y);
        if (!neighbor.equals(cell)) {
          neighbors.push(neighbor);
        }
      }
    }

    return neighbors;
  }

  getAliveNeighborsOf(cell) {
    var neighbors = this.getNeighborsOf(cell);

    // var aliveNeighbors = neighbors.filter(neighbor => {
    //   return this.isAlive(neighbor);
    // });

    var aliveNeighbors = [];

    for (let neighbor of neighbors) {
      if (this.isAlive(neighbor)) {
        aliveNeighbors.push(neighbor);
      }
    }

    return aliveNeighbors;
  }

  getDeadNeighborsOf(cell) {
    var neighbors = this.getNeighborsOf(cell);

    var deadNeighbors = [];

    for (let neighbor of neighbors) {
      if (!this.isAlive(neighbor)) {
        deadNeighbors.push(neighbor);
      }
    }

    return deadNeighbors;
  }


  getReviveCandidates(aliveCells) {
    var candidates = [];

    aliveCells.forEach(aliveCell => {
      var deadNeighbors = this.getDeadNeighborsOf(aliveCell);

      for (let deadNeighbor of deadNeighbors) {
        if (this.getAliveNeighborsOf(deadNeighbor).length === 3) {
          candidates.push(deadNeighbor);
        }
      }
    });

    return candidates;
  }

  getAliveCandidates(aliveCells) {
    return aliveCells.filter(aliveCell => {
      var countOfAliveNeighbors = this.getAliveNeighborsOf(aliveCell).length;
      return countOfAliveNeighbors === 2 || countOfAliveNeighbors === 3;
    });
  }

  newGeneration() {
    var aliveCandidates = this.getAliveCandidates(this.aliveCells);
    var reviveCandidates = this.getReviveCandidates(this.aliveCells);

    this.aliveCells = aliveCandidates.concat(reviveCandidates);
  }
}