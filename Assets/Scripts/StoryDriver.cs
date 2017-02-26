using UnityEngine;
using System.Collections;

public class StoryDriver : MonoBehaviour {
	// Use this for initialization
	public Dialog startingDiaglog = null;
	public Item[] startingItems = new Item[0];
	void Start () {
		if (GameState.currentState == null) Debug.Log("current state null.");
		if (startingItems == null) Debug.Log("starting items null.");
		GameState.startDialog(startingDiaglog);

		foreach (Item i in startingItems) {
			GameState.addToInventory(i);
		}
	}
}
