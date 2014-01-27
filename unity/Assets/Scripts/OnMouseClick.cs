using UnityEngine;
using System.Collections;

public class OnMouseClick : MonoBehaviour {

	public string LevelToLoad;

	void OnMouseOver() {
		renderer.enabled = true;
		if (Input.GetMouseButtonDown(0)) {
			Application.LoadLevel(LevelToLoad);
		}
	}

	void OnMouseExit() {
		renderer.enabled = false;
	}
}
