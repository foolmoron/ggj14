using UnityEngine;
using System.Collections;
using GGJ14;

public class DressedMonster : MonoBehaviour {

	public string AnimationPrefix = "Walk";
	Animator animator;
	Dresses currentDress = Dresses.Plain;

	void Start () {
		animator = GetComponentInChildren<Animator>();
	}
	
	public void SetCurrentDress(Dresses dress) {
		if (currentDress != dress) {
			currentDress = dress;

			string animSuffix = "";
			switch (currentDress) {
			case Dresses.Plain:
				animSuffix = "Plain";
				break;
			case Dresses.Dots:
				animSuffix = "Dots";
				break;
			case Dresses.Stripes:
				animSuffix = "Stripes";
				break;
			}

			if (animator) {
				var state = animator.GetCurrentAnimatorStateInfo(0);
				var prevTime = state.normalizedTime;
				animator.Play(AnimationPrefix + animSuffix, 0, prevTime);
			}
		}
	}
}
