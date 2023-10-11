# Kagura-Kart
Car game
# Add a short description of the intended behavior, how the game mechanic should work. I need to know what were you trying to achieve.
The main goal with the game is to make a multiplayer car game in a 3D world to be able to drive around in a track where the player needs to cross 
a checkpoint that will allowe your player to complete a lap. The player needs to complete 3 laps before the opponent so that they can achieve Victory. 
The game has 3 levels witch you are able to chose from when you click the button play. 

My first inicial toughts were that i make a normal controller for the car where the controler moves the whole car, 
but since i decided to make the game in 3D i had to change the controller to a wheel controller. 

	
# Add a short set of instructions for me, as a developer, about what do I need do to in order to take a look at your project - what scene I need to load in order to play? Do I need any additional packages to install?
For starters you need to open the folder called scenes and open the Main Menu scene in order to start the game as intended. I have used ProBuilder to make my first 2 levels but i dont know if you need to have it installed. I have used the New Input system for controling my cars so you would need to download package. 

# Describe quickly the structure of your code and the thinking behind design.
Basically what the wheel controller does is it controlls the angle at whitch the wheels rotate based off the local collider position and rotation. 
To be more precise with "A, D, Left, Right" you control the wheels rotation in the Y Axis and with "W, S, Up, Down" you control the X Axis.
Unfortunately i couldnt smooth out the turn rotation of the wheels when you go left and right they simply instantly rotate to a specific angle that i have assigned. 
The car then starts to move based off the angle that the wheels are facing and also depending on its current torque, because the wheels can rotate backwards aswell.  
My brake works by applying brakeTorque to the wheels witch gradualy slows the car down when you holw either "Space" or "Left CTRL". 
For all the Menu Scripts i used 1 script that changes scense by using "buildIndex +(the number of the scene)", 
but in order to go back from another level i added 3 different bulls that can control how much the "buildIndex" needs to go down with. 
This way I have to manualy go to each scene and check in the bool "level" so for example if the main menu scens index is 0, 
level 1 is 1 and so on, if bool level 3 is assigned and you click the "Back to Menu" button the index goes down by 3.
	
Add a short list if instructions about how to play the game like, for example, the key mappings and what do they do
# You conntrol the cars by using "W, A, S, D + Space" for player1 and "Arrows Up, Down, Left, Right + right CTRL" for player 2, 
"Space and right CTRL" is used to brake. There is a checkpoint at middle of the track in each level that will let you get your score/Lap up when you cross the finish line. 
	
Add a list of sources of inspiration - you don't need to cover all of them, just the ones that helped.
# I have used these sources if inspiration
How to make Car Controller in Unity using New Input System. (https://www.youtube.com/watch?v=WCA_cXRNmtU&t=67s)

Add the Unity version for the project
Unity version 2023.1.14f1

Add your name to the project
Made by Georgi Damyanov
