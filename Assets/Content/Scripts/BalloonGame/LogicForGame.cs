// GAME DESC
// player stands on tower with a gun
// when started balloons will spawn from the fog towards them 
// player must shoot balloons to earn score
// player has 3 lives, looses life if balloon reaches the center of the tower

// BALLOON SPAWNER
// balloon pool
// hold several spawning positions for ballons around area
// have timer for when balloons are spawned
// spawn randomly between positions
// decrease spawn timer based on active game time 

// BALLOONS
// Move towards the center of the tower
// if ballon hits center, call to game manager to take a life, delete balloon
// if poped, de-activate for re calling 

// GAME MANAGER
// holds game timer to gradually increase both difficulty and score
// when balloon hit, call to life manager and get back a bool if lives = 0 or not
// Resets all systems when game over 

// LIFE MANAGER    
// holds lives, when lives over call back to game manager game over
// displays lives on UI / updates it 

// SCORE MANAGER
// updates score UI 
// adds score based on time in here
// multiplies score by balloons and game time? by how long game has passed for
// score UI in sky for easy visablity / or on each side of the tower

// GUN
// needs some sort of respawn for if player drops it off the edge 
// must shoot objects with a genourous cooldown to keep up with balloons
// must shoot straight
// use a bullet pool
