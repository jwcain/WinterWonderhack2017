using UnityEngine;
using System.Collections;

public class WordLibrary : MonoBehaviour {


	public static bool compareStringToArray(string s, string[] arr) {
		//loop through all the strings in arr to see if s matches one of them.
		foreach (string a in arr) {
			if (s.ToUpper().Equals(a.ToUpper())) {
				return true;
			}
		}
		return false;
	}


	//Verbs
	public static string[] verb_Look_Input = new string[] {"LOOK", "EXAMINE", "VIEW"};
	public static string[] verb_Look_Mod = new string[] {"AT", "UNDER", "OVER", "AROUND", "BY", "THROUGH"};

	public static string[] verb_Get_Input = new string[] {"GET", "TAKE", "GRAB", "PICKUP"};
	public static string[] verb_Get_Mod = new string[] {};

	public static string[] verb_Go_Input = new string[] {"GO", "MOVE", "TRAVEL"};
	public static string[] verb_Go_Mod = new string[] {"TO"};

	public static string[] verb_Use_Input = new string[] {"USE"};
	public static string[] verb_Use_Mod = new string[] {"ON", "WTIH"};

	public static string[] verb_ZZ_Input = new string[] {};
	public static string[] verb_ZZ_Mod = new string[] {};

	public static string[] verb_Exit_Input = new string[] {"CLOSEGAME"};
	public static string[] verb_Exit_Mod = new string[] {};

	//Synonym Library
	public static string[] syn_Room = new string[] {"ROOM", "AREA", "HERE"};
	public static string[] syn_Inventory = new string[] {"INVENTORY", "STORAGE", "ITEMS", "POCKETS", "STUFF"};


}
