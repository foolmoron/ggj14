using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {
	public SpriteRenderer FadeSprite;
	public float FadeDuration = 2f;
	float fadeTime = 0;
	Material fadeMaterial;

	void Start () {
		FadeSprite.enabled = true;
		fadeMaterial = FadeSprite.material;
		fadeMaterial.color = Color.white;
	}

	void Update () {
		if (fadeTime < FadeDuration) {
			fadeTime += Time.deltaTime;
			float interp = fadeTime / FadeDuration;
			fadeMaterial.color = Color.Lerp(Color.white, Color.clear, interp);
		} else {
			FadeSprite.enabled = false;
			this.enabled = false;
		}
	}
}
