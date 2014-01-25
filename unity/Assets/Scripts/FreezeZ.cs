using UnityEngine;
using System.Collections;

public class FreezeZ : MonoBehaviour {

	public float ZValueToFreeze = 0;

	void FixedUpdate() {
		Vector3 currentPosition = transform.position;
		currentPosition.z = ZValueToFreeze;
		transform.position = currentPosition;
	}
}
