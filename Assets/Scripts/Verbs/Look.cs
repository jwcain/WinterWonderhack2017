using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Look : Verb {

	void Start() {
		verbText = WordLibrary.verb_Look_Input;
		modifiers = WordLibrary.verb_Look_Mod;
	}

	override public void Action(GameState gameState, List<string[]> pairInputs) {
		//Check to see what we are looking at.
		bool lookingAtItem = false;
		Item item = null;
		Location location = null;
		//No pairs, means look around the current room
		if (pairInputs.Count == 1) {
			//We are looking at here
			//or We are looking at an item
			//or we are looking at a location

			if (WordLibrary.compareStringToArray(pairInputs[0][1], WordLibrary.syn_Room)) {
				//Load up the room box text
				TextOutputManager.sendOutput(gameState.currentLocation.boxText);
			}
			else if (gameState.currentLocation.checkIfConnectedLocation(pairInputs[0][1])) {
				//Load up the room box text for the other room
				TextOutputManager.sendOutput("does not output other rooms boxtext yet.");
			}
			else if (gameState.currentLocation.checkIfContainsItem(pairInputs[0][1])) {
				Debug.Log("Looking at an item");
				//Load up box text for the item.
				//get the item
				//get the items box text.
				//print it
				TextOutputManager.sendOutput(gameState.currentLocation.getItemFromText(pairInputs[0][1]).boxText);
			}
			else {
				TextOutputManager.sendOutput("I dont see a " + pairInputs[0][1] + ".");
			}
		}
		else if (pairInputs.Count == 0) {
			TextOutputManager.sendOutput(gameState.currentLocation.boxText);
		}
	}
}
