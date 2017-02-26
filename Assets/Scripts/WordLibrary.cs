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
	public static string[] verb_Look_Input = new string[] {"LOOK"};
	public static string[] verb_Look_Mod = new string[] {"AT", "UNDER", "OVER", "AROUND", "BY", "THROUGH"};

	public static string[] verb_Put_Input = new string[] {"PUT"};
	public static string[] verb_Put_Mod = new string[] {"ON", "IN", "OUT", "UNDER", "OVER", "BY"};


	//Synonym Library
	public static string[] syn_Room = new string[] {"ROOM", "AREA", "HERE"};


}
