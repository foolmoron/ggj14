using UnityEngine;
using System.Collections;

namespace GGJ14 {
	public class DressChanger : MonoBehaviour {

		public Dresses CurrentDress = Dresses.Plain;

		public void ChangeDress(Dresses newDress) {
			if (newDress != CurrentDress) {
				CurrentDress = newDress;
			}
		}
		
		public Dresses NextDress() {
			switch (CurrentDress) {
			case Dresses.Plain:
				return Dresses.Dots;
			case Dresses.Dots:
				return Dresses.Stripes;
			case Dresses.Stripes:
				return Dresses.Plain;
			}
			return Dresses.Plain;
		}
		
		public Dresses PreviousDress() {
			switch (CurrentDress) {
			case Dresses.Plain:
				return Dresses.Stripes;
			case Dresses.Dots:
				return Dresses.Plain;
			case Dresses.Stripes:
				return Dresses.Dots;
			}
			return Dresses.Plain;
		}
	}
}