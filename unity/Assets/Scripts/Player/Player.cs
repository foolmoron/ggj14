using UnityEngine;
using System.Collections;

namespace GGJ14 {
	[RequireComponent(typeof(DressChanger))]
	public class Player : MonoBehaviour {

		public LayerMask RaycastLayers;
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
		private float distToSide;


		public Vector3 Velocity;

		CharacterController characterController;
		SpriteRenderer spriteRenderer;
		DressChanger dressChanger;
		Dresses currentDress;

		Animator animator;
		bool wasGrounded = false;

		void Awake() {
			characterController = GetComponent<CharacterController>();
			spriteRenderer = GetComponentInChildren<SpriteRenderer>();
			dressChanger = GetComponent<DressChanger>();
			currentDress = dressChanger.CurrentDress;

			animator = GetComponentInChildren<Animator>();
		}

		void Start() {
			UpdateDress();
			distToGround = collider.bounds.extents.y;
			distToSide = collider.bounds.extents.x;
			
		}

		void FixedUpdate() {
			//snap to z = 0
			Vector3 currentPosition = transform.position;
			currentPosition.z = 0;
			transform.position = currentPosition;
		}
		
		void Update() {
			bool isGrounded = IsGrounded();

			// X movement
			if (Input.GetButton("Right") || Input.GetAxis("Horizontal360") > 0.001) {
				if ((Velocity.x >= 0)&&((isGrounded&&Velocity.x<MaxMoveSpeed)||Velocity.x < MoveSpeed)) {
					Velocity.x = Velocity.x + GroundAcceleration*Time.deltaTime;
				} else if (Velocity.x < 0)
				{
					Velocity.x = Velocity.x + StoppingAccelleration*Time.deltaTime;
				}
				transform.localScale = new Vector3(1, 1, 1);
				animator.SetTrigger("Moving");
				animator.ResetTrigger("NotMoving");
			} else if (Input.GetButton("Left") || Input.GetAxis("Horizontal360") < 0) {
				if ((Velocity.x <= 0)&&((isGrounded&&Velocity.x>-MaxMoveSpeed)||Velocity.x > -MoveSpeed)) {
					Velocity.x = Velocity.x - GroundAcceleration*Time.deltaTime;
				} else if (Velocity.x > 0)
				{
					Velocity.x = Velocity.x - StoppingAccelleration*Time.deltaTime;
				}
				transform.localScale = new Vector3(-1, 1, 1); // horizontally flip animation
				animator.SetTrigger("Moving");
				animator.ResetTrigger("NotMoving");
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
				if (Velocity.x == 0.0f) {
					animator.SetTrigger("NotMoving");
					animator.ResetTrigger("Moving");
				}
			}
			if (IsBlockedOnLeft() && Velocity.x < 0)
			{
				Velocity.x = Velocity.x/2;
			}
			if (IsBlockedOnRight() && Velocity.x > 0)
			{
				Velocity.x = Velocity.x/2;
			}

			//Y movement		
			if (!isGrounded) 
			{
				Velocity.y = Velocity.y - FallSpeed * Time.deltaTime;
			} 
			else 
			{
				if (!Input.GetButtonDown("Jump") && !Input.GetButtonDown("Jump360"))
				{
				Velocity.y = 0.0f;
				}
			}
			if ((Input.GetButtonDown("Jump")&&IsGrounded()) || (Input.GetButtonDown("Jump360")&&IsGrounded())) {
				Velocity.y = JumpSpeed;
				animator.SetTrigger("Jumped");
				animator.ResetTrigger("Landed");
				animator.ResetTrigger("NotMoving");
				animator.ResetTrigger("Moving");
			}

			// Dress Changes
			if (Input.GetButtonDown("PreviousDress") || Input.GetButtonDown("PreviousDress360")) {
				currentDress = dressChanger.PreviousDress();
				dressChanger.ChangeDress(currentDress);
				UpdateDress();
			} else if (Input.GetButtonDown("NextDress") || Input.GetButtonDown("NextDress360")) {
				currentDress = dressChanger.NextDress();
				dressChanger.ChangeDress(currentDress);
				UpdateDress();
			}

			//Landing
			if (!wasGrounded && isGrounded) {
				animator.SetTrigger("Landed");
			}

			wasGrounded = isGrounded;
			characterController.Move(Velocity * Time.deltaTime);
		}


		bool IsGrounded(){
			return ((Physics.Raycast(transform.position, -Vector3.up, (float)(distToGround + 0.1), RaycastLayers)) ||
			        (Physics.Raycast(transform.position + new Vector3(distToSide,0,0), -Vector3.up, (float)(distToGround + 0.1), RaycastLayers))||
			        (Physics.Raycast(transform.position - new Vector3(distToSide,0,0), -Vector3.up, (float)(distToGround + 0.1), RaycastLayers)));
		}
		
		bool IsBlockedOnLeft(){
			return ((Physics.Raycast(transform.position, Vector3.left, (float)(distToSide + 0.1), RaycastLayers)) ||
			        (Physics.Raycast(transform.position + new Vector3(0,distToGround,0), Vector3.left, (float)(distToSide + 0.1), RaycastLayers))||
			        (Physics.Raycast(transform.position - new Vector3(0,distToGround,0), Vector3.left, (float)(distToSide + 0.1), RaycastLayers)));
		}
		
		bool IsBlockedOnRight(){
			return ((Physics.Raycast(transform.position, -Vector3.left, (float)(distToSide + 0.1), RaycastLayers)) ||
			        (Physics.Raycast(transform.position + new Vector3(0,distToGround,0), -Vector3.left, (float)(distToSide + 0.1), RaycastLayers))||
			        (Physics.Raycast(transform.position - new Vector3(0,distToGround,0), -Vector3.left, (float)(distToSide + 0.1), RaycastLayers)));
		}
		void UpdateDress() {
			switch (currentDress) {
			case Dresses.Plain:
				//spriteRenderer.sprite = PlainSprite;
				break;
			case Dresses.Dots:
				//spriteRenderer.sprite = DotsSprite;
				break;
			case Dresses.Stripes:
				//spriteRenderer.sprite = StripesSprite;
				break;
			}
		}
	}
}