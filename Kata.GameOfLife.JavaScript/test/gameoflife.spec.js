/* globals Game, Cell */

describe('Game of life spec', function () {
  'use strict';

  describe('isAlive', function () {
    describe('When a cell is alive', function () {
      beforeEach(function () {
        this.game = new Game(new Cell(0, 0));

        this.isAlive = this.game.isAlive(new Cell(0, 0));
      });

      it('Should return true', function () {
        expect(this.isAlive).toEqual(true);
      });
    });

    describe('When a cell is not alive', function () {
      beforeEach(function () {
        this.game = new Game(new Cell(0, 0));

        this.isAlive = this.game.isAlive(new Cell(0, 1));
      });

      it('Should return false', function () {
        expect(this.isAlive).toEqual(false);
      });
    });
  });

  describe('nextGeneration', function () {
    describe('When a living cell has fewer than two alive neighbors', function () {
      beforeEach(function () {
        this.game = new Game(new Cell(0, 0));

        this.game.newGeneration();

        this.isAlive = this.game.isAlive(new Cell(0,0));
      });

      it('Should die after new generation', function () {
        expect(this.isAlive).toEqual(false);
      });
    });

    describe('When a living cell has two alive neighbors', function () {
      beforeEach(function () {
        this.game = new Game(new Cell(1, 1), new Cell(2,1), new Cell(1, 2));

        this.game.newGeneration();

        this.isAlive = this.game.isAlive(new Cell(1,1));
      });

      it('Should stay alive', function () {
        expect(this.isAlive).toEqual(true);
      });
    });

    describe('When a living cell has three alive neighbors', function () {
      beforeEach(function () {
        this.game = new Game(new Cell(1, 1), new Cell(2,1), new Cell(1, 2), new Cell(2, 2));

        this.game.newGeneration();

        this.isAlive = this.game.isAlive(new Cell(1,1));
      });

      it('Should stay alive', function () {
        expect(this.isAlive).toEqual(true);
      });
    });

    describe('When a dead cell has three alive neighbors', function () {
      beforeEach(function () {
        this.game = new Game(new Cell(2,1), new Cell(1, 2), new Cell(2, 2));

        this.game.newGeneration();

        this.isAlive = this.game.isAlive(new Cell(1,1));
      });

      it('Should review by reproduction', function () {
        expect(this.isAlive).toEqual(true);
      });
    });

    describe('When a living cell has more than three alive neighbors', function () {
      beforeEach(function () {
        this.game = new Game(new Cell(1, 1), new Cell(2,1), new Cell(3,1), new Cell(1, 2), new Cell(2, 2));

        this.game.newGeneration();

        this.isAlive = this.game.isAlive(new Cell(2,1));
      });

      it('Should die because overcrowding', function () {
        expect(this.isAlive).toEqual(false);
      });
    });
  });
});