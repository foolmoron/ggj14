using UnityEngine;
using System.Collections;

public class EnemyDieOnTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other) {
		Debug.Log("tr");
		Destroy(transform.parent.gameObject);
		//poof
	}
}
