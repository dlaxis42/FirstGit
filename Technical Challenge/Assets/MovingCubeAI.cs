using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCubeAI : MonoBehaviour {
	private GameObject center;
	private Animator animator;
	private float distance;
	private bool movingToward = true;
	private float speed;

	// Use this for initialization
	void Start () {
		center = GameObject.FindWithTag ("Player");
		animator = gameObject.GetComponent<Animator> ();distance = Vector3.Distance (center.transform.position, transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		speed = (((float)1.25 * (distance - 4))) * Time.deltaTime;

		if (movingToward == true) {
			transform.position = Vector3.MoveTowards (transform.position, center.transform.position, speed);
		} else {
			transform.position = Vector3.MoveTowards (transform.position, 2 * (transform.position - center.transform.position), speed);
		}

		distance = Vector3.Distance (center.transform.position, transform.position);
		animator.SetFloat ("distanceFromCenter", distance);
	}

	public void setMovementToward (bool newValue) {
		movingToward = newValue;
	}
}
