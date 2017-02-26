using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Location : MonoBehaviour {

	public Location[] connectedLocations;
	public string[] connectedLocationsText;
	public string boxText;
	public Item[] items;
	private int itemCount;
	public string[] identifiers;

	public void addItem(Item newItem) {

		//Resize the item array if we are trying to add another item!
		//Grow the array by one
		Item[] newItems = new Item[items.Length + 1];
		for (int i = 0; i < items.Length; i++) newItems[i] = items[i];
		items = newItems;

		items[itemCount] = newItem;
		itemCount++;
	}
	public void removeItem(Item item) {
		for (int i = 0; i <= itemCount; i++) {
			if (items[i] == item) {
				getAndRemoveItem(i);
				break;
			}
		}
		Debug.Log("No item");
	}

	public Item getAndRemoveItem(int i) {
		Item toRet = items[i];
		shiftLeftFromIndex(i);

		//Shrink the array by one
		Item[] newItems = new Item[items.Length - 1];
		for (int j = 0; j < newItems.Length; j++) newItems[j] = items[j];
		items = newItems;

		itemCount--;
		return toRet;
	}

	public int getItemCount() {
		return itemCount;
	}

	private void shiftLeftFromIndex(int index) {
		Debug.Log("Shiften");
		for (int i = index; i < items.Length -1; i++) {
			items[i] = items[i+1];
		}
		items[items.Length-1] = null;
	}


	public bool checkIfConnectedLocation(string s) {
		foreach (Location l in connectedLocations) {
			if (WordLibrary.compareStringToArray(s,l.identifiers)) {
				return true;
			}
		}
		return false;
	}
	public bool checkIfContainsItem(string s) {
		foreach (Item i in items) {
			if (WordLibrary.compareStringToArray(s,i.identifiers)) {
				return true;
			}
		}
		return false;
	}
	public Item getItemFromText(string s) {
		//This method will trust that the item exists more or less
		foreach (Item i in items) {
			if (WordLibrary.compareStringToArray(s,i.identifiers)) {
				return i;
			}
		}
		return null;
	}

	public Location getLocationFromText(string s) {
		foreach (Location l in connectedLocations) {
			if (WordLibrary.compareStringToArray(s,l.identifiers)) {
				return l;
			}
		}
		return null;
	}

	public string getRelativeBoxTextForLocation(Location l) {
		for (int i = 0; i < connectedLocations.Length; i++) {
			if (l == connectedLocations[i]) {
				return connectedLocationsText[i];
			}
		}
		return "";
	}

	public string getContentsAsString() {
		string ret = "Nearby Locations: \n";
		foreach(Location l in connectedLocations) {
			ret += l.identifiers[0] + "\n";
		}

		ret += "Nearby Things: \n";
		foreach(Item i in items) {
			ret += i.identifiers[0] + "\n";
		}

		return ret;
	}
}
