using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Verb : MonoBehaviour {

	public string[] verbText; // touch, look, grab, push
	public string[] modifiers;// in, on, around, over, etc


	public string[] getVerbText() {
		return verbText;
	}
	public string[] getModText() {
		return modifiers;
	}

	public abstract void Action(GameState gameState, List<string[]> modifierNounInputs);
}
