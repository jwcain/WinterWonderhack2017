﻿using UnityEngine;
using System.Collections;

public class TextEntryManager : MonoBehaviour {

	public tk2dTextMesh textMesh;
	private TextLog textLog;
	private int logProgress = -1;
	enum InputType {UpArrow, DownArrow, Enter, Escape, Backspace, Tab, Text}
	private InputType lastInput;

	// Use this for initialization
	void Start() {
		lastInput = InputType.Text;
		logProgress = -1;
		textLog = new TextLog(32);
		if (textMesh == null) {
			Debug.LogError("Text mesh not assigned to input.");
			Debug.Break();
		}
	}

	// Update is called once per frame
	void Update() {
		string str = Input.inputString;

		if (GameState.currentDialog != null) {
			bool pressedEnter = false;
			if (str.Length == 1 && ((int)str[0]) == 13) {
				if (Input.GetKeyDown(KeyCode.Return)) {
					pressedEnter = true;
				}
			}


			if (pressedEnter) {
				//Finish the response typing
				//Do the next thing
				//if there is nothing else, null our dialog and return
				textMesh.text += GameState.currentDialog.dialog[GameState.currentDialog.Progress].response;
				TextOutputManager.sendOutput(textMesh.text, GameState.currentState.itemColor);
				ClearInput();
				if (GameState.currentDialog.Progress >= GameState.currentDialog.dialog.Length - 1) {
					// we are done
					foreach(Item i in GameState.currentDialog.endOfDialogItems) {
						GameState.addToInventory(i);
					}
					GameState.currentDialog = null;
				}
				else {
					GameState.currentDialog.Progress++;
					TextOutputManager.sendOutput(GameState.currentDialog.dialog[GameState.currentDialog.Progress].statement, GameState.currentState.storyColor);
				}
			}
			else {
				int count = str.Length;
				string leftover;
				string toType = "";
			
				if (count > GameState.currentDialog.dialog[GameState.currentDialog.Progress].response.Length -1) {
					toType = GameState.currentDialog.dialog[GameState.currentDialog.Progress].response;
					leftover = "";
				}
				else {
					for (int i = 0; i < count; i++) { toType += GameState.currentDialog.dialog[GameState.currentDialog.Progress].response[i]; }
					leftover = GameState.currentDialog.dialog[GameState.currentDialog.Progress].response.Substring(count);
				}
				//Debug.Log(leftover);
				GameState.currentDialog.dialog[GameState.currentDialog.Progress].response = leftover;
				textMesh.text += toType.ToUpper();
			}
			return;

			//End of dialog stuff
		}
		else {

			//Had issues with the input hanging up because backspace and enter are accepted by Input.inputString
			//So we screen specially for these two inputs
			// Backspace == 8, Enter = 13
			//We then check for the click so holding it down does not break things
			if (Input.GetKeyDown(KeyCode.Home)) {
				Application.Quit();
			}
			else if (Input.GetKeyDown(KeyCode.UpArrow)) {
				//if we were not already using hte arrow keys, reset the counter
				if ((lastInput == InputType.DownArrow || lastInput == InputType.UpArrow) == false) 
					logProgress = -1;
				UpArrow();
				lastInput = InputType.UpArrow;
			}
			else if (Input.GetKeyDown(KeyCode.DownArrow)) {
				// if we where not already using the arrow keys, reset the counter
				if ((lastInput == InputType.DownArrow || lastInput == InputType.UpArrow) == false) 
					logProgress = -1;
				DownArrow();
				lastInput = InputType.DownArrow;
			}
			else {
				if (str.Length == 1 && ((int)str[0]) == 8) {
					if (Input.GetKeyDown(KeyCode.Backspace)) {
						Backspace();
						lastInput = InputType.Backspace;
					}
				}
				else if (Input.GetKeyDown(KeyCode.Delete)) {
					Backspace();
					lastInput = InputType.Backspace;
				}
				else if (str.Length == 1 && ((int)str[0]) == 13) {
					if (Input.GetKeyDown(KeyCode.Return)) {
						Enter();
						lastInput = InputType.Enter;
					}
				}
				else if (Input.GetKeyDown(KeyCode.Escape)) {
					Escape();
					lastInput = InputType.Escape;
				}
				else if (Input.GetKeyDown(KeyCode.Tab)) {
					Tab();
					lastInput = InputType.Tab;
				}
				else if (str.Length > 0) {
					//Debug.Log((int)str[0]);
					textMesh.text = textMesh.text + str.ToUpper();
					lastInput = InputType.Text;
				}
			}
		}
	}

	private void Tab() {
		// Attempt to autocomplete text based on situation
	}
	private void Escape() {
		//log current input field
		//clear input field
		LogInput();
		ClearInput();
	}
	private void UpArrow() { 
		//save current text if it is not a previous input
		//0 means this is our first time pressing up arrow
		logProgress++;
		//If this is our first arrow key input, log what is in the field before we ovverride it
		if ((lastInput == InputType.DownArrow || lastInput == InputType.UpArrow) == false) {
			LogInput();
		}
		if (logProgress > textLog.getIndex())
			logProgress = textLog.getIndex();
		string str = textLog.Get(logProgress);
		textMesh.text = str;
	}
	private void DownArrow() { 
		//save current text if it is not a previous input
		//0 means this is our first time pressing up arrow
		logProgress--;
		if (logProgress < 0) {
			logProgress = -1;
			//make sure we have been using arrow keys before we delet things
			if (lastInput == InputType.DownArrow || lastInput == InputType.UpArrow) {
				ClearInput();
			}
		}
		else {
			string str = textLog.Get(logProgress);
			textMesh.text = str;
		}
	}

	private void Enter() {
		TextOutputManager.sendOutput("-> " + textMesh.text, GameState.currentState.defaultColor);
		TextParser.Parse(textMesh.text);
		LogInput();
		ClearInput();
	}

	private void Backspace() {
		if (textMesh.text.Length == 1)
			textMesh.text = "";
		else if (textMesh.text.Length > 1)
			textMesh.text = textMesh.text.Substring(0,textMesh.text.Length-1);
	}
	private void ClearInput() {
		textMesh.text = "";
	}
	private void LogInput() {
		//Put the last input into the log field
		string str = textMesh.text;
		ClearInput();
		if (str.Length > 0)
			textLog.Log(str);
	}
}
