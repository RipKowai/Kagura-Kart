# Kagura-Kart
Car game
# Add a short description of the intended behavior, how the game mechanic should work. I need to know what were you trying to achieve.
- The main goal with the game is to make a 3D multiplayer car game. The goal is to be able to drive around in a track where the player needs to cross 
a checkpoint that will allow your player to complete a lap. The player needs to complete 3 laps before the opponent so that you can achieve Victory. 
The game has 3 levels witch you are able to chose from when you click the button play. 

- My first initial thoughts were that i make a normal controller for the car where the controller moves the whole car, 
but since i decided to make the game in 3D i had to change the controller to a wheel controller. 

	
# A short set of instructions for me, as a developer, about what do I need do to in order to take a look at your project - what scene I need to load in order to play? Do I need any additional packages to install?
For starters you need to open the folder called scenes and open the Main Menu scene in order to start the game as intended. I have used ProBuilder to make my first 2 levels but i don't know if you need to have it installed. I have used the New Input system for controlling my cars so you would need to download package. 

# Describe quickly the structure of your code and the thinking behind design.
- Basically what the wheel controller does is it controls the angle at which the wheels rotate based off the local collider position and rotation. 
To be more precise with "A, D, Left, Right" you control the wheels rotation in the Y Axis and with "W, S, Up, Down" you control the X Axis.
Unfortunately i couldn't smooth out the turn rotation of the wheels when you go left and right they simply instantly rotate to a specific angle that i have assigned. 
The car then starts to move based off the angle that the wheels are facing and also depending on its current torque, because the wheels can rotate backwards as well.  
My brake works by applying brakeTorque to the wheels witch gradually slows the car down when you how either "Space" or "Left CTRL". 

- For all the Menu Scripts i used 1 script that changes scenes by using "buildIndex +(the number of the scene)", 
but in order to go back from another level I added 3 different bulls that can control how much the "buildIndex" needs to go down with. 
This way I have to manually go to each scene and check in the bool "level" so for example if the main menu scenes index is 0, 
level 1 is 1 and so on, if bool level 3 is assigned and you click the "Back to Menu" button the index goes down by 3.

- As for my checkpoint and lap counter i did this; the finish line has a bool called "touchFinishLine" and the players have a bool called "Lap" in order for the player to score both bools need to be equal to true. For the first lap every bool is off, once the player crosses the checkpoint his "lap" bool is true and the "touchFinishLine '' becomes true, this way the player can cross the finish line and score/lap. Every time the player crosses the finish line their score goes up and players bool "Lap '' becomes false. This way the players cannot interact with the finish line unless they cross the checkpoint. 

	
# Add a short list if instructions about how to play the game like, for example, the key mappings and what do they do
- You control the cars by using "W, A, S, D + Space" for player1 and "Arrows Up, Down, Left, Right + right CTRL" for player 2, 
"Space and right CTRL" is used to brake. There is a checkpoint at the middle of the track in each level that will let you get your score/Lap up when you cross the finish line. 
	
Add a list of sources of inspiration.
#Sources of inspiration
How to make a Car Controller in Unity using the New Input System. (https://www.youtube.com/watch?v=WCA_cXRNmtU&t=67s)

# Add the Unity version for the project
Unity version 2023.1.14f1

#Made by Georgi Damyanov
