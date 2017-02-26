using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Look : Verb {
	
	void Start() {
		verbText = new string[] {"LOOK"};
		modifiers = new string[] {"AT", "UNDER", "OVER", "AROUND", "BY", "THROUGH"};
	}

	override public void Action(GameState gameState, List<string[]> modifierNounInputs) {
		Debug.Log("Assumed verb is  LOOK");

		foreach (string[] sa in modifierNounInputs) {
			
			Debug.Log("M: " + sa[0] + "\n N: " + sa[1]);
		}

	}
}
