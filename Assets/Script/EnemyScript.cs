using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour {

	public int life;
	public GameObject fishPrefab;
	public Transform fishesGenerator;
	public float interval;

	IEnumerator Start() {
		Instantiate (fishPrefab, fishesGenerator.transform.position, fishesGenerator.transform.rotation);
		yield return new WaitForSeconds (interval);

		StartCoroutine (Start ());
	}

	void OnCollisionEnter2D (Collision2D c) {
		if (c.gameObject.tag == "Fire") {
			life--;
			if (life <= 0) {
				//Player has won
				Destroy (gameObject);
				GameObject.Find("EndText").GetComponent<Text>().text = "You won!";
				GameScript.Instance.userHasWon = true;
			}
		}
	}
}
