using UnityEngine;
using System.Collections;

public class StoryDriver : MonoBehaviour {
	// Use this for initialization
	public string text;
	void Start () {
		TextOutputManager.sendOutput(text, GameState.currentState.storyColor);
	}
}
