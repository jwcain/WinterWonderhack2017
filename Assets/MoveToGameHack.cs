using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MoveToGameHack : MonoBehaviour {
	// Update is called once per frame
	void Update () {
		if (GameState.currentState.checkInventoryForItem("TRIGGERITEM")) {
			SceneManager.LoadScene("Bedroom");
		}
	}
}
