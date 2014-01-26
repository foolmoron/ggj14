using UnityEngine;
using System.Collections;

public class RadiusScript : MonoBehaviour {
	public bool playerLeft, playerRight;
	// Use this for initialization
	void Start () {
		playerLeft = playerRight = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.tag==("Player")) 
		{
			Debug.Log("Yo");
			if (collider.transform.position.x > transform.position.x) {
				playerRight= true;
			} else {
				playerLeft= true;
			}
		}
	}
	void OnTriggerExit(Collider collision) {
		if (collision.gameObject.tag==("Player"))
		{
			playerLeft = playerRight = false;
		}
	}
}
