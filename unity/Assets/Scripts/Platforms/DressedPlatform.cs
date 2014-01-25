using UnityEngine;
using System.Collections;

namespace GGJ14 {
	public class DressedPlatform : MonoBehaviour {
		public SpriteRenderer SpriteRenderer { get; private set; }
		public MeshRenderer MeshRenderer { get; private set; }
		public Collider Collider { get; private set; }

		Color fadedColor = Color.Lerp(Color.white, Color.clear, 0.75f);

		void Awake() {
			SpriteRenderer = GetComponent<SpriteRenderer>();
			MeshRenderer = GetComponent<MeshRenderer>();
			Collider = GetComponent<Collider>();
		}

		public virtual void Disable() {
			if (SpriteRenderer) 
				SpriteRenderer.color = fadedColor;
			else if (MeshRenderer)
				MeshRenderer.material.SetColor("_TintColor", Color.Lerp(fadedColor, Color.clear, 0.5f)); // particles shader requires half as much alpha
			if (Collider) Collider.enabled = false;
		}

		public virtual void Enable() {
			if (SpriteRenderer) 
				SpriteRenderer.color = Color.white;
			else if (MeshRenderer)
				MeshRenderer.material.SetColor("_TintColor", Color.Lerp(Color.white, Color.clear, 0.5f));
			if (Collider) Collider.enabled = true;
		}
	}
}