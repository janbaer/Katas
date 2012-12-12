describe("GameOfLife", function () {
    var cell;

    beforeEach(function () {

    });

    describe("Alive cells with fewer than two alive neighboors", function () {
        it("should be killed after newgeneration", function () {

            var grid = new Grid(new Array(new Cell(1,1), new Cell(1,2)));
            grid.newGeneration();

            var isAlive = grid.isAlive(new Cell(1,1));          
            
            expect(isAlive).toEqual(false);

        });
    });

    describe("Alive cells with two alive neighboors", function () {
        it("should be keep alive after newgeneration", function () {

            var grid = new Grid(new Array(new Cell(1,1), new Cell(1,2), new Cell(1,3)));
            grid.newGeneration();

            var isAlive = grid.isAlive(new Cell(1,2));          
            
            expect(isAlive).toEqual(true);

        });
    });

    describe("Alive cells with three alive neighboors", function () {
        it("should be keep alive after newgeneration", function () {

            var grid = new Grid(new Array(new Cell(1,1), new Cell(1,2), new Cell(1,3), new Cell(2,2)));
            grid.newGeneration();

            var isAlive = grid.isAlive(new Cell(1,2));          
            
            expect(isAlive).toEqual(true);

        });
    });

    describe("Alive cells with more than three alive neighboors", function () {
        it("should be died after newgeneration", function () {

            var grid = new Grid(new Array(new Cell(1,1), new Cell(1,2), new Cell(2,1), new Cell(3,1), new Cell(2,2)));
            grid.newGeneration();

            var isAlive = grid.isAlive(new Cell(2,2));

            expect(isAlive).toEqual(false);

        });
    });

    describe("Dead cells with three alive neighboors", function () {
        it("should be alive after newgeneration", function () {

            var grid = new Grid(new Array(new Cell(1,1), new Cell(1,2), new Cell(1,3)));
            grid.newGeneration();

            var isAlive = grid.isAlive(new Cell(2,2));          
            
            expect(isAlive).toEqual(true);

        });
    });


    describe("getCountOfAliveNeighbors for a cell with two alive neighbors", function () {
        it("should return 2", function () {

            var grid = new Grid(new Array(new Cell(1,1), new Cell(2,1), new Cell(3,1)));

            var count = grid.getCountOfAliveNeighbors(new Cell(2,1));   
            
            expect(count).toEqual(2);

        });
    });

    describe("getDeadNeighborsOf for an cell", function () {
        it("should return all dead cells", function () {

            var grid = new Grid(new Array(new Cell(1,1)));

            var deadNeighbors = grid.getDeadNeighborsOf(new Cell(2,1));   
            
            expect(deadNeighbors.length).toEqual(7);

        });
    });    

    describe("isAlive for an alive cell", function () {
        it("should return true", function () {

            var grid = new Grid(new Array(new Cell(1,1)));

            var isAlive = grid.isAlive(new Cell(1,1));   
            
            expect(isAlive).toEqual(true);

        });
    });

    describe("isAlive for an dead cell", function () {
        it("should return false", function () {

            var grid = new Grid();

            var isAlive = grid.isAlive(new Cell(1,1));   
            
            expect(isAlive).toEqual(false);

        });
    });



    describe("getNeighborsOf for a cell", function () {
        it("should return 8 neighbors", function () {

            var grid = new Grid();

            var neighbors = grid.getNeighborsOf(new Cell(2,2));        
            
            expect(neighbors.length).toEqual(8);

        });
    });



   
});

