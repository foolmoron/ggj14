using UnityEngine;
using System.Collections;

public class CutsceneOnly : MonoBehaviour {

	public SpriteRenderer FadeSprite;
	public float CutsceneFadeInDuration;
	public float CutsceneDuration;

	Goal goal;
	bool cutsceneFadingIn = true;
	bool waiting = true;
	float fadeTime = 0;

	void Start() {
		goal = GetComponentInChildren<Goal>();
	}

	void Update() {
		if (cutsceneFadingIn) {
			fadeTime += Time.deltaTime;
			float interp = fadeTime / CutsceneFadeInDuration;
			if (interp >= 1) {
				cutsceneFadingIn = false;
				fadeTime = 0;
				waiting = true;
			}
			
			FadeSprite.material.color = Color.Lerp(Color.white, Color.clear, interp);
		}
		if (waiting) {
			fadeTime += Time.deltaTime;
			float interp = fadeTime / CutsceneDuration;
			if (interp >= 1) {
				goal.OnTriggerEnter(null);
				waiting = false;
			}
		}
	}
}
