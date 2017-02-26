using UnityEngine;
using System.Collections;

public class Dialog : MonoBehaviour {
	public Item[] requiredItems = new Item[0];
	public int Progress = 0;
	public DialogStep[] dialog = null;
	public Item[] endOfDialogItems = new Item[0];




	[System.Serializable]
	public class DialogStep {
		public string statement;
		public string response;
	}
}
