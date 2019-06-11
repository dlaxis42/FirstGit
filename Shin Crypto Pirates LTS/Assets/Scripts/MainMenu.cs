using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject instructionUI;

	// Use this for initialization
	public void PlayGame() {
		Time.timeScale = 1.0f;

		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public static void LoadNext() {
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void activateInstructions() {
		instructionUI.SetActive (true);
	}

	public void deactivateInstructions() {
		instructionUI.SetActive (false);
	}
}
