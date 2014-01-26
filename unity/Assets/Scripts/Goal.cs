using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	public float FadeDelay = 1f;
	public float FadeDuration = 2f;
	public string NextLevel;
	public SpriteRenderer FadeSprite;
	public GameObject VictoryParticles;

	public bool ShowCutscene = false;
	public Sprite CutsceneSprite;
	public float CutsceneFadeInDuration = 1f;
	public float CutsceneDuration = 3f;
	public float CutsceneFadeOutDuration = 1f;
	SpriteRenderer cutscene;
	bool cutsceneFadingIn = false;
	bool cutsceneFadingOut = false;

	bool fading = false;
	float fadeTime = 0;
	bool canLoad = true;

	void Start () {
		FadeSprite.material.color = Color.clear;
	}

	void Update () {
		if (fading) {
			fadeTime += Time.deltaTime;
			float interp = fadeTime / FadeDuration;
			if (interp >= 1) {
				fading = false;
				if (ShowCutscene)
					StartCutscene();
				else
					Application.LoadLevel(NextLevel);
			}

			FadeSprite.material.color = Color.Lerp(Color.clear, Color.white, interp);
		}
		if (cutsceneFadingIn) {
			fadeTime += Time.deltaTime;
			float interp = fadeTime / CutsceneFadeInDuration;
			if (interp >= 1) {
				cutsceneFadingIn = false;
				StartCoroutine(FadeOutCutsceneWithDelay());
			}
			
			FadeSprite.material.color = Color.Lerp(Color.white, Color.clear, interp);
		}
		if (cutsceneFadingOut) {
			fadeTime += Time.deltaTime;
			float interp = fadeTime / CutsceneFadeOutDuration;
			if (interp >= 1) {
				cutsceneFadingOut = false;
				Application.LoadLevel(NextLevel);
			}
			
			FadeSprite.material.color = Color.Lerp(Color.clear, Color.white, interp);
		}
	}

	void OnTriggerEnter(Collider other) {
		if (!canLoad)
			return;

		canLoad = false;
		StartCoroutine(FadeWithDelay());
	}

	IEnumerator FadeWithDelay() {
		Instantiate(VictoryParticles, transform.position, Quaternion.identity);
		yield return new WaitForSeconds(FadeDelay);
		FadeSprite.enabled = true;
		fading = true;
	}

	IEnumerator FadeOutCutsceneWithDelay() {
		yield return new WaitForSeconds(CutsceneDuration);
		FadeSprite.enabled = true;
		cutsceneFadingOut = true;
		fadeTime = 0;
	}

	void StartCutscene() {
		var cutsceneSprite = new GameObject("CutsceneSprite");
		var cutscene = cutsceneSprite.AddComponent<SpriteRenderer>();
		cutscene.sprite = CutsceneSprite;
		cutscene.sortingOrder = FadeSprite.sortingOrder;
		cutscene.transform.parent = FadeSprite.transform.parent;
		cutscene.transform.localPosition = new Vector3(FadeSprite.transform.localPosition.x, FadeSprite.transform.localPosition.y, FadeSprite.transform.localPosition.z + 1);
		cutscene.transform.localScale = new Vector3(6.4f, 6.4f, 1);

		cutsceneFadingIn = true;
		fadeTime = 0;
	}
}
