# CS 4610 - Computer Graphics 1
# Project Proposal

## Team Members: Nick Henry, Sarah McLaughlin, Jay Toebben, Tiffany Young
## Contact Person: Jay Toebben (ejtn78@mail.missouri.edu)
## Project Plan: Meeting every 2 - 3 days

# PacMan Unleashed
A maze-PacMan game with different levels that have different points of view, mazes, enemies and power-ups.

## Stage 1: 2D game:
- Template of a maze with your PacMan character moving through it with a fixed camera. A collision into enemies or walls will result in the loss of a life or the game.
- 3D map with a superimposed 2D view. Similar to classic PacMan.
## Stage 2: 3D game:
- 1st person PacMan maze that follows the player’s POV
## Stage 3: 3rd or 1st person PacMan maze:
- Weapons (possible power-ups/rapid fire)
- Multiple lives
- Fruit - health, speed-up
- Giant fruit - Giant PacMan chomper
- Additional obstacles
	- New enemies


## Methods/Goals:

- Unity
- Map Functionality 
	- Transport/transposing onto other mazes
	- Possible cube → 6 planes
	- Walls alter every 30-60 seconds
- Design
	- 3D models
	- Websites/Google images
	- FBX and Unity objects
	- Photoshop
- Ghosts 
	- Pick a direction to go and changes direction with collision into wall → moves in direction closest to PacMan
	- When they die, removed and spin off map
- Controls
	- 2D: up, down, left, and right buttons
	- 3D: mouse controls
- Portals
	- Teleport to new random maze runner/walls or another preset maze designs
- Sound Effects
	- PacMan womp womp sounds
	- PacMan music
- Supported Operating Systems
	- OSX, Linux, Windows, WebGL


## Project Management Plan:

- Regular meetings every 2 to 3 days
- Role assignments
	- Nick - Ghosts (AI) - possible Dark PacMan
	- Sarah - Map (Auto generated maps?), PacMan/3D PacMan
	- Jay - Map, Camera Views
	- Tiffany - Ghost, Enemies, Attack/Rapid Fire/Power-ups
