using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour {
	public bool canPickup = false;
	public bool canTalk = false;
	public string[] identifiers;
	public string boxText;
	public UseCase[] cases;
	public Dialog dialog;

}
