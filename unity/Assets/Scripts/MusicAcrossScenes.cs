using UnityEngine;
using System.Collections;

public class MusicAcrossScenes : MonoBehaviour {
	void Start () {
		DontDestroyOnLoad(gameObject);
	}
}
