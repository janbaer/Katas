'use strict';

describe('Game Of Life Tests', function () {
  describe('When a cell is alive', function () {
    it('Should return true', function () {
      var grid = new Grid(new Cell(1,1));
      expect(grid.isAlive(new Cell(1,1))).toEqual(true);
    });
  });
  describe('When a cell is not alive', function () {
    it('Should return false', function () {
      var grid = new Grid(new Cell(1,1));
      expect(grid.isAlive(new Cell(1,2))).toEqual(false);
    });
  });
  describe('When alive cell has fewer than two alive neighbors', function () {
    it('Should died after new generation', function () {
      var grid = new Grid(new Cell(1,1), new Cell(1,2));
      grid.newGeneration();
      expect(grid.isAlive(new Cell(1,2))).toEqual(false);
    });
  });
  describe('When alive cell has two alive neighbors', function () {
    it('Should keep alive after new generation', function () {
      var grid = new Grid(new Cell(1,1), new Cell(1,2), new Cell(1,3));
      grid.newGeneration();
      expect(grid.isAlive(new Cell(1,2))).toEqual(true);
    });
  });
  describe('When alive cell has three alive neighbors', function () {
    it('Should keep alive after new generation', function () {
      var grid = new Grid(new Cell(1,1), new Cell(1,2), new Cell(1,3), new Cell(2,2));
      grid.newGeneration();
      expect(grid.isAlive(new Cell(1,2))).toEqual(true);
    });
  });
  describe('When alive cell has more than three alive neighbors', function () {
    it('Should died after new generation', function () {
      var grid = new Grid(new Cell(1,1), new Cell(1,2), new Cell(1,3), new Cell(2,2), new Cell(2,1));
      grid.newGeneration();
      expect(grid.isAlive(new Cell(1,2))).toEqual(false);
    });
  });
  describe('When a dead cell has three alive neighbors', function () {
    it('Should revive after new generation', function () {
      var grid = new Grid(new Cell(1,1), new Cell(1,3), new Cell(2,2));
      grid.newGeneration();
      expect(grid.isAlive(new Cell(1,2))).toEqual(true);
    });
  });
});
