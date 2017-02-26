using UnityEngine;
using System.Collections;


public class GameState : MonoBehaviour {

	//Do we make all verb exections and events overide the current static state?
	public static GameState currentState;
	public Location currentLocation;

	void Start() {
		if (currentState == null) {
			currentState = this;
		}
		else {
			Debug.LogError("You have many game states.");
			Debug.Break();
		}
	}

	void Update() {
		//This should be the only update method in the whooooole gammmmmmm3... I have no way to prove that
	}

}
