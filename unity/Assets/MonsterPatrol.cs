using UnityEngine;
using System.Collections;

public class MonsterPatrol : MonoBehaviour {
	private float TimeTillChange;
	public float TimeToChange;
	public float MoveSpeed = 5f;
	CharacterController characterController;
	public Vector3 Velocity;

	void Awake() {
		characterController = GetComponent<CharacterController>();
	}
	void Start()
	{
		Velocity = new Vector3 (MoveSpeed,0,0);
	}
	// Update is called once per frame
	void Update () {
		if (Time.time > TimeTillChange) 
		{
			Velocity = -Velocity;
			TimeTillChange = TimeToChange + Time.time;
		}

		if (Velocity.x < 0)
			transform.localScale = new Vector3(1, 1, 1); // horizontally flip animation
		else
			transform.localScale = new Vector3(-1, 1, 1);
		characterController.Move(Velocity * Time.deltaTime);
	}
}
