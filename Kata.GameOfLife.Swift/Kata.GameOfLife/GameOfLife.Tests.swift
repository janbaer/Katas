import XCTest

class Kata_GameOfLife: XCTestCase {
    
    override func setUp() {
        super.setUp()
        // Put setup code here. This method is called before the invocation of each test method in the class.
    }
    
    override func tearDown() {
        // Put teardown code here. This method is called after the invocation of each test method in the class.
        super.tearDown()
    }
    
    func testWhenCellIsAlife_ItShouldReturnTrue() {
        let game = Game(aliveCells: Cell(x:1, y:1))
        
        let isAlive = game.isAlive(Cell(x:1, y:1))
        
        XCTAssertTrue(isAlive)
    }

    func testWhenCellIsAlife_ItShouldReturnFalse() {
        let game = Game(aliveCells: Cell(x:1, y:1))
        
        let isAlive = game.isAlive(Cell(x:1, y:2))
        
        XCTAssertFalse(isAlive)
    }
    
    func testWhenAlifeCellHasLessThanTwoAliveNeighbors_ItShouldDie() {
        var game = Game(aliveCells: Cell(x:1, y:1), Cell(x:1, y: 2))
        
        game = game.newGeneration()
        
       
        XCTAssertFalse(game.isAlive(Cell(x:1, y:2)))
    }
    
    func testWhenAlifeCellHasTwoAliveNeighbors_ItShouldSurvive() {
        var game = Game(aliveCells: Cell(x:1, y:1), Cell(x:1, y: 2), Cell(x:2, y:1))
        
        game = game.newGeneration()
        
        XCTAssertTrue(game.isAlive(Cell(x:1, y:1)))
    }

    func testWhenAlifeCellHasThreeAliveNeighbors_ItShouldSurvive() {
        var game = Game(aliveCells: Cell(x:1, y:1), Cell(x:1, y: 2),
                                    Cell(x:2, y:1), Cell(x:2, y: 2))
        game = game.newGeneration()
        
        XCTAssertTrue(game.isAlive(Cell(x:1, y:1)))
    }

    func testWhenAlifeCellHasMoreThanThreeAliveNeighbors_ItShouldDie() {
        var game = Game(aliveCells: Cell(x:1, y:1), Cell(x:1, y: 2),
                                    Cell(x:2, y:1), Cell(x:2, y: 2),
                                    Cell(x: 3, y: 1))
        game = game.newGeneration()
        
        XCTAssertFalse(game.isAlive(Cell(x:2, y:1)))
    }

    func testWhenADeadCellHasThreeAliveNeighbors_ItShouldRevieve() {
        var game = Game(aliveCells: Cell(x:1, y:1),
                                    Cell(x:2, y: 2),
                                    Cell(x: 3, y: 1))
        game = game.newGeneration()
        
        XCTAssertTrue(game.isAlive(Cell(x:2, y:1)))
    }

    
}
