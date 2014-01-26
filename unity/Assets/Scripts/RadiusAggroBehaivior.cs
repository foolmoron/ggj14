using UnityEngine;
using System.Collections;

public class RadiusAggroBehaivior : MonoBehaviour {

	public Vector3 Velocity;
	public float MoveSpeed=20f;
	CharacterController characterController;
	// Use this for initialization
	void Awake() {
		characterController = GetComponent<CharacterController>();
	}
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		if (transform.FindChild ("Radius").GetComponent<RadiusScript>().playerLeft) 
		{
			Debug.Log ("REal");
			Velocity.x = -MoveSpeed;
		} 
		if (transform.FindChild ("Radius").GetComponent<RadiusScript>().playerRight) 
		{
			Velocity.x = MoveSpeed;
		} 
		characterController.Move(Velocity * Time.deltaTime);
	}
}
