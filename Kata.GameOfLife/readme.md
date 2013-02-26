#Overview

This project contains my solution for the kata "GameOfLife"

# References

- [Article in Wikipedia EN](http://en.wikipedia.org/wiki/Conway's_game_of_life)
- [Artikel in Wikipedia DE](http://de.wikipedia.org/wiki/Game_of_Life)
- [Lösung in C#](http://martinsaspects.blogspot.de/2011/01/conways-game-of-life-code-kata.html)

# Rules
- Lebende Zellen mit weniger als zwei lebenden Nachbarn sterben in der Folgegeneration an Einsamkeit.
- Eine lebende Zelle mit zwei oder drei lebenden Nachbarn bleibt in der Folgegeneration lebend.
- Eine tote Zelle mit genau drei lebenden Nachbarn wird in der Folgegeneration neu geboren.
- Lebende Zellen mit mehr als drei lebenden Nachbarn sterben in der Folgegeneration an Überbevölkerung.

- Any live cell with fewer than two live neighbours dies, as if caused by under-population.
- Any live cell with two or three live neighbours lives on to the next generation.
- Any live cell with more than three live neighbours dies, as if by overcrowding.
- Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.