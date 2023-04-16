# Explanation
In this project I created the classic PacMan game.
I took images from google for the map, pellet (coin) ans ghost.
## Scripts
### Player
1. MovementController: responsible for the movement of both the pacman and the ghost while using the nodes for knowing the avalible directions.
2. PlayerController: responsible for sending the direction to the script above, fliping the pacman animation by the direction and check if the game was ender succesfully.

### Ghost (RED, BLUE, ORANGE AND PINK)
1. MovementController: responsible for the movement of both the pacman and the ghost while using the nodes for knowing the avalible directions.
2. EnemyController: responsible for player hunting.

### Node
1. NodeController: responsible for checking which nodes are avalible to direct from each specific node.
2. GhostUnlock: some nodes unlock specific ghost, this script responsible for that.
3. GhostShield: one node shields the player for 15 seconds, this script responsible for doing so.
