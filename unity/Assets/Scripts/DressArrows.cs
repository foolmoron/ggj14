using UnityEngine;
using System.Collections;
using GGJ14;

public class DressArrows : MonoBehaviour {
	
	public SpriteRenderer LeftArrow;
	public SpriteRenderer RightArrow;
	public Sprite PlainSprite;
	public Sprite DotsSprite;
	public Sprite StripesSprite;

	Dresses currentDress;

	void Awake() {
		SetCurrentDress(Dresses.Plain);
		Vector3 prevScale = LeftArrow.transform.localScale;
		prevScale.x = -Mathf.Abs(prevScale.x);
		LeftArrow.transform.localScale = prevScale;
	}
	
	public void SetCurrentDress(Dresses dress) {
		currentDress = dress;
		
		switch (currentDress) {
		case Dresses.Plain:
			LeftArrow.sprite = StripesSprite;
			RightArrow.sprite = DotsSprite;
			break;
		case Dresses.Dots:
			LeftArrow.sprite = PlainSprite;
			RightArrow.sprite = StripesSprite;
			break;
		case Dresses.Stripes:
			LeftArrow.sprite = DotsSprite;
			RightArrow.sprite = PlainSprite;
			break;
		}
	}
}
