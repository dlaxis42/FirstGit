using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seekerMove : MonoBehaviour {
	public float speed = 0.4f;
	Vector2 destination = Vector2.zero;
	Vector2 currentDirection = Vector2.zero;
	Vector2 dir = Vector2.zero;

	Vector2 seekerPosition = Vector2.zero;
	Vector2 playerPosition = Vector2.zero;

	// Vectors to serve as the cardinal directions
	Vector2 up = Vector2.up;
	Vector2 left = Vector2.left;
	Vector2 down = Vector2.down;
	Vector2 right = Vector2.right;

	public AudioSource hitPlayer;
	public AudioSource hitAI;


	// Use this for initialization
	void Start () {
		destination = transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
//		changeSpeed (); // testing speed changes

		seekerPosition = transform.position;
		playerPosition = GameObject.FindWithTag ("Player").transform.position;

		// Changes animation based on movement direction
		dir = destination - (Vector2)transform.position;
		GetComponent<Animator> ().SetFloat ("dirX", dir.x);
		GetComponent<Animator> ().SetFloat ("dirY", dir.y);

		if (dir.x > 0.1) {
			GetComponent<Animator> ().Play ("seekerVanRight");
		} else if (dir.x < -0.1) {
			GetComponent<Animator> ().Play ("seekerVanLeft");
		} else if (dir.y > 0.1) {
			GetComponent<Animator> ().Play ("seekerVanUp");
		} else if (dir.y < -0.1) {
			GetComponent<Animator> ().Play ("seekerVanDown");
		}

		if ((Vector2)transform.position == destination) {

			// Checks whether the vertical or horizontal distance between seeker and player is greater
			if (Mathf.Abs (seekerPosition.x - playerPosition.x) >
			   Mathf.Abs (seekerPosition.y - playerPosition.y)) {
				// Checks whether the player is left or right of the seeker
				if (seekerPosition.x > playerPosition.x) {
					// Put precedence on moving left
					if (validMove (left) && currentDirection != right) {
						currentDirection = left;
					} else if (seekerPosition.y > playerPosition.y) {
						if (validMove (down) && currentDirection != up) {
							currentDirection = down;
						} else if (validMove (up) && currentDirection != down) {
							currentDirection = up;
						} else if (validMove (right) && currentDirection != left) {
							currentDirection = right;
						}
					} else {
						if (validMove (up) && currentDirection != down) {
							currentDirection = up;
						} else if (validMove (down) && currentDirection != up) {
							currentDirection = down;
						} else if (validMove (right) && currentDirection != left) {
							currentDirection = right;
						}
					}
				} else {
					// Put precedence on moving right
					if (validMove (right) && currentDirection != left) {
						currentDirection = right;
					} else if (seekerPosition.y > playerPosition.y) {
						if (validMove (up) && currentDirection != down) {
							currentDirection = up;
						} else if (validMove (down) && currentDirection != up) {
							currentDirection = down;
						} else if (validMove (left) && currentDirection != right) {
							currentDirection = left;
						}
					} else {
						if (validMove (down) && currentDirection != up) {
							currentDirection = down;
						} else if (validMove (up) && currentDirection != down) {
							currentDirection = up;
						} else if (validMove (left) && currentDirection != right) {
							currentDirection = left;
						}
					}
				}
			} else {
				// Checks whether the player is above or below the seeker
				if (seekerPosition.y > playerPosition.y) {
					// Put precedence on moving down
					if (validMove (down) && currentDirection != up) {
						currentDirection = down;
					} else if (seekerPosition.x > playerPosition.x) {
						if (validMove (left) && currentDirection != right) {
							currentDirection = left;
						} else if (validMove (right) && currentDirection != left) {
							currentDirection = right;
						} else if (validMove (up) && currentDirection != down) {
							currentDirection = up;
						}
					} else {
						if (validMove (right) && currentDirection != left) {
							currentDirection = right;
						} else if (validMove (left) && currentDirection != right) {
							currentDirection = left;
						} else if (validMove (up) && currentDirection != down) {
							currentDirection = up;
						}
					}
				} else {
					// Checks if moving up is valid
					if (validMove (up) && currentDirection != down) {
						currentDirection = up;
					} else if (seekerPosition.x > playerPosition.x) {
						if (validMove (left) && currentDirection != right) {
							currentDirection = left;
						} else if (validMove (right) && currentDirection != left) {
							currentDirection = right;
						} else if (validMove (down) && currentDirection != up) {
							currentDirection = down;
						}
					} else {
						if (validMove (right) && currentDirection != left) {
							currentDirection = right;
						} else if (validMove (left) && currentDirection != right) {
							currentDirection = left;
						} else if (validMove (down) && currentDirection != up) {
							currentDirection = down;
						}
					}
				}
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
	}

	void OnTriggerEnter2D(Collider2D co) {
		if (co.tag == "Player") {
			Destroy (co.gameObject);

			DavidMove.playerIsDead = true; // if it hits the player, then turns player dead
			hitPlayer.Play ();

		} else if (co.tag == "Enemy") {
			hitAI.Play ();
		}
	}

	void changeSpeed() {
		speed = DifficultyToggle.enemySpeed;
	}
}
