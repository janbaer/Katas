'use strict';

/* globals Grid, Cell */

describe('GameOfLife spec', function () {
  describe('isAlive spec', function () {
    describe('When the given cell isAlive', function () {
      it('Should return true', function () {
        var grid = new Grid(new Cell(1, 1));
        expect(grid.isAlive(new Cell(1, 1))).toBe(true);
      });
    });
    describe('When the given cell is not alive', function () {
      it('Should return false', function () {
        var grid = new Grid(new Cell(0, 1));
        expect(grid.isAlive(new Cell(1, 1))).toBe(false);
      });
    });
  });
  describe('getNeighborsOf', function () {
    describe('For each given cell', function () {
      it('Should return 8 neighbors', function () {
        var cell = new Cell(1, 1);
        var neighbors = new Grid().getNeighborsOf(cell);
        expect(neighbors.length).toBe(8);
      });
    });
  });
  describe('getAliveNeighborsOf', function () {
    it('Should return just the neighbors that are alive', function () {
      var grid = new Grid(new Cell(1, 1), new Cell(1,2), new Cell(5,5));
      var neighbors = grid.getAliveNeighborsOf(new Cell(1, 1));
      expect(neighbors.length).toBe(1);
    });
  });
  describe('getDeadNeighborsOf', function () {
    it('Should return just the neighbors that are not alive', function () {
      var grid = new Grid(new Cell(1, 1), new Cell(1,2));
      var neighbors = grid.getDeadNeighborsOf(new Cell(1, 1));
      expect(neighbors.length).toBe(7);
    });
  });

  describe('newGeneration', function () {
    describe('When a living cell has fewer than three alive neighbors', function () {
      it('Should dies as if by underpopulation', function () {
        var grid = new Grid(new Cell(1, 1),
                            new Cell(1, 2),
                            new Cell(2, 1));
        grid.newGeneration();
        expect(grid.isAlive(new Cell(1, 1))).toBe(false);
      });
    });
    describe('When a living cell has three alive neighbors', function () {
      it('Should stay alive', function () {
        var grid = new Grid(new Cell(1, 1),
                            new Cell(1, 2),
                            new Cell(2, 1),
                            new Cell(2, 2));
        grid.newGeneration();
        expect(grid.isAlive(new Cell(1, 1))).toBe(true);
      });
    });
    describe('When a living cell has four alive neighbors', function () {
      it('Should stay alive', function () {
        var grid = new Grid(new Cell(1, 1),
                            new Cell(1, 2),
                            new Cell(2, 1),
                            new Cell(3, 1),
                            new Cell(2, 2));
        grid.newGeneration();
        expect(grid.isAlive(new Cell(2, 2))).toBe(true);
      });
    });
    describe('When a living cell has more than four alive neighbors', function () {
      it('Should dies as if by overpopulation', function () {
        var grid = new Grid(new Cell(1, 1),
                            new Cell(1, 2),
                            new Cell(2, 1),
                            new Cell(3, 1),
                            new Cell(2, 2),
                            new Cell(3, 2));
        grid.newGeneration();
        expect(grid.isAlive(new Cell(2, 2))).toBe(false);
      });
    });
    describe('When a dead cell has three alive neighbors', function () {
      it('Should be reborn', function () {
        var grid = new Grid(new Cell(1, 2),
                            new Cell(2, 1),
                            new Cell(2, 2));
        grid.newGeneration();
        expect(grid.isAlive(new Cell(1, 1))).toBe(true);
      });
    });
  });
});
