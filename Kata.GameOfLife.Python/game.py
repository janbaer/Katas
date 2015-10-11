from cell import Cell

class Game:
  def __init__(self, *args):
    self.aliveCells = []

    if (isinstance(args[0], list)):
      self.aliveCells = args[0]
    else:
      for aliveCell in args:
        self.aliveCells.append(aliveCell)

  def isAlive(self, cell):
    return any(aliveCell.equals(cell) for aliveCell in self.aliveCells)

  def getNeighborsOf(self, cell):
    neighbors = []

    for x in range(-1, 2):
      for y in range(-1, 2):
        neighbor = Cell(cell.x + x, cell.y + y)
        if (cell.equals(neighbor) == False):
          neighbors.append(neighbor)

    return neighbors

  def getAliveNeighborsOf(self, cell):
    neighbors = self.getNeighborsOf(cell)
    return [neighbor for neighbor in neighbors if self.isAlive(neighbor)]

  def getCountOfAliveNeighborsOf(self, cell):
    return len(self.getAliveNeighborsOf(cell))

  def getAliveCandidates(self):
    aliveCandidates = []

    for aliveCell in self.aliveCells:
      count = self.getCountOfAliveNeighborsOf(aliveCell)
      if count == 2 or count == 3:
        aliveCandidates.append(aliveCell)

    return aliveCandidates

  def getDeadNeighborsOf(self, cell):
    neighbors = self.getNeighborsOf(cell)
    return [neighbor for neighbor in neighbors if self.isAlive(neighbor) == False]

  def getReviveCandidates(self):
    reviveCandidates = []

    for aliveCell in self.aliveCells:
      deadNeighbors = self.getDeadNeighborsOf(aliveCell)
      for deadNeighbor in deadNeighbors:
        if (self.getCountOfAliveNeighborsOf(deadNeighbor) == 3):
          reviveCandidates.append(deadNeighbor)

    return reviveCandidates

  def newGeneration(self):
    aliveCandidates = self.getAliveCandidates()
    reviveCandidates = self.getReviveCandidates()
    return Game(aliveCandidates + reviveCandidates)
