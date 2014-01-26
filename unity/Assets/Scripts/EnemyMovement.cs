using UnityEngine;
using System.Collections;
namespace GGJ14 {
	public class EnemyMovement : MonoBehaviour {
		
		public float MoveSpeed = 5f;
		public float FallSpeed = 40f;
		private float distToGround;
		private float distToSide;
		
		
		public Vector3 Velocity;
		
		CharacterController characterController;
//		SpriteRenderer spriteRenderer;			
	//	Animator animator;
		bool wasGrounded = false;
		
		void Awake() {
			characterController = GetComponent<CharacterController>();
//			spriteRenderer = GetComponentInChildren<SpriteRenderer>();				
//			animator = GetComponentInChildren<Animator>();
		}
		
		void Start() {
			distToGround = collider.bounds.extents.y;
			distToSide = collider.bounds.extents.x;
			
		}
		
		void Update() {
			bool isGrounded = IsGrounded();
/*			
			// X movement
			if (Input.GetButton("Right") || Input.GetAxis("Horizontal360") > 0.001) {
					
				Velocity.x = MoveSpeed;
				transform.localScale = new Vector3(1, 1, 1);
//				animator.SetTrigger("Moving");
//				animator.ResetTrigger("NotMoving");
			} else if (Input.GetButton("Left") || Input.GetAxis("Horizontal360") < 0) {
				Velocity.x = -MoveSpeed;
				transform.localScale = new Vector3(-1, 1, 1); // horizontally flip animation
//				animator.SetTrigger("Moving");
//				animator.ResetTrigger("NotMoving");
			} else {
				Velocity=0.0f;
//			}*/
			if (Velocity.x == 0.0f) {
//					animator.SetTrigger("NotMoving");
//					animator.ResetTrigger("Moving");
			}
/*			if (IsBlockedOnLeft() && Velocity.x < 0)
			{
				Velocity.x = Velocity.x/2;
			}
			if (IsBlockedOnRight() && Velocity.x > 0)
			{
				Velocity.x = Velocity.x/2;
			}*/
			
			//Y movement		
			if (!isGrounded) 
			{
				Velocity.y = Velocity.y - FallSpeed * Time.deltaTime;
			} 
/*			else 
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
			//Landing
			if (!wasGrounded && isGrounded) {
				animator.SetTrigger("Landed");
			}*/
			
//			wasGrounded = isGrounded;
			characterController.Move(Velocity * Time.deltaTime);
		}
		
		
		bool IsGrounded(){
			return ((Physics.Raycast(transform.position, -Vector3.up, (float)(distToGround + 0.1))) ||
			        (Physics.Raycast(transform.position + new Vector3(distToSide,0,0), -Vector3.up, (float)(distToGround + 0.1)))||
			        (Physics.Raycast(transform.position - new Vector3(distToSide,0,0), -Vector3.up, (float)(distToGround + 0.1))));
		}
		
		bool IsBlockedOnLeft(){
			return ((Physics.Raycast(transform.position, Vector3.left, (float)(distToSide + 0.1))) ||
			        (Physics.Raycast(transform.position + new Vector3(0,distToGround,0), Vector3.left, (float)(distToSide + 0.1)))||
			        (Physics.Raycast(transform.position - new Vector3(0,distToGround,0), Vector3.left, (float)(distToSide + 0.1))));
		}
		
		bool IsBlockedOnRight(){
			return ((Physics.Raycast(transform.position, -Vector3.left, (float)(distToSide + 0.1))) ||
			        (Physics.Raycast(transform.position + new Vector3(0,distToGround,0), -Vector3.left, (float)(distToSide + 0.1)))||
			        (Physics.Raycast(transform.position - new Vector3(0,distToGround,0), -Vector3.left, (float)(distToSide + 0.1))));
		}
	}
}
