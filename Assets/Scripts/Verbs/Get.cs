using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Get : Verb {

	void Start() {
		verbText = WordLibrary.verb_Get_Input;
		modifiers = WordLibrary.verb_Get_Mod;
	}

	override public void Action(GameState gameState, List<string[]> pairInputs) {
		//check to see if the item exists
		//check to see if it can be taken
		//put it in inventory
		//remove from the room
		if (pairInputs.Count == 1) {
			string noun = pairInputs[0][1];
			if (gameState.currentLocation.checkIfContainsItem(noun)) {
				Item item = gameState.currentLocation.getItemFromText(noun);
				if (item.canPickup == true) {
					gameState.currentLocation.removeItem(item);
					GameState.addToInventory(item);
					TextOutputManager.sendOutput("You took the " + noun + ".");
				}
				else {
					TextOutputManager.sendOutput("You cannot take " + noun + ".");
				}
			}
			else if (gameState.checkInventoryForItem(noun) != null) {
				TextOutputManager.sendOutput("You already have " + noun + ".");
			}
			else {
				TextOutputManager.sendOutput("Take what?");
			}
		}
		else {
			TextOutputManager.sendOutput("Take what?");
		}
	}
}
