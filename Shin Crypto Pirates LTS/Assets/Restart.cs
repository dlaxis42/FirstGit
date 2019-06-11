using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Restart : MonoBehaviour {

	public static bool gameIsPaused = false;
	public GameObject pauseMenuUI;
	public GameObject currentScoreText;

	public static int endScore;
	
	// Update is called once per frame
	void Update () {

		if (DavidMove.playerIsDead == true) {
			
			if (gameIsPaused) {
//				Resume ();
			} else {
				Pause ();
			}

		}

	}

	public void Restarting() {
		pauseMenuUI.SetActive (false);
		currentScoreText.SetActive (false);
		Time.timeScale = 1.0f;
		gameIsPaused = false;
		DavidMove.playerIsDead = false;
		ScoreScript.scoreValue = 0; // reset score to 0
		MazeBehavior.restartGame ();
	}

	void Pause() {
		pauseMenuUI.SetActive (true);
		currentScoreText.SetActive (true);
		Time.timeScale = 0.0f;
		gameIsPaused = true;
	}

	public void loadMenu() {
		// Makes sure music does not stack when returning to menu
		GameObject toDestroy = GameObject.Find("Interstellar Odyssey");
		Destroy (toDestroy);

		pauseMenuUI.SetActive (false);
		currentScoreText.SetActive (false);
		Time.timeScale = 1.0f;
		gameIsPaused = false;
		DavidMove.playerIsDead = false;
		ScoreScript.scoreValue = 0; // reset score to 0
		SceneManager.LoadScene ("StartScreen");


	}

//	public static void updateScore(int endScore) {
//		currentScoreText.GetComponent<Text> ().text = "Score: " + endScore;
//	}
}
