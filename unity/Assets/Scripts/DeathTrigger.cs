using UnityEngine;
using System.Collections;

public class DeathTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		StartLevelReset();
	}

	void OnCollisionEnter(Collision collision) {
		StartLevelReset();
	}

	void StartLevelReset() {
		Debug.Log("Loading");
		Application.LoadLevel(Application.loadedLevel);
	}
}
