using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotationGameobject : MonoBehaviour {

	public float rotationRate= 10f;
	// Use this for initialization
	void Start () {
		Debug.Log ("Gameobject's Rotation Started :)");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.down, rotationRate * Time.deltaTime);
		
	}
}
