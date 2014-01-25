using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public Texture bgTexture;

	void OnGUI () {
		// Make a background box
		GUI.Box(new Rect(125,125,400,350), "Super Princess Adventure");
		
		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect(150,175,350,100), "Start Game")) {
			Application.LoadLevel(1);
		}
		
		// Make the second button.
		if(GUI.Button(new Rect(150,300,350,100), "Options")) {
			Application.LoadLevel(2);
		}
	}
}

