# 3rd Dev Update
## Implementing enemy AI

### What was expected to be done?
The objective for this milestone was to implement a functional enemy AI, that will be able to attack the player, adding a sense to the game rather than walking around the map, as well as a challenge.
Ideally, the AI should be able to:
Shoot at the player, using a bullet spread variable to balance the enemies by missing some shots, making them more “human”
Move, making it harder to the player to hit the bullets
Find cover in near objects

### What was actually done?
The AI was implemented. Due to the lack of time and resources, only one kind of enemy, with one kind of gun was implemented. The enemy is designed so it misses some bullets, moves randomly sometimes and stops shooting from time to time to “reload” or when the player gets out of a defined range. All this behaviour is handled in the EnemyBehaviour.cs script. It also uses the same health script the player uses to determine the HP of the enemy, just with a different formatting (a single number showing the HPs left in contrast to the current/maximum” display on the player. The enemy uses a prefab that is instantiated along the map. 

Implementing this AI arose multiple challenges. First of all, I could not find a fitting model in mixamo, so I had to import it from somewhere else and then use mixamo animations. It took some time to figure out how to make the animations work as intended, because when I first imported them, I did not turn off the “In place” option in mixamo, which led to weird movement of the enemy. Also, implementing the Health system on the enemy led to multiple bugs. Enemies’ HP would not update, or their guns would be shot by the player since they were using the same script at the beginning. The final AI could not be as complex as originally expected (being able to hide or even chase the player), but it has enough implementation to not be just a turret. 

On this last push of the project, some other minor changes were done such as adding details to the map or a little camera animation in the opening scene 
