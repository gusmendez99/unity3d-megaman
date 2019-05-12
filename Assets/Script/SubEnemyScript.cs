using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubEnemyScript : MonoBehaviour {

	public GameObject target;
	public float speed;
	private SpriteRenderer render;

	void Start () {

		// Sets player as a target, subenemy will move to it
		target = GameObject.FindGameObjectWithTag ("Player");

		render = GetComponent<SpriteRenderer> ();
	}

	void Update () {

		if (transform.position.x >= target.transform.position.x) {
			render.flipX = false;
		} else {
			render.flipX = true;
		}

		// Moves into target
		transform.position = Vector2.Lerp (transform.position, target.transform.position, speed * Time.deltaTime);

	}
}
