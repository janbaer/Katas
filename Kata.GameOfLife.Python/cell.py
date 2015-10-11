class Cell:
  def __init__(self, x, y):
    self.x = x
    self.y = y

  def __str__(self):
    return "x: {0}, y: {1}".format(self.x, self.y)

  def equals(self, otherCell):
    return self.x == otherCell.x and self.y == otherCell.y