using UnityEngine;
using System.Collections;

namespace GGJ14 {
	[RequireComponent(typeof(DressChanger))]
	public class Player : MonoBehaviour {

		public float MoveSpeed = 5f;
		public float MoveThreshold = 0.5f;
		public float JumpSpeed = 5f;
		public Sprite PlainSprite;
		public Sprite DotsSprite;
		public Sprite StripesSprite;

		public Vector3 Velocity;

		CharacterController characterController;
		SpriteRenderer spriteRenderer;
		DressChanger dressChanger;
		Dresses currentDress;

		void Awake() {
			characterController = GetComponent<CharacterController>();
			spriteRenderer = GetComponentInChildren<SpriteRenderer>();
			dressChanger = GetComponent<DressChanger>();
			currentDress = dressChanger.CurrentDress;
		}

		void Start() {
			UpdateDress();
		}

		void FixedUpdate() {
			//snap to z = 0
			Vector3 currentPosition = transform.position;
			currentPosition.z = 0;
			transform.position = currentPosition;
		}
		
		void Update() {
			if (Input.GetButton("Right")) {
				Velocity.x = MoveSpeed;
			} else if (Input.GetButton("Left")) {
				Velocity.x = -MoveSpeed;
			} else {
				Velocity.x = 0;
			}

			if (Input.GetButton("Jump")) {
				Velocity.y = JumpSpeed;
			} else {
				Velocity.y = -JumpSpeed;
			}

			if (Input.GetButtonDown("PreviousDress")) {
				currentDress = dressChanger.PreviousDress();
				dressChanger.ChangeDress(currentDress);
				UpdateDress();
			} else if (Input.GetButtonDown("NextDress")) {
				currentDress = dressChanger.NextDress();
				dressChanger.ChangeDress(currentDress);
				UpdateDress();
			}

			characterController.Move(Velocity * Time.deltaTime);
		}

		void UpdateDress() {
			switch (currentDress) {
			case Dresses.Plain:
				spriteRenderer.sprite = PlainSprite;
				break;
			case Dresses.Dots:
				spriteRenderer.sprite = DotsSprite;
				break;
			case Dresses.Stripes:
				spriteRenderer.sprite = StripesSprite;
				break;
			}
		}
	}
}