using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Talk : Verb {

	void Start() {
		verbText = WordLibrary.verb_Talk_Input;
		modifiers = WordLibrary.verb_Talk_Mod;
	}

	override public void Action(GameState gameState, List<string[]> pairInputs) {
		string noun = pairInputs[0][1];
		if (gameState.currentLocation.checkIfContainsItem(noun)) {
			Item item = gameState.currentLocation.getItemFromText(noun);
			if (item.canTalk) {
				List<Item> requiredItems = new List<Item>(item.dialog.requiredItems);
				foreach(Item i in GameState.currentState.inventory) {
					requiredItems.Remove(i);
				}
				if (requiredItems.Count == 0)
					GameState.startDialog(item.dialog);
				else
					TextOutputManager.sendOutput("You don't know if you have anything to talk about.", GameState.currentState.defaultColor);
			}
		}
		else {
			TextOutputManager.sendOutput("They don't seem interested in talking.", GameState.currentState.defaultColor);
		}
	}
}
