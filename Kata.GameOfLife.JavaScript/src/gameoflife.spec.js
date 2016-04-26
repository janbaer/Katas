/* globals Cell, Game */
'use strict';

//import { Cell, Game } from 'gameoflife.js';

describe('Game of life spec', function() {
  describe('isAlive tests', function() {
    describe('When a cell is alive', function() {
      beforeEach(function() {
        this.game = new Game(new Cell(0, 0));
      });

      it('Should return true', function() {
        expect(this.game.isAlive(new Cell(0, 0))).toEqual(true);
      });
    });

    describe('When a cell is not alive', function() {
      beforeEach(function() {
        this.game = new Game(new Cell(0, 0));
      });

      it('Should return false', function() {
        expect(this.game.isAlive(new Cell(0, 1))).toEqual(false);
      });
    });
  });


  describe('NewGeneration tests', function() {
    describe('When a living cell has 2 alive neighbors', function() {
      beforeEach(function() {
        this.game = new Game(new Cell(0, 0), new Cell(0, 1), new Cell(1,1));

        this.game.newGeneration();
      });

      it('Should stay alive', function() {
        expect(this.game.isAlive(new Cell(0, 0))).toEqual(true);
      });
    });

    describe('When a living cell has less than 2 alive neighbors', function() {
      beforeEach(function() {
        this.game = new Game(new Cell(0, 0), new Cell(0, 1));

        this.game.newGeneration();
      });

      it('Should stay alive', function() {
        expect(this.game.isAlive(new Cell(0, 0))).toEqual(false);
      });
    });

  });
});
