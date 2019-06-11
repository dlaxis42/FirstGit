using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontDestroyAudio : MonoBehaviour {

	void Awake() {
		DontDestroyOnLoad (transform.gameObject);
	}
}
