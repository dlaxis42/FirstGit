using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMove : MonoBehaviour {
	public float speed = 0.4f;
	Vector2 destination = Vector2.zero;
	Vector2 currentDirection = Vector2.zero;
	Vector2 dir = Vector2.zero;

	public AudioSource hitPlayer;
	public AudioSource hitAI;

	// Vectors to serve as the cardinal directions
	Vector2 up = Vector2.up;
	Vector2 left = Vector2.left;
	Vector2 down = Vector2.down;
	Vector2 right = Vector2.right;

	// Use this for initialization
	void Start () {
		destination = transform.position;
		DavidMove.playerIsDead = false;;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

//		changeSpeed (); // testing speed changes

		// Changes animation based on movement direction
		dir = destination - (Vector2)transform.position;
		GetComponent<Animator> ().SetFloat ("dirX", dir.x);
		GetComponent<Animator> ().SetFloat ("dirY", dir.y);

		if (dir.x > 0.1) {
			GetComponent<Animator> ().Play ("right");
		} else if (dir.x < -0.1) {
			GetComponent<Animator> ().Play ("left");
		} else if (dir.y > 0.1) {
			GetComponent<Animator> ().Play ("up");
		} else if (dir.y < -0.1) {
			GetComponent<Animator> ().Play ("down");
		}

		// Is called when the enemy has moved one space
		if ((Vector2)transform.position == destination) {

			// Selects a random cardinal direction (0=up, 1=left, 2=down, 3=right)
			int directionSelect = Random.Range (0, 4);

			// Selects whether to check other directions in counterclockwise (0)
			// or clockwise (1)
			int rotatePreference = Random.Range (0, 2);

			// If up is selected
			if (directionSelect == 0) {
				// Checks if moving up is valid
				if (validMove (up) && currentDirection != down) {
					currentDirection = up;

				// Checks all directions, counterclockwise
				} else if (rotatePreference == 0) {
					if (validMove (left) && currentDirection != right) {
						currentDirection = left;
					} else if (validMove (down) && currentDirection != up) {
						currentDirection = down;
					} else if (validMove (right) && currentDirection != left) {
						currentDirection = right;
					} else {
						currentDirection = Vector2.zero;
					}

				// Checks all directions, clockwise
				} else if (rotatePreference == 1) {
					if (validMove (right) && currentDirection != left) {
						currentDirection = right;
					} else if (validMove (down) && currentDirection != up) {
						currentDirection = down;
					} else if (validMove (left) && currentDirection != right) {
						currentDirection = left;
					} else {
						currentDirection = Vector2.zero;
					}

				// If none are valid, stops moving
				} else {
					currentDirection = Vector2.zero;
				}

			// If left is selected
			} else if (directionSelect == 1) {
				// Checks if moving left is valid
				if (validMove (left) && currentDirection != right) {
					currentDirection = left;

				// Checks all directions, counterclockwise
				} else if (rotatePreference == 0) {
					if (validMove (down) && currentDirection != up) {
						currentDirection = down;
					} else if (validMove (right) && currentDirection != left) {
						currentDirection = right;
					} else if (validMove (up) && currentDirection != down) {
						currentDirection = up;
					} else {
						currentDirection = Vector2.zero;
					}

				// Checks all directions, clockwise
				} else if (rotatePreference == 1) {
					if (validMove (up) && currentDirection != down) {
						currentDirection = up;
					} else if (validMove (right) && currentDirection != left) {
						currentDirection = right;
					} else if (validMove (down) && currentDirection != up) {
						currentDirection = down;
					} else {
						currentDirection = Vector2.zero;
					}

				// If none are valid, stops moving
				} else {
					currentDirection = Vector2.zero;
				}

			// If down is selected
			} else if (directionSelect == 2) {
				// Checks if moving down is valid
				if (validMove (down) && currentDirection != up) {
					currentDirection = down;

				// Checks all directions, counterclockwise
				} else if (rotatePreference == 0) {
					if (validMove (right) && currentDirection != left) {
						currentDirection = right;
					} else if (validMove (up) && currentDirection != down) {
						currentDirection = up;
					} else if (validMove (left) && currentDirection != right) {
						currentDirection = left;
					} else {
						currentDirection = Vector2.zero;
					}

				// Checks all directions, clockwise
				} else if (rotatePreference == 1) {
					if (validMove (left) && currentDirection != right) {
						currentDirection = left;
					} else if (validMove (up) && currentDirection != down) {
						currentDirection = up;
					} else if (validMove (right) && currentDirection != left) {
						currentDirection = right;
					} else {
						currentDirection = Vector2.zero;
					}

				// If none are valid, stops moving
				} else {
					currentDirection = Vector2.zero;
				}

			// If right is selected
			} else if (directionSelect == 3) {
				// Checks if moving right is valid
				if (validMove (right) && currentDirection != left) {
					currentDirection = right;

				// Checks all directions, counterclockwise
				} else if (rotatePreference == 0) {
					if (validMove (up) && currentDirection != down) {
						currentDirection = up;
					} else if (validMove (left) && currentDirection != right) {
						currentDirection = left;
					} else if (validMove (down) && currentDirection != up) {
						currentDirection = down;
					} else {
						currentDirection = Vector2.zero;
					}

				// Checks all directions, clockwise
				} else if (rotatePreference == 1) {
					if (validMove (down) && currentDirection != up) {
						currentDirection = down;
					} else if (validMove (left) && currentDirection != right) {
						currentDirection = left;
					} else if (validMove (up) && currentDirection != down) {
						currentDirection = up;
					} else {
						currentDirection = Vector2.zero;
					}

				// If none are valid, stops moving
				} else {
					currentDirection = Vector2.zero;
				}

			} else {
				currentDirection = Vector2.zero;
			}

			destination = (Vector2)transform.position + currentDirection;
		}

		Vector2 position = Vector2.MoveTowards (transform.position, destination, speed);
		GetComponent<Rigidbody2D> ().MovePosition (position);
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

		//return (hit.collider == GetComponent<Collider2D> ());
	}

	void OnTriggerEnter2D(Collider2D co) {
		if (co.tag == "Player") {
			Destroy (co.gameObject);
			DavidMove.playerIsDead = true; // if it hits the player, then turns player dead
			hitPlayer.Play ();

		} else if (co.tag == "Enemy") {
			Destroy (gameObject);
			hitAI.Play ();
		}
	}

	void changeSpeed() {
		speed = DifficultyToggle.enemySpeed;
	}
}
