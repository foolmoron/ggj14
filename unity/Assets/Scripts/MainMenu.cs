using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public string FirstGameScene;
	public string ControlsScene;

	public float StartLeft;
	public float StartTop;
	public float StartWidth;
	public float StartHeight;
	public float ControlsLeft;
	public float ControlsTop;
	public float ControlsWidth;
	public float ControlsHeight;

	Color highlight = new Color(255, 105, 180, 128);

	void OnGUI () {
		GUI.color = Color.clear;

		if (GUI.Button(new Rect(StartLeft,StartTop,StartWidth,StartHeight), "")) {
			Application.LoadLevel(FirstGameScene);
		}

		if(GUI.Button(new Rect(ControlsLeft,ControlsTop,ControlsWidth,ControlsHeight), "")) {
			Application.LoadLevel(ControlsScene);
		}
	}
}

