'use strict';

class Cell {
  constructor(x, y) {
    this.x = x;
    this.y = y;
  }

  equals(anotherCell) {
   return this.x === anotherCell.x &&
          this.y === anotherCell.y;
  }
}

class Game {
  constructor(...aliveCells) {
    this.aliveCells = aliveCells;
  }

  isAlive(cell) {
    return this.aliveCells.some((aliveCell) => aliveCell.equals(cell));
  }

  newGeneration() {
  }
}
