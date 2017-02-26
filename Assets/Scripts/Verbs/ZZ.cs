using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class ZZ : Verb {

	void Start() {
		verbText = WordLibrary.verb_ZZ_Input;
		modifiers = WordLibrary.verb_ZZ_Mod;
	}

	override public void Action(GameState gameState, List<string[]> pairInputs) {

	}
}
