using UnityEngine;
using System.Collections;

namespace GGJ14 {
	public class DressManager : MonoBehaviour {

		public DressChanger DressChangerToWatch;

		Dresses currentDress;
		PlainPlatform[] allPlain;
		DotsPlatform[] allDots;
		StripesPlatform[] allStripes;
		DressArrows dressArrows;

		void Awake() {
			currentDress = DressChangerToWatch.CurrentDress;
			allPlain = Object.FindObjectsOfType<PlainPlatform>();
			allDots = Object.FindObjectsOfType<DotsPlatform>();
			allStripes = Object.FindObjectsOfType<StripesPlatform>();
			dressArrows = Object.FindObjectOfType<DressArrows>();
		}

		void Start() {
			HandleDressChanged();
		}
		
		void Update() {
			if (currentDress != DressChangerToWatch.CurrentDress) {
				currentDress = DressChangerToWatch.CurrentDress;
				HandleDressChanged();
			}
		}

		public void HandleDressChanged() {
			for (int i = 0; i < allPlain.Length; i++) { allPlain[i].Disable(); }
			for (int i = 0; i < allDots.Length; i++) { allDots[i].Disable(); }
			for (int i = 0; i < allStripes.Length; i++) { allStripes[i].Disable(); }
			
			DressedPlatform[] platformsToEnable = null;
			switch (currentDress) {
			case Dresses.Plain:
				platformsToEnable = allPlain;
				break;
			case Dresses.Dots:
				platformsToEnable = allDots;
				break;
			case Dresses.Stripes:
				platformsToEnable = allStripes;
				break;
			}
			for (int i = 0; i < platformsToEnable.Length; i++) { 
				platformsToEnable[i].Enable(); 
			}

			if (dressArrows)
				dressArrows.SetCurrentDress(currentDress);
		}
	}
}