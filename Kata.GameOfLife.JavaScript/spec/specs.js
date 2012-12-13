/// <reference path="../lib/underscore.js" />
/// <reference path="../src/source.js" />

describe("GameOfLife", function () {
    var Cell = GameOfLife.Cell;
    
    beforeEach(function () {

    });

    describe("Alive cells with fewer than two alive neighboors", function () {
        it("should be killed after newgeneration", function () {

            var grid = new GameOfLife.Grid(new Array(new Cell(1, 1), new Cell(1, 2)));
            grid = grid.newGeneration();

            var isAlive = grid.isAlive(new GameOfLife.Cell(1, 1));
            
            expect(isAlive).toEqual(false);

        });
    });

    describe("Alive cells with two alive neighboors", function () {
        it("should be keep alive after newgeneration", function () {

            var grid = new GameOfLife.Grid(new Array(new GameOfLife.Cell(1, 1), new GameOfLife.Cell(1, 2), new GameOfLife.Cell(1, 3)));
            grid = grid.newGeneration();

            var isAlive = grid.isAlive(new GameOfLife.Cell(1, 2));
            
            expect(isAlive).toEqual(true);

        });
    });

    describe("Alive cells with three alive neighboors", function () {
        it("should be keep alive after newgeneration", function () {

            var grid = new GameOfLife.Grid(new Array(new Cell(1, 1), new Cell(1, 2), new Cell(1, 3), new Cell(2, 2)));
            grid = grid.newGeneration();

            var isAlive = grid.isAlive(new GameOfLife.Cell(1, 2));
            
            expect(isAlive).toEqual(true);

        });
    });

    describe("Alive cells with more than three alive neighboors", function () {
        it("should be died after newgeneration", function () {

            var grid = new GameOfLife.Grid(new Array(new Cell(1, 1), new Cell(1, 2), new Cell(2, 1), new Cell(3, 1), new Cell(2, 2)));
            grid = grid.newGeneration();

            var isAlive = grid.isAlive(new Cell(2,2));

            expect(isAlive).toEqual(false);

        });
    });

    describe("Dead cells with three alive neighboors", function () {
        it("should be alive after newgeneration", function () {

            var grid = new GameOfLife.Grid(new Array(new Cell(1, 1), new Cell(1, 2), new Cell(1, 3)));
            grid = grid.newGeneration();

            var isAlive = grid.isAlive(new Cell(2,2));          
            
            expect(isAlive).toEqual(true);

        });
    });


    describe("getCountOfAliveNeighbors for a cell with two alive neighbors", function () {
        it("should return 2", function () {

            var grid = new GameOfLife.Grid(new Array(new Cell(1, 1), new Cell(2, 1), new Cell(3, 1)));

            var count = grid.getCountOfAliveNeighbors(new Cell(2,1));   
            
            expect(count).toEqual(2);

        });
    });

    describe("getDeadNeighborsOf for an cell", function () {
        it("should return all dead cells", function () {

            var grid = new GameOfLife.Grid(new Array(new Cell(1, 1)));

            var deadNeighbors = grid.getDeadNeighborsOf(new Cell(2,1));   
            
            expect(deadNeighbors.length).toEqual(7);

        });
    });    

    describe("isAlive for an alive cell", function () {
        it("should return true", function () {

            var grid = new GameOfLife.Grid(new Array(new Cell(1, 1)));

            var isAlive = grid.isAlive(new Cell(1,1));   
            
            expect(isAlive).toEqual(true);

        });
    });

    describe("isAlive for an dead cell", function () {
        it("should return false", function () {

            var grid = new GameOfLife.Grid();

            var isAlive = grid.isAlive(new Cell(1,1));   
            
            expect(isAlive).toEqual(false);

        });
    });



    describe("getNeighborsOf for a cell", function () {
        it("should return 8 neighbors", function () {

            var grid = new GameOfLife.Grid();

            var neighbors = grid.getNeighborsOf(new Cell(2,2));        
            
            expect(neighbors.length).toEqual(8);

        });
    });

    describe("Cell.equals with another cell", function () {
        it("should return true if X and Y are equals", function () {

            var cell1 = new GameOfLife.Cell(1, 1);
            var cell2 = new GameOfLife.Cell(1, 1);

            var equals = cell1.equals(cell2);
            
            expect(equals).toEqual(true);

        });
        
        it("should return false if X ia different", function () {

            var cell1 = new GameOfLife.Cell(1, 1);
            var cell2 = new GameOfLife.Cell(2, 1);

            var equals = cell1.equals(cell2);

            expect(equals).toEqual(false);

        });
        
        it("should return false if Y is different", function () {

            var cell1 = new GameOfLife.Cell(1, 1);
            var cell2 = new GameOfLife.Cell(1, 2);

            var equals = cell1.equals(cell2);

            expect(equals).toEqual(false);

        });
        
        it("should return false if the other cell is null", function () {

            var cell1 = new GameOfLife.Cell(1, 1);

            var equals = cell1.equals(null);

            expect(equals).toEqual(false);

        });
        
        it("should return false if the other cell is undefined", function () {

            var cell1 = new GameOfLife.Cell(1, 1);

            var equals = cell1.equals();

            expect(equals).toEqual(false);

        });
    });

   
});

