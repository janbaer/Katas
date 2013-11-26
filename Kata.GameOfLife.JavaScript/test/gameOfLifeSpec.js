'use strict';

describe('Game Of Life Tests', function () {
  describe('When the cell on the given position is alive', function () {
    it('Should return true', function () {
      var grid = new Grid(new Cell(1,1));
      expect(grid.isAlive(1,1)).toEqual(true);
    });
  });

  describe('When the cell on the given position is not alive', function () {
    it('Should return false', function () {
      var grid = new Grid(new Cell(1,1));
      expect(grid.isAlive(1,2)).toEqual(false);
    });
  });

  describe('Any alive cells with fewer than 2 alive neighboors', function () {
    it('Should be killed after new generation', function () {
      var grid = new Grid(new Cell(1,1));
      grid.newGeneration();
      expect(grid.isAlive(1,1)).toEqual(false);
    });
  });

  describe('Any alive cells with two alive neighboors', function () {
    it('Should keep alive after new generation', function () {
      var grid = new Grid(new Cell(1,1), new Cell(1,2), new Cell(1,3));
      grid.newGeneration();
      expect(grid.isAlive(1,2)).toEqual(true);
    });
  });

  describe('Any alive cells with three alive neigboors', function () {
    it('Should stay alive after new generation', function () {
      var grid = new Grid(new Cell(1,1), new Cell(1,2), new Cell(1,3), new Cell(2,2));
      grid.newGeneration();
      expect(grid.isAlive(1,2)).toEqual(true);
    });
  });

  describe('Any alive cell with more than three alive neighboors', function () {
    it('Should die after new generation', function () {
      var grid = new Grid(new Cell(1,1), new Cell(1,2), new Cell(1,3), new Cell(2,1), new Cell(2,2));
      grid.newGeneration();
      expect(grid.isAlive(1,2)).toEqual(false);
    });
  });

  describe('Any dead cell with exactly three alive neighboors', function () {
    it('Should be reborn after new generation', function () {
      var grid = new Grid(new Cell(1,1), new Cell(1,3), new Cell(2,2));
      grid.newGeneration();
      expect(grid.isAlive(1,2)).toEqual(true);
    });
  });

});
