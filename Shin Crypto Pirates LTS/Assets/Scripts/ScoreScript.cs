using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	public GameObject scoreText;
	public GameObject bestScoreText;
	public GameObject currentScoreText;

	public static int scoreValue = 0;
	public static int bestScore = 0;
	public static int endScore = scoreValue;


	void Update() {
		endScore = scoreValue;

		// Checks if the player is dead
		if (DavidMove.playerIsDead == true) {

			if (scoreValue > bestScore) {
				bestScore = scoreValue;
			}
		}

		// Updates the score UI
		scoreText.GetComponent<Text>().text = "Score: " + scoreValue;
		currentScoreText.GetComponent<Text> ().text = "Score: " + endScore;
		bestScoreText.GetComponent<Text> ().text = "Best Score: " + bestScore;
	}
}
