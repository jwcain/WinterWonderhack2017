using System.Collections;

public class TextLog {

	//A class that holds a log of strings
	// int 0 was the most recent input, int length-1 is the last
	private string[] strings;
	private int index;

	public TextLog(int size) {
		index = -1;
		strings = new string[size];
		strings[0] = "";
	}
	public TextLog(TextLog other) {
		index = -1;
		strings = (string[])other.getLog().Clone();
	}
		
	public void Log(string input) {
		index++;
		//Shift over all inputs
		shiftRight();
		//Add new input
		strings[0] = input;
	}

	public int getIndex() {
		return index;
	}
	public string Get(int i) {
		//If we are trying to look at what is over the length of the log, just return the last one
		if (i > index) i = index;
		if (i < 0) i = 0; // protect against bad input
		return strings[i];
	}

	//Shifts all enteries into the sgtrings right
	private void shiftRight() {
		for (int i = strings.Length - 1; i > 0; i--) {
			strings[i] = strings[i-1];
		}
		strings[0] = "";
	}


	public string[] getLog() {
		return strings;
	}

}
