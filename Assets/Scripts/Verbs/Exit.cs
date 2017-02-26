using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Exit : Verb {

	void Start() {
		verbText = WordLibrary.verb_Exit_Input;
		modifiers = WordLibrary.verb_Exit_Mod;
	}

	override public void Action(GameState gameState, List<string[]> pairInputs) {
		Application.Quit();
	}
}
