using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Use : Verb {

	void Start() {
		verbText = WordLibrary.verb_Use_Input;
		modifiers = WordLibrary.verb_Use_Mod;
	}

	override public void Action(GameState gameState, List<string[]> pairInputs) {
		//Check if the first noun exists
		if (pairInputs.Count > 0) {
			string noun = pairInputs[0][1];
			//Find the noun somwhere
			//The noun can be in the room or you backpack.
			Item item = null;
			if (gameState.currentLocation.checkIfContainsItem(noun)) {
				item = gameState.currentLocation.getItemFromText(noun);
			}
			else if (gameState.checkInventoryForItem(noun) != null) {
				item = gameState.checkInventoryForItem(noun);
			}
			if (item != null) {
				//Look in the item for a use case that works!
				foreach (UseCase c in item.cases) {
					if (c.checkCase(pairInputs)) {
						c.Action();
						return;
					}
				}
				TextOutputManager.sendOutput("I cannot use " + noun + " like that.", GameState.currentState.defaultColor);
			}
			else {
				TextOutputManager.sendOutput("I cannot use that.", GameState.currentState.defaultColor);
				return;
			}
		}
		else {
			TextOutputManager.sendOutput("Use what, how?", GameState.currentState.defaultColor);
		}
	}
}
