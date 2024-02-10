This is the code for Version 0.61 of my math-fantasy RPG Mathemagica, a one-man project by Joaquin Fuenzalida Nunez made with Unity. 

Currently, there's one room implemented, with a couple of battles within. 
The crafting and battling system has had a lot of development, it's almost fully set up so building on it from here on out should be easier.

This is my first exploration of using ScriptableObjects to hold data, and it's been semi-successful.
I've lost a lot of data and time in the learning process. 
For now, the weapons, enchanting ingredients and combat initiation data is stored in SOs. 
I'd like to add more of the playerUnit and enemyUnit data as SOs as well, in a similar fashion to how the 
weapons contain all their data in corresponding SOs. Currently, the playerUnit HP resets between battles due to the prefabs not storing that data.

The enchanting system in theory works as follows:
  Different spells contain different mathematical operators (+, -, /, *, and more complex functions as well).
  The spells can be used on any target, to modify their HP value.
  Some, but not all, of these functions depend on additional numbers. (HP - exampleDamage, HP / exampleDamage)
  Thus, some spells can be enchanted to modify those foundational numbers, with ingredients found in the world.
  Ingredients have different "NP" values correspondingly, signifying what number they will provide to the spell. 
  Some ingredients with low NP values may prove more useful for some spells, whereas those with high NP values may prove more useful for others.
  Thus, the player is incentivized to consider carefully where, when and how best to enchant with their limited ingredients.

The battle system in theory works as follows:
  Different enemies in the world have different ranges of HP values, and they die after getting to 0 HP.
  However, in this game, HP values are not restricted to whole numbers, positive numbers, or even real numbers. 
  If an enemy has a negative HP value, you will need to "heal" them to get them up to 0 HP.
  If an enemy has a decimal in their HP value, you might need to use the Gravitation spell to get their HP to a whole number. 
  If an enemy has an imaginary HP value, you will need to use a spell that can affect Imaginary HP values.
  
Thus, the strategy of this game's combat is born from correctly identifying what mathematical spells and crafting options you have at your disposal to 
defeat the opponent. 


To provide a clean list of immediate next steps: 
1. I need to provide more context within the game to explain what's currently happening.
The game is high-concept, so I'd like to provide some color coding to aid in combat awareness. 
Perhaps  players could see a visual "aura" from their enemy that signifies something about their HP state and appropriate actions. 
If the opponent has an Imaginary HP, perhaps they glow pink, the same color as their moves that do Imaginary Damage, and so on and so forth.

2. I'd like to add a wider variety of spells and perhaps items that can be used in battle
I have a decent selection of themed enchanting ingredients, but I'd like to increase their utility. 
More spells and especially items would prove a great way to further explore the potential of the enchanting system and allow for further player
experimentation and exploration.

I'd make a longer list, but since so much remains to be done (sound design, animations, item sprites), I'll get back to working on the game and naturally 
build out the areas that obviously need work, and circle back to this list when it seems reasonable to add onto it again.


A playable demo of the game in its current state can be found at 
https://thatmolamola.itch.io/mathemagica
