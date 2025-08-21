This game is inspired by ‘Arkanoid’, but I have twisted a few things. Player controls a “Pad” which only moves on the X-axis. It has a box collider and a “Ball trajectory” custom function, which is my logic to compare the original game, which doesn't have a random trajectory and change in linear velocity. The game loop runs in a three-wall setup, which also acts collider. There are blocks that players need to break using the ball. There few special blocks which, when collided spawn a new color ball. Now the player controls the original ball and the new balls.

In the top left corner, there is a score UI that increases whenever a block is broken. In the top right corner, there is “Lives” UI, which tells how many lives (chances) does player has if they miss the ball. Inside its logic, there is a function that gets called whenever the ball goes down the pad and out of camera view. There is a menu UI, which has “Game Over!!” text UI and a button that says “Play again”. There is the “Highest Score”, which tells what the highest score achieved is in the entire game loop. Internally, there is an array that holds all the scores achieved, and there is a function that finds and displays the biggest number in the array.

<img width="1471" height="837" alt="image" src="https://github.com/user-attachments/assets/1abef579-132c-4b24-b9ee-2607fd840aa7" />

Components and Hierarchy = <img width="888" height="554" alt="image" src="https://github.com/user-attachments/assets/d7506422-39f3-482b-b7a8-c701a4857c87" />

Gameplay = https://drive.google.com/file/d/1DiRitD_4Whw0s7WQKc4oP0g0r_fpd2qX/view?usp=sharing
