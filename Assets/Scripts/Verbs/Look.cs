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
		//No pairs, means look around the current room
		if (pairInputs.Count == 1) {
			//We are looking at here
			//or We are looking at an item
			//or we are looking at a location
			string noun = pairInputs[0][1];

			if (WordLibrary.compareStringToArray(noun, WordLibrary.syn_Room)) {
				//Load up the room box text
				TextOutputManager.sendOutput(gameState.currentLocation.boxText,GameState.currentState.storyColor);
				gameState.currentLocation.outputContentsAsString();
			}
			else if (WordLibrary.compareStringToArray(noun, WordLibrary.syn_Inventory)) {
				//Load up the room box text
				TextOutputManager.sendOutput(GameState.getItemsAsText(), GameState.currentState.itemColor);
			}
			else if (gameState.currentLocation.checkIfConnectedLocation(noun)) {
				//Load up the room box text for the other room
				TextOutputManager.sendOutput(
					gameState.currentLocation.getRelativeBoxTextForLocation(
						gameState.currentLocation.getLocationFromText(noun)
					),
					GameState.currentState.storyColor
				);
			}
			else if (gameState.currentLocation.checkIfContainsItem(noun)) {
				//Load up box text for the item.
				//get the item
				//get the items box text.
				//print it
				TextOutputManager.sendOutput(gameState.currentLocation.getItemFromText(noun).boxText, GameState.currentState.storyColor);
			}
			else if (gameState.checkInventoryForItem(noun) != null) {
				TextOutputManager.sendOutput(gameState.checkInventoryForItem(noun).boxText, GameState.currentState.storyColor);
			}
			else {
				TextOutputManager.sendOutput("I dont see a " + noun + ".", GameState.currentState.defaultColor);
			}
		}
		else if (pairInputs.Count == 0) {
			TextOutputManager.sendOutput(gameState.currentLocation.boxText, GameState.currentState.storyColor);
			gameState.currentLocation.outputContentsAsString();
		}
	}



}
