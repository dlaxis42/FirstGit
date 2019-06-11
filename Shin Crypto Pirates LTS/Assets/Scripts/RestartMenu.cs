using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour {

	public void RestartGame() {
		if (DavidMove.playerIsDead == true) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex - 1);
		}
	}
}
