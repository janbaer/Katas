declare var _;
module GameOfLife {
    export class Cell {
        public X: number;
        public Y: number;

        constructor(x: number, y: number) {
            this.X = x;
            this.Y = y;
        }

        equals(other: Cell) {
            if (other == null || other === undefined) {
                return false;
            }
            return this.X == other.X && this.Y == other.Y;
        }
    }

    export class Grid {

        aliveCells: Cell[];

        constructor(initialAliveCells: Cell[]) {
            if (initialAliveCells === undefined) {
                initialAliveCells = [];
            }
            this.aliveCells = initialAliveCells;
        }

        public isAlive(cell: Cell) {
            var isAlive = false;

            _.each(this.aliveCells, function (c: Cell) {
                if (cell.equals(c)) {
                    isAlive = true;
                }
            });

            return isAlive;
        }

        public getNeighborsOf(cell: Cell) {
            var neigbors = [];

            _.each(_.range(-1, 2), function (x: number) {
                _.each(_.range(-1, 2), function (y: number) {

                    var c = new Cell(cell.X + x, cell.Y + y);

                    if (cell.equals(c) == false) {
                        neigbors.push(c);
                    }

                });
            });

            return neigbors;
        }

        public getCountOfAliveNeighbors(cell: Cell) {
            var neighbors = this.getNeighborsOf(cell);

            var count = 0;

            var that = this;

            _.each(neighbors, function (neighbor: Cell) {
                if (that.isAlive(neighbor)) {
                    count++;
                }

            });

            return count;
        }

        public getDeadNeighborsOf(cell: Cell) {
            var that = this;

            var neighbors = this.getNeighborsOf(cell);
            var deadNeighbors = [];

            _.each(neighbors, function (neighbor: Cell) {
                if (that.isAlive(neighbor) == false) {
                    deadNeighbors.push(neighbor);
                }
            });

            return deadNeighbors;
        }

        public newGeneration() {
            var aliveCandidates = this.getAliveCandidates(this.aliveCells);

            var reviveCandidates = this.getReviveCandidates(this.aliveCells);

            return new Grid(aliveCandidates.concat(reviveCandidates));
        }

        private getAliveCandidates(aliveCells) {
            var that = this;
            var aliveCandidates = [];

            _.each(aliveCells, function (cell: Cell) {
                var numberOfAliveNeighbors = that.getCountOfAliveNeighbors(cell);

                if (numberOfAliveNeighbors == 2 || numberOfAliveNeighbors == 3) {
                    aliveCandidates.push(cell);
                }
            });

            return aliveCandidates;
        }

        private getReviveCandidates(aliveCells) {
            var that = this;
            var candidates = [];

            _.each(aliveCells, function (cell) {
                var deadNeighbors = that.getDeadNeighborsOf(cell);

                _.each(deadNeighbors, function (c: Cell) {
                    if (that.getCountOfAliveNeighbors(c) == 3) {
                        if (that.containsCell(candidates, c) == false) {
                            candidates.push(c);
                        }
                    }
                });
            });

            return candidates;
        }

        private containsCell(cells: Cell[], cell: Cell) {
            var containsCell = false;

            _.each(cells, function (c: Cell) {
                if (c.equals(cell)) {
                    containsCell = true;
                }

            });

            return containsCell;

        }
    }
}