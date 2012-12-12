
var Cell = function (x, y) {
	"use strict";

	this.X = x;
	this.Y = y;
};


var Grid = function (initialAliveCells) {
	"use strict";

	var that = this;

	if (initialAliveCells === undefined) {
		initialAliveCells = [];
	}

	var aliveCells = initialAliveCells;

	this.isAlive = function (cell) {
		var isAlive = false;

		_.each(aliveCells, function(c) {
			if (c.X == cell.X && c.Y == cell.Y) {
				isAlive = true;
			}
		});

		return isAlive;
	};
	
	this.newGeneration = function() {

		var aliveCandidates = getAliveCandidates(aliveCells);
		var reviveCandidates = getReviveCandidates(aliveCells);

		aliveCells = aliveCandidates.concat(reviveCandidates);
	};
    
	this.getDeadNeighborsOf = function(cell) {

		var neighbors = this.getNeighborsOf(cell);

		var deadNeighbors = [];

		_.each(neighbors, function(neighbor) {
			if (that.isAlive(neighbor) == false) {
				deadNeighbors.push(neighbor);
			}
		});

		return deadNeighbors;
	};

	this.getCountOfAliveNeighbors = function (cell) {
		var countOfAliveNeighbors = 0;

		var neighbors = that.getNeighborsOf(cell);

		_.each(neighbors, function(neighbor) {
			if (that.isAlive(neighbor)) {
				countOfAliveNeighbors++;
			}
		});

		return countOfAliveNeighbors;

	};

	this.getNeighborsOf = function(cell) {
		var neighbors = [];

		for (var x = -1; x < 2; x++) {
			for (var y = -1; y < 2; y++) {
				var c = new Cell(cell.X + x, cell.Y + y);
				if ((c.X == cell.X && c.Y == cell.Y) == false) {
					neighbors.push(c);
				}
			}
		}

		return neighbors;
	};

	function containsCell(cells, cell) {
		var containsCell = false;

		_.each(cells, function(c) {
			if (cell.X == c.X && cell.Y == c.Y ) {
				containsCell = true;
			}			
		});

		return containsCell;
	}

	function getAliveCandidates(cells) {
		var candidates = [];

		_.each(cells, function (cell) {
			var countOfAliveNeighbors = that.getCountOfAliveNeighbors(cell);
			if (countOfAliveNeighbors == 2 || countOfAliveNeighbors == 3) {
				candidates.push(cell);
			}
		});

		return candidates;
	}

	function getReviveCandidates(cells) {
		var candidates = [];

		_.each(cells, function(cell) {
			var deadNeighbors = that.getDeadNeighborsOf(cell);
			_.each(deadNeighbors, function(neighbor) {
				if (that.getCountOfAliveNeighbors(neighbor) == 3) {
					if (containsCell(candidates, neighbor) == false) {
						candidates.push(neighbor);
					}
				}
			});
		});

		return candidates;
	}

};


