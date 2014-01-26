using UnityEngine;
using System.Collections;

public class MonsterPatrol : MonoBehaviour {
	private float TimeTillChange;
	public float TimeToChange;
	public float MoveSpeed;
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
		characterController.Move(Velocity * Time.deltaTime);
	}
}
