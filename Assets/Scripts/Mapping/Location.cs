using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Location : MonoBehaviour {

	public Location[] connetedLocations;
	public string[] connectedLocationsText;
	public string boxText;
	public Item[] items;
	private int itemCount;
	public string[] identifiers;

	public void addItem(Item newItem) {

		//Resize the item array if we are trying to add another item!
		if (itemCount >= items.Length) {
			Item[] newItems = new Item[items.Length + 5];
			for (int i = 0; i < items.Length; i++) newItems[i] = items[i];
			items = newItems;
		}

		items[itemCount] = newItem;
		itemCount++;
	}

	public Item getAndRemoveItem(int i) {
		Item toRet = items[i];
		shiftLeftFromIndex(i);
		itemCount --;
		return toRet;
	}

	public int getItemCount() {
		return itemCount;
	}

	private void shiftLeftFromIndex(int index) {
		for (int i = index; i < items.Length -1; i++) {
			items[i] = items[i+1];
		}
		items[items.Length-1] = null;
	}


	public bool checkIfConnectedLocation(string s) {
		foreach (Location l in connetedLocations) {
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
}
