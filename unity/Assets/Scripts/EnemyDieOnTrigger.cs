using UnityEngine;
using System.Collections;

public class EnemyDieOnTrigger : MonoBehaviour {
	public GameObject OnDiePrefab;

	void OnTriggerEnter(Collider other) {
		Debug.Log("tr");
		Destroy(transform.parent.gameObject);
		Instantiate(OnDiePrefab, transform.position, Quaternion.identity);
	}
}
