using UnityEngine;
using System.Collections;

public class Goal : MonoBehaviour {

	public float FadeDelay = 1f;
	public float FadeDuration = 2f;
	public string NextLevel;
	public SpriteRenderer FadeSprite;
	public GameObject VictoryParticles;

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
}
