using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Use_Exploration_BasementKeyOnBasementDoor : UseCase {


	public Item[] secretItems;
	public string secretBoxText;

	override public bool checkCase(List<string[]> pairInputs) {
		Debug.Log("Keycheck");
		//Check if the player has the key,
		string noun = pairInputs[1][1];
		if (noun.Equals("DOOR") && (GameState.currentState.currentLocation.checkIfContainsItem(noun))) {
			return true;
		}
		return false;
	}
	override public void Action() {
		//Take all of our secret items, put them in the basement, change the boxtext of the basement, and remove the door.
		GameState.currentState.currentLocation.items = secretItems;
		GameState.currentState.currentLocation.boxText = secretBoxText;
	}
}
