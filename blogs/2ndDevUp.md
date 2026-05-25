# 2nd Dev Update
## Milestone: Implementing different FPS systems such as health, shooting and menus

### What was expected to be done?
The plan for this milestone was to implement the core mechanics and systems of the game, this being:
Health system that would be applied to enemies and the player. The player should be able to be hit by enemies, as well as losing HP when in contact with different props such as barbed wire or fire, and able to regain health by consuming collectibles placed across the map
Shooting system. Both the enemies and the player must have a weapon that they can use to hit each other. This gun should be able to shoot, reload, keep a count of the remaining bullets, and deny shooting when there are no bullets.
HUD and menu. A basic HUD showing the player’s health and remaining bullets should be displayed. Also, an initial menu scene, together with death and victory messages should be implemented.

### What was actually done?
The health system was implemented as expected, but it carried a lot of problems and bugs. I could not really make the sliders work as I wanted (visually) which led to a not very pleasing health UI, that later was changed to numbers representing the HP. The first part of the implementation of the health system was when the player collided with the barbed wire, which worked as expected, later on, a bullet script was made so the player would receive damage, together with a bandage item that can be picked up to regain health.

The shooting system was implemented mostly following a Youtube tutorial (https://www.youtube.com/watch?v=woXLV8cIe7s), and later changed a bit to fit the game. While it worked properly at the beginning, at some point there were some issues with the trail, since I wanted to both shoot a projectile and drop the case on the floor at the same time, but the asset I was using was the whole bullet. The idea of dropping the case was original and implemented following the same concept as with the bullet themselves. The bullets are thrown via a shooting point in the muzzle of the gun, so the same was done on the side of the gun to generate the cases that would fall to the ground.
Magazines were placed across the map, following the same logic and script as the bandages mentioned before

For the HUD, I just did a simple display of the bullet count as well as for the health of the player.
The initial scene was done by sculpting a new mountainous scene, and adding some assets, so it would look like the player is someone somewhat distant to the chaos happening in the game. To represent that, the romanian flag was added (animated using a youtube tutorial as well), together with a radio playing Кончится лето (a song talking about people wanting change by the russian band Kino), and a piece of paper with a real article from the time.

### What is next?
The next and last milestone of the project is to “Implement the enemy AI”, as well as finishing up the last details of the game. I expect this milestone to be a hard one since AI seems to me like the most complex part of the project.
