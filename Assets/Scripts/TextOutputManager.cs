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

	public static void sendOutput(string text, string color) {
		//colorToString(color);
		string display = output.textMesh.text;
		int limit = 2000;
		if (display.Length > limit) {
			//Get the last 1100 chars of the text
			string newDisplay = display.Substring(800);
			display = newDisplay;
		}
		display += ("^C" + color + "")+(text.ToUpper() + "\n") ;
		output.textMesh.text = display;
	}

	private static string colorToString(Color color) {
		//^cRBGA
		return "^c" + decimalToHex(color.r) + decimalToHex(color.b)+ decimalToHex(color.g) + "f";
	}

	private static string decimalToHex(float t) {
		string[] output = {"0","1","2","3","4","5","6","7","8","9","a","b","c","d","e","f"};
		int o = (int)Mathf.Round(Mathf.Lerp(0,15,t));
		return output[o];
	}
}
