using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {
	public float FadeDuration = 2f;
	float fadeTime = 0;
	SpriteRenderer spriteRenderer;
	Material fadeMaterial;

	void Start () {
		spriteRenderer = GetComponentInChildren<SpriteRenderer>();
		spriteRenderer.enabled = true;
		fadeMaterial = spriteRenderer.material;
		fadeMaterial.color = Color.white;
	}

	void Update () {
		if (fadeTime < FadeDuration) {
			fadeTime += Time.deltaTime;
			float interp = fadeTime / FadeDuration;
			fadeMaterial.color = Color.Lerp(Color.white, Color.clear, interp);
		} else {
			spriteRenderer.enabled = false;
			this.enabled = false;
		}
	}
}
