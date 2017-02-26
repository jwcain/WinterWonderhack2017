using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ExpoisitionHack : MonoBehaviour {
	private bool once = false;
	private bool twice = false;
	void Update() {
		if (once && Input.GetKeyDown(KeyCode.Return))
			twice = true;
		
		if (GameState.currentState.currentLocation.identifiers[0].Equals("AUDITORIUM") && !once) {
		TextOutputManager.sendOutput("A student, pale as a ghost is crouching over a body. " +
			"They have their hands clasped over the mouth. Your worst fears come to mind as you rush towards the stage. " +
			"As you get closer, you stumble to your knees. The last thing you remember before passing out is Kevin’s ashen " +
			"face, in a pool of his own blood. ", GameState.currentState.storyColor);
			once = true;
		}


		if (Input.GetKeyDown(KeyCode.Return) && once && twice) {
			Debug.Log("yeah it just went");
			SceneManager.LoadScene("OpenExploration");
		}
	}
}
