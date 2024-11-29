## Tic Tac Toe
We are developing the module used by a GUI to keep the state of Tic-tac-toe. The users playing the game will click on a GUI which in turn will invoke our module

### Game Setup
- One board – 3 x 3 cells
- Two players – O & X
- Players take turns

### Game Rules
- Player One starts
- A mark can only be placed on an empty position
- Game ends if...
    - board full
    - if the same symbol per appears in a row, column or diagonal then that player wins

### Additional constraints/request
- Expose a way (function/method/property) to know the status of the game, which can be:
    - Next player turn: "X|O turn" or...
    - One of the players wins: "X|O wins" or...
    - The board is full: "Draw"

### TODO
- What's the first test?