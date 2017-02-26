using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TextOutputManager : MonoBehaviour {


	public tk2dTextMesh textMesh;
	public static TextOutputManager output;


	void Start() { 
		if (output == null) {
			output = this;
		}
		else {
			Debug.Log("You have many text outputs, dont do that");
			Debug.Break();
		}
	}

	public static void sendOutput(string text) {
		output.textMesh.text += text.ToUpper();
	}
}
