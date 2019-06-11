using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour {

	public AudioSource collectSound; 

	// Checks if the collision2D is triggered
	void OnTriggerEnter2D(Collider2D other) {

		if (other.tag == "Player") {
			collectSound.Play (); // Sound effect
			ScoreScript.scoreValue += 100; // Adds 100pts
			Destroy (gameObject); // Destroys to token
		}
	}
}
