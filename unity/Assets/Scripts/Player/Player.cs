using UnityEngine;
using System.Collections;

namespace GGJ14 {
	[RequireComponent(typeof(DressChanger))]
	public class Player : MonoBehaviour {

		public float MoveSpeed = 5f;
		public float MaxMoveSpeed = 20f;
		public float MoveThreshold = 0.5f;
		public float JumpSpeed = 15f;
		public float FallSpeed = 40f;
		public float GroundAcceleration = 20f;
		public float StoppingAccelleration = 40f;
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

// X movement
			if (Input.GetButton("Right")) {
				if ((Velocity.x >= 0)&&((IsGrounded()&&Velocity.x<MaxMoveSpeed)||Velocity.x < MoveSpeed)) {
					Velocity.x = Velocity.x + GroundAcceleration*Time.deltaTime;
				} else if (Velocity.x < 0)
				{
					Velocity.x = Velocity.x + StoppingAccelleration*Time.deltaTime;
				}
			} else if (Input.GetButton("Left")) {
				if ((Velocity.x <= 0)&&((IsGrounded()&&Velocity.x>-MaxMoveSpeed)||Velocity.x > -MoveSpeed)) {
					Velocity.x = Velocity.x - GroundAcceleration*Time.deltaTime;
				} else if (Velocity.x > 0)
				{
					Velocity.x = Velocity.x - StoppingAccelleration*Time.deltaTime;
				}
			} else {
				if(Velocity.x > 0)
				{
					if (Velocity.x-GroundAcceleration*Time.deltaTime > 0)
					{
						Velocity.x = Velocity.x-GroundAcceleration*Time.deltaTime;
					}
					else
					{
						Velocity.x = 0.0f;
					}
				}
				else if (Velocity.x < 0)
				{
					if (Velocity.x+GroundAcceleration*Time.deltaTime < 0)
					{
						Velocity.x = Velocity.x+GroundAcceleration*Time.deltaTime;
					}
					else
					{
						Velocity.x = 0.0f;
					}
				}

			}

//Y movement		
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
// Dress Changes
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