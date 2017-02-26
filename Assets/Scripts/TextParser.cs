using UnityEngine;
using System.Collections;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class TextParser : MonoBehaviour {

	public Verb[] verbs;
	private static string[] removable = new string[] {"A", "AN", "THE", "I"};
	private static TextParser currentParser;


	void Start() {
		if (TextParser.currentParser == null) {
			TextParser.currentParser = this;
		}
		else {
			Debug.LogError("You have two active parsers, dont do that");
			Debug.Break();
		}
	}

	public static void Parse(string input) {

		//Split the input on whitespace
		string pattern = @"\s";
		string[] splitInput = Regex.Split(input, pattern);
		List<string> fInput = new List<string>(splitInput);
		stripInput(fInput); // Strip known usless words, we let these be typed in for the players benefit

		//If we have no input left, do invalid input handling and return
		if (fInput.Count < 0) {
			//invalid input handling goes here
			sendError("Nothing left after split");
			return;
		}

		// Expression: (verb) ((modifier)*(noun)+)*
		//This is the expression we are trying to break down into.
		//Firt we will assume the first string is always the verb after stripping input.
		//Then we loop through and try to make modifier/noun pairs
		//If there is a modifier, there has to be a noun that follows (look AT TREE)
		//However, we may have a noun that does not have a modifier (grab ROCK)


		//Assume the first string is the verb
		string verbInput = removeFirst(fInput);

		Verb verb = null;
		//Compare verb to verb list
		foreach (Verb v in TextParser.currentParser.verbs) {
			foreach(string s in v.getVerbText()) {	
				if (s.Equals(verbInput)) {
					//Yay! we found matching verb
					verb = v;
				}
			}
		}

		//If we didnt find a verb, cause and error and exit
		if (verb == null) {
			//Handle invalid input here
			sendError("I'm not sure I know how to do that.");
			return;
		}

		List<string[]> modifierNounPairs = new List<string[]>();
		while (fInput.Count > 0) {
			string[] pair = new string[2]; // We use a array of two strings to hold the modifier noun pair
			//Get the first token, there has to be one or else we could never loop here
			string c = removeFirst(fInput);

			bool foundMod = false;
			//Check if that token is a modifier,
			foreach (string s in verb.getModText()) {
				if (s.Equals(c)) {
					//This is a modifier
					pair[0] = c;
					foundMod = true;
				}
			}
			Debug.Log("foundMod: " + foundMod);
			//based on weather or not we found a modifier, we do different things
			if (foundMod == false) {
				//since it was not a mod, we assume it was a noun add it to the pair and move on
				pair[1] = c;
				modifierNounPairs.Add(pair);
				continue;
			}
			else {
				//we found a mod, that means there has to be a noun that goes with it
				//check if the list has anything left
				if (fInput.Count < 1) {
					//This input has failed
					sendError(c + " WHAT?");
					return;
				}
				//Grab what we think is a noun
				string noun = removeFirst(fInput);

				//Put it in the pair, and add the pair to the list
				pair[1] = noun;
				modifierNounPairs.Add(pair);
			}
		}
		//Call the action now that we have doen all the preprocessing
		verb.Action(GameState.currentState, modifierNounPairs);
	}


	private static void sendError(string errorText) {
		//Debug.Log(errorText);
		TextOutputManager.sendOutput(errorText, GameState.currentState.errorColor);
	}

	private static string removeFirst(List<string> input) {
		string s = input[0];
		input.RemoveAt(0);
		return s;
	}

	//removes all articles and conjuntions
	private static void stripInput(List<string> toStrip) {
		for (int i = toStrip.Count - 1; i >= 0; i--) {
			foreach (string s in removable) {
				if (toStrip[i].Equals(s))
					toStrip.Remove(toStrip[i]);
			}
		}
	}
}
