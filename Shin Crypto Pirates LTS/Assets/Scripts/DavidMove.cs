using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// NOTE: Code heavily based on a tutorial by noobtuts.com
// Source: https://noobtuts.com/unity/2d-pacman-game

public class DavidMove : MonoBehaviour {
	public float speed = 0.4f;
	Vector2 destination = Vector2.zero;
	Vector2 currentDirection = Vector2.zero;
	Vector2 nextDirection = Vector2.zero;

	public static bool playerIsDead = false;

	// Use this for initialization
	void Start () {
		destination = transform.position;
	}

	// Update is called once per frame
	void FixedUpdate () {
		

		// Changes the player's direction if they press an arrow key, it's a valid move,
		// and they're not trying to make a 180-degree turn
		if (Input.GetKey (KeyCode.UpArrow) //&& validMove(Vector2.up)
			&& currentDirection != Vector2.down) {
			//destination = (Vector2)transform.position + Vector2.up;
			nextDirection = Vector2.up;
		}
		if (Input.GetKey (KeyCode.RightArrow) //&& validMove(Vector2.right) 
			&& currentDirection != Vector2.left) {
			//destination = (Vector2)transform.position + Vector2.right;
			nextDirection = Vector2.right;
		}
		if (Input.GetKey (KeyCode.DownArrow) //&& validMove(Vector2.down) 
			&& currentDirection != Vector2.up) {
			//destination = (Vector2)transform.position + Vector2.down;
			nextDirection = Vector2.down;
		}
		if (Input.GetKey (KeyCode.LeftArrow) //&& validMove(Vector2.left) 
			&& currentDirection != Vector2.right) {
			//destination = (Vector2)transform.position + Vector2.left;
			nextDirection = Vector2.left;
		}

		// Move toward the destination
		Vector2 position = Vector2.MoveTowards (transform.position, destination, speed);
		GetComponent<Rigidbody2D> ().MovePosition (position);

		// Is called when the player has moved one space
		if ((Vector2)transform.position == destination) {
			// Keeps the player moving if there isn't a wall in the way
			if (validMove (nextDirection)) {
				currentDirection = nextDirection;
				destination = (Vector2)transform.position + currentDirection;

				// Changes animation based on movement direction
				Vector2 dir = destination - (Vector2)transform.position;
				GetComponent<Animator> ().SetFloat ("DirX", dir.x);
				GetComponent<Animator> ().SetFloat ("DirY", dir.y);

				if (dir.x > 0.1) {
					GetComponent<Animator> ().Play ("right");
				} else if (dir.x < -0.1) {
					GetComponent<Animator> ().Play ("left");
				} else if (dir.y > 0.1) {
					GetComponent<Animator> ().Play ("up");
				} else if (dir.y < -0.1) {
					GetComponent<Animator> ().Play ("down");
				}

			} else if (validMove (currentDirection)) {
				destination = (Vector2)transform.position + currentDirection;
			}
		}
	}

	bool validMove(Vector2 dir) {
		Vector2 pos = transform.position;
		RaycastHit2D hit = Physics2D.Linecast (pos + dir, pos);

		if (hit.collider == null) {
			return true;
		} else if (hit.collider.name == "AlphaMazeBackup") {
			return false;
		} else {
			return true;
		}
	}
}
