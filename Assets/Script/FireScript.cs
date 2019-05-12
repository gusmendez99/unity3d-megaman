using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

	public float speed;

	void Start () {
		// Destroy after 3 seconds
		Destroy (gameObject, 3.0f);
	}

	private void OnCollisionEnter2D(Collision2D collision) { 
		// Destroying on collision
		Destroy (gameObject);
	}

	void OnTriggerEnter2D(Collider2D c) {
		if (c.tag == "Enemy") {
			// Destroys enemy and fire objects
			Destroy (c.gameObject);
			Destroy (gameObject);
		}
	}

	void Update () {
		// Move projectile
		transform.Translate (Vector2.right * speed * Time.deltaTime);
	}
}
