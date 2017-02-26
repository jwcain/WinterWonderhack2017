using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class GameState : MonoBehaviour {

	//Do we make all verb exections and events overide the current static state?
	public static GameState currentState;
	public Location currentLocation;
	public IList<Item> inventory;
	public static Dialog currentDialog;

	public string defaultColor;
	public string locationColor;
	public string itemColor;
	public string errorColor;
	public string storyColor;

	public Dialog endgameDialog;

	void Awake() {
		if (currentState == null) {
			currentState = this;
		}
		else {
			Debug.LogError("You have many game states, don't do that!");
			Debug.Break();
		}
		inventory = new List<Item>();
	}

	public static void addToInventory(Item i) {
		currentState.inventory.Add(i);
	}

	public static Item removefromInvetory(Item i) {
		currentState.inventory.Remove(i);
		return i;
	}
	public static string getItemsAsText() {
		string ret = "";
		foreach (Item i in currentState.inventory) {
			ret += i.identifiers[0] + " ";
		}
		return ret;
	}

	public Item checkInventoryForItem(string s) {
		//This method will trust that the item exists more or less
		foreach (Item i in inventory) {
			if (WordLibrary.compareStringToArray(s,i.identifiers)) {
				return i;
			}
		}
		return null;
	}


	public void moveInventoryItemToCurrentRoom(string s) {
		Item i = checkInventoryForItem(s);
		removefromInvetory(i);
		currentLocation.addItem(i);
	}
	public static void startDialog(Dialog d) {
		GameState.currentDialog = d;
		TextOutputManager.sendOutput(d.dialog[0].statement, GameState.currentState.storyColor);
	}
	public static void startEndgameScene() {
		SceneManager.LoadScene("EndScene");
	}

	void Update() {
		//This should be the only update method in the whooooole gammmmmmm3... I have no way to prove that
	}

}
