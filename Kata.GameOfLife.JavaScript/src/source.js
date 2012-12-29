var GameOfLife;
(function (GameOfLife) {
    var Cell = (function () {
        function Cell(x, y) {
            this.X = x;
            this.Y = y;
        }
        Cell.prototype.equals = function (other) {
            if(other == null || other === undefined) {
                return false;
            }
            return this.X == other.X && this.Y == other.Y;
        };
        return Cell;
    })();
    GameOfLife.Cell = Cell;    
    var Grid = (function () {
        function Grid(initialAliveCells) {
            if(initialAliveCells === undefined) {
                initialAliveCells = [];
            }
            this.aliveCells = initialAliveCells;
        }
        Grid.prototype.isAlive = function (cell) {
            var isAlive = false;
            _.each(this.aliveCells, function (c) {
                if(cell.equals(c)) {
                    isAlive = true;
                }
            });
            return isAlive;
        };
        Grid.prototype.getNeighborsOf = function (cell) {
            var neigbors = [];
            _.each(_.range(-1, 2), function (x) {
                _.each(_.range(-1, 2), function (y) {
                    var c = new Cell(cell.X + x, cell.Y + y);
                    if(cell.equals(c) == false) {
                        neigbors.push(c);
                    }
                });
            });
            return neigbors;
        };
        Grid.prototype.getCountOfAliveNeighbors = function (cell) {
            var neighbors = this.getNeighborsOf(cell);
            var count = 0;
            var that = this;
            _.each(neighbors, function (neighbor) {
                if(that.isAlive(neighbor)) {
                    count++;
                }
            });
            return count;
        };
        Grid.prototype.getDeadNeighborsOf = function (cell) {
            var that = this;
            var neighbors = this.getNeighborsOf(cell);
            var deadNeighbors = [];
            _.each(neighbors, function (neighbor) {
                if(that.isAlive(neighbor) == false) {
                    deadNeighbors.push(neighbor);
                }
            });
            return deadNeighbors;
        };
        Grid.prototype.newGeneration = function () {
            var aliveCandidates = this.getAliveCandidates(this.aliveCells);
            var reviveCandidates = this.getReviveCandidates(this.aliveCells);
            return new Grid(aliveCandidates.concat(reviveCandidates));
        };
        Grid.prototype.getAliveCandidates = function (aliveCells) {
            var that = this;
            var aliveCandidates = [];
            _.each(aliveCells, function (cell) {
                var numberOfAliveNeighbors = that.getCountOfAliveNeighbors(cell);
                if(numberOfAliveNeighbors == 2 || numberOfAliveNeighbors == 3) {
                    aliveCandidates.push(cell);
                }
            });
            return aliveCandidates;
        };
        Grid.prototype.getReviveCandidates = function (aliveCells) {
            var that = this;
            var candidates = [];
            _.each(aliveCells, function (cell) {
                var deadNeighbors = that.getDeadNeighborsOf(cell);
                _.each(deadNeighbors, function (c) {
                    if(that.getCountOfAliveNeighbors(c) == 3) {
                        if(that.containsCell(candidates, c) == false) {
                            candidates.push(c);
                        }
                    }
                });
            });
            return candidates;
        };
        Grid.prototype.containsCell = function (cells, cell) {
            var containsCell = false;
            _.each(cells, function (c) {
                if(c.equals(cell)) {
                    containsCell = true;
                }
            });
            return containsCell;
        };
        return Grid;
    })();
    GameOfLife.Grid = Grid;    
})(GameOfLife || (GameOfLife = {}));