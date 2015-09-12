import Foundation
import Swift

class Cell {
    var X:Int
    var Y:Int

    init(x:Int, y:Int) {
        self.X = x;
        self.Y = y;
    }

    func equals(anotherCell: Cell) -> Bool {
        return self.X == anotherCell.X &&
               self.Y == anotherCell.Y
    }
}


class Game {
    init(aliveCells: Cell...) {
        self.aliveCells = aliveCells
    }

    init(aliveCells: [Cell]) {
        self.aliveCells = aliveCells
    }

    var aliveCells:[Cell]

    func isAlive(cell:Cell) -> Bool {
        return self.aliveCells.contains({ aliveCell in
            return aliveCell.equals(cell)
        })
    }


    func getNeighborsOf(cell: Cell) -> [Cell] {
        var neighbors: [Cell] = []

        for x in -1...1 {
            for y in -1...1 {
                let neighbor = Cell(x: cell.X + x, y: cell.Y + y)
                if !cell.equals(neighbor) {
                    neighbors.append(neighbor)
                }
            }
        }

        return neighbors
    }


    func getAlifeNeighborsOf(cell: Cell) -> [Cell] {
        let neighbors = getNeighborsOf(cell)
        return neighbors.filter( { neighbor in
            return self.isAlive(neighbor)
        })
    }

    func getCountOfAliveNeighborsOf(cell: Cell) -> Int {
        return getAlifeNeighborsOf(cell).count
    }

    func containsCellPredicate(cell: Cell, anotherCell: Cell) -> Bool {
        return cell.equals(anotherCell)
    }

    func getReviveCandidates() -> [Cell] {
        var reviveCandidates: [Cell] = []

        for aliveCell in self.aliveCells {
            let deadNeighbors = getNeighborsOf(aliveCell).filter({ cell in
                return self.isAlive(cell) == false
            })

            for deadNeighbor in deadNeighbors {
                if getCountOfAliveNeighborsOf(deadNeighbor) == 3 {
                    if !reviveCandidates.contains({ candidate in
                        return candidate.equals(deadNeighbor)
                    }) {
                        reviveCandidates.append(deadNeighbor)
                    }
                }
            }

        }

        return reviveCandidates
    }

    func newGeneration() -> Game {
        var aliveCandidates = self.aliveCells.filter({ aliveCell in
            let count = getCountOfAliveNeighborsOf(aliveCell)
            return count == 2 || count == 3
        })

        let reviveCandidates = getReviveCandidates()

        aliveCandidates.appendContentsOf(reviveCandidates)

        return Game(aliveCells:aliveCandidates)
    }


}

