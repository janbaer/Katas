/* globals Grid, Cell */

'use strict';

describe('GameOfLife spec', function () {
  describe('isAlive spec', function () {
    describe('When a cell is alive', function () {
      it('Should return true', function () {
        var grid = new Grid(new Cell(1,1));
        expect(grid.isAlive(new Cell(1,1))).toBe(true);
      });
    });

    describe('When cell is not alive', function () {
      it('Should return false', function () {
        var grid = new Grid(new Cell(1,2));
        expect(grid.isAlive(new Cell(1,1))).toBe(false);
      });
    });
  });

  describe('newGeneratin spec', function () {
    describe('When a alive cell has fewer than two alive neighbors', function () {
      it('Should return false', function () {
        var grid = new Grid(new Cell(1,1), new Cell(1,2));
        grid.newGeneration();
        expect(grid.isAlive(new Cell(1,2))).toBe(false);
      });
    });

    describe('When a alive cell has two alive neighbors', function () {
      it('Should still alive', function () {
        var grid = new Grid(new Cell(1,1), new Cell(1,2), new Cell(1,3));
        grid.newGeneration();
        expect(grid.isAlive(new Cell(1,2))).toBe(true);
      });
    });

    describe('When a alivecell has three alive neighbors', function () {
      it('Should still alive', function () {
        var grid = new Grid(new Cell(1,1), new Cell(1,2), new Cell(1,3), new Cell(2,2));
        grid.newGeneration();
        expect(grid.isAlive(new Cell(1,2))).toBe(true);
      });
    });

    describe('When a alive cell has more than three alive neighbors', function () {
      it('Should die as is by overpopulation', function () {
        var grid = new Grid(new Cell(1,1), new Cell(1,2), new Cell(1,3), new Cell(2,2), new Cell(2,1));
        grid.newGeneration();
        expect(grid.isAlive(new Cell(1,2))).toBe(false);
      });
    });

    describe('When a dead cell has three alive neighbors', function () {
      it('Should revive after new generation', function () {
        var grid = new Grid(new Cell(1,1), new Cell(1,3), new Cell(2,2));
        grid.newGeneration();
        expect(grid.isAlive(new Cell(1,2))).toBe(true);
      });
    });
  });
});
