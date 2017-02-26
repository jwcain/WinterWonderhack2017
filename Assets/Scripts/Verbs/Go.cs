using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Go : Verb {

	void Start() {
		verbText = WordLibrary.verb_Go_Input;
		modifiers = WordLibrary.verb_Go_Mod;
	}

	override public void Action(GameState gameState, List<string[]> pairInputs) {
		if (pairInputs.Count == 1) {
			string noun = pairInputs[0][1];

			//Check to see if it is a valid location
			//Go to it if possible
			//Otherwise, yell at the player

			if (gameState.currentLocation.checkIfConnectedLocation(noun)) {
				Location newLocation = gameState.currentLocation.getLocationFromText(noun);
				gameState.currentLocation = newLocation;
				TextOutputManager.sendOutput("You are now in the " + newLocation.identifiers[0] + ".", GameState.currentState.defaultColor);
			}
			else {
				TextOutputManager.sendOutput("I cannot go to " + noun + ".", GameState.currentState.defaultColor);
			}
		}
		else if (pairInputs.Count == 0) {
			TextOutputManager.sendOutput("Where?", GameState.currentState.defaultColor);
		}
		else  {
			TextOutputManager.sendOutput("I don't know how to go there.", GameState.currentState.defaultColor);
		}
	}
}
