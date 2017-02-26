using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class Use_DoorInBedroom : UseCase {


	override public bool checkCase(List<string[]> pairInputs) {
		return true;
	}
	override public void Action() {
		bool hasClothes = GameState.currentState.checkInventoryForItem("CLOTHES");
		bool hasBackpack = GameState.currentState.checkInventoryForItem("BACKPACK");
		if (hasClothes && hasBackpack) {
			SceneManager.LoadScene("HackathonExposition");
		}
		else if (hasClothes) {
			TextOutputManager.sendOutput("How do you expect to do a hackathon without a computer? You’re not that good at programming.", GameState.currentState.storyColor);
		}
		else if (hasBackpack) {
			TextOutputManager.sendOutput("Sorry, not wearing clothes stopped being cute when you hit puberty.", GameState.currentState.storyColor);
		}
		else {
			TextOutputManager.sendOutput("You’re not great at following instructions are you? Why don’t you try again?", GameState.currentState.storyColor);
		}
	}
}
