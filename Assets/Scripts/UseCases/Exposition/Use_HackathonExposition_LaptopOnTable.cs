using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Use_HackathonExposition_LaptopOnTable : UseCase {


	override public bool checkCase(List<string[]> pairInputs) {
		string noun = pairInputs[1][1];
		Debug.Log(noun);
		if (noun.Equals("TABLE") & GameState.currentState.currentLocation.checkIfContainsItem(noun)) {
			return true;
		}
		return false;
	}
	override public void Action() {
		GameState.startDialog(GameState.currentState.currentLocation.getItemFromText("TABLE").dialog);
	}
}

