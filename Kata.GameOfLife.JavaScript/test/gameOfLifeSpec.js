'use strict';

/* globals Grid, Cell */

describe('GameOfLife spec', function () {
  describe('When a cell is alive', function () {
    it('Should return true', function () {
      var grid = new Grid(new Cell(1,1));
      expect(grid.isAlive(new Cell(1,1))).toBe(true);
    });
  });

  describe('When a cell on the given position is not alive', function () {
    it('Should return false', function () {
      var grid = new Grid(new Cell(1,1));
      expect(grid.isAlive(new Cell(0,1))).toBe(false);
    });
  });

  describe('newGeneration', function () {
    describe('When a living cell has fewer than three alive neighbors', function () {
      it('Should die', function () {
        var grid = new Grid(new Cell(1,1), new Cell(1, 2), new Cell(2, 2));
        grid.newGeneration();
        expect(grid.isAlive(new Cell(1,1))).toBe(false);
      });
    });

    describe('When a living cell has three alive neighbors', function () {
      it('Should stay alive', function () {
        var grid = new Grid(new Cell(1,1),
                            new Cell(2,1),
                            new Cell(2,2),
                            new Cell(1,2));
        grid.newGeneration();
        expect(grid.isAlive(new Cell(1,1))).toBe(true);
      });
    });

    describe('When a living cell has four alive neighbors', function () {
      it('Should stay alive', function () {
        var grid = new Grid(new Cell(1,1),
                            new Cell(2,1),
                            new Cell(3,2),
                            new Cell(1,2),
                            new Cell(2,2));
        grid.newGeneration();
        expect(grid.isAlive(new Cell(2,1))).toBe(true);
      });
    });

    describe('When a dead cell has three alive neighbors', function () {
      it('Should revive after new generation', function () {
        var grid = new Grid(new Cell(1,2),
                            new Cell(2,2),
                            new Cell(2,1));
        grid.newGeneration();
        expect(grid.isAlive(new Cell(1,1))).toBe(true);
      });
    });

    describe('When a cell has more than four alive neighbors', function () {
      it('Should dies as if by overcrowding ', function () {

      });
    });
  });
});
