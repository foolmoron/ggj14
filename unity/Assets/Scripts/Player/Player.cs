using UnityEngine;
using System.Collections;

namespace GGJ14 {
	[RequireComponent(typeof(DressChanger))]
	public class Player : MonoBehaviour {

		public float MoveSpeed = 5f;
		public float MoveThreshold = 0.5f;
		public float JumpSpeed = 5f;
		public float FallSpeed = 10f;
		public Sprite PlainSprite;
		public Sprite DotsSprite;
		public Sprite StripesSprite;
		private bool OnGround;
		private float distToGround;

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
			distToGround = collider.bounds.extents.y;
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

		
			if (!IsGrounded ()) 
			{
				Velocity.y = Velocity.y - FallSpeed * Time.deltaTime;
			} 
			else 
			{
				if (!Input.GetButton("Jump"))
				{
				Velocity.y = 0.0f;
				}
			}
			if (Input.GetButton("Jump")&&IsGrounded()) {
				Velocity.y = JumpSpeed;
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
		bool IsGrounded(){
			return Physics.Raycast(transform.position, -Vector3.up, (float)(distToGround + 0.1));
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