using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class UseCase : MonoBehaviour {

	//Determines a particular way to use an item.

	abstract public bool checkCase(List<string[]> pairInputs);
	abstract public void Action();
}
