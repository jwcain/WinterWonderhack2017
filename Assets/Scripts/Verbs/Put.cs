using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Put : Verb {


	void Start() {
		verbText = new string[] {"PUT"};
		modifiers = new string[] {"ON", "IN", "OUT", "UNDER", "OVER", "BY"};
	}

	override public void Action(GameState gameState, List<string[]> modifierNounInputs) {
		Debug.Log("Assumed verb is PUT");

		foreach (string[] sa in modifierNounInputs) {

			Debug.Log("M: " + sa[0] + "\n N: " + sa[1]);
		}

	}
}
