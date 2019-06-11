using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedSpawn : MonoBehaviour {

	public Transform[] spawnPoints;
	public GameObject[] objects; // use this object

	public bool stopSpawn = false;
	public float spawnTime; 
	public float spawnDelay;

	// Use this for initialization
	void Start () {
		// constantly calls the 
		InvokeRepeating ("SpawnObject", spawnTime, spawnDelay);
	}

	public void SpawnObject() {
		int rand = Random.Range (0, objects.Length);
		int randSpawn = Random.Range (0, spawnPoints.Length);

		Instantiate (objects [rand], spawnPoints[randSpawn].position, transform.rotation);

		if (stopSpawn) {
			CancelInvoke ("SpawnObject");
		}
	}
}
