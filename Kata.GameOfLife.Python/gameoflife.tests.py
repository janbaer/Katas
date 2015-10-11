import unittest

from cell import Cell
from game import Game

class GameOfLifeTests(unittest.TestCase):
  def test_ShouldBeAlive(self):
    game = Game(Cell(1, 1))
    self.assertTrue(game.isAlive(Cell(1, 1)))

  def test_shouldNotBeAlive(self):
    game = Game(Cell(1, 1))
    self.assertFalse(game.isAlive(Cell(1, 2)))

  #@unittest.skip("demonstrating skipping")
  def test_when_Cell_Has_Less_Than_TwoAliveNeighbors_it_should_die(self):
    game = Game(Cell(1,1), Cell(1, 2))
    game = game.newGeneration()
    self.assertFalse(game.isAlive(Cell(1, 1)))

  def test_when_Cell_Has_Two_Alive_Neighbors_it_should_stay_alive(self):
    game = Game(Cell(1,1), Cell(1, 2), Cell(2, 1))
    game = game.newGeneration()
    self.assertTrue(game.isAlive(Cell(1, 1)))

  def test_when_Cell_Has_Three_Alive_Neighbors_it_should_stay_alive(self):
    game = Game(Cell(1,1), Cell(1, 2), Cell(2, 1), Cell(2, 2))
    game = game.newGeneration()
    self.assertTrue(game.isAlive(Cell(1, 1)))

  def test_when_Cell_Has_For_Alive_Neighbors_it_should_die_by_overpopulation(self):
    game = Game(Cell(1,1), Cell(1, 2), Cell(2, 1), Cell(2, 2), Cell(1, 3))
    game = game.newGeneration()
    self.assertFalse(game.isAlive(Cell(1, 2)))

  def test_when_dead_Cell_Has_Three_Alive_Neighbors_it_should_revive(self):
    game = Game(Cell(1, 2), Cell(2, 1), Cell(2, 2))
    game = game.newGeneration()
    self.assertTrue(game.isAlive(Cell(1, 1)))

if __name__ == '__main__':
    unittest.main()