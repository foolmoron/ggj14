using UnityEngine;
using System.Collections;

namespace GGJ14 {
	[RequireComponent(typeof(SpriteRenderer))]
	public class DressedPlatform : MonoBehaviour {
		public SpriteRenderer SpriteRenderer { get; private set; }
		public Collider Collider { get; private set; }

		void Start() {
			SpriteRenderer = GetComponent<SpriteRenderer>();
			Collider = GetComponent<Collider>();
		}

		public virtual void Disable() {
			SpriteRenderer.enabled = false;
			if (Collider) Collider.enabled = false;
		}

		public virtual void Enable() {
			SpriteRenderer.enabled = true;
			if (Collider) Collider.enabled = true;
		}
	}
}