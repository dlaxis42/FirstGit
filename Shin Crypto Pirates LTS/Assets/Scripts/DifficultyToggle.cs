using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DifficultyToggle : MonoBehaviour {

	public GameObject[] enemiesList;
	public int gameDifficulty = 0;
	public GameObject difficultyText;

	public static float enemySpeed = 0.4f;

	// Use this for initialization
	void Start () {
		difficultyText.GetComponent<Text>().text = "Difficulty: Easy";
		enemySpeed = 0.05f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.D)) {
			gameDifficulty++;

			if (gameDifficulty > 2) {
				gameDifficulty = 0;
			}

			if (gameDifficulty == 0) {
				difficultyText.GetComponent<Text>().text = "Difficulty: Easy";
				enemySpeed = 0.05f;
			} else if (gameDifficulty == 1) {
				difficultyText.GetComponent<Text>().text = "Difficulty: Medium";
				enemySpeed = 0.075f;
			} else if (gameDifficulty == 2) {
				difficultyText.GetComponent<Text>().text = "Difficulty: Hard";
				enemySpeed = 0.11f;
			}
		}
	}
}
