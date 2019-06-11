using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MazeBehavior : MonoBehaviour {

	string sceneName;
	public static string mainSceneName;

	// Use this for initialization
	void Start () {
		sceneName = SceneManager.GetActiveScene ().name;
		mainSceneName = sceneName;
	}
	
	// Update is called once per frame
	void Update () {
//		if (Input.GetKeyDown (KeyCode.R)) {
//			restartGame ();
//		}
	}

	public static void restartGame() {
		SceneManager.LoadScene (mainSceneName);
		DavidMove.playerIsDead = false;
	}
}
