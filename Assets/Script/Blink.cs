using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Blink : MonoBehaviour {

	// Interval between one blink and another
	public float interval;

	IEnumerator Start () {

		GetComponent<SpriteRenderer> ().enabled = false;
		yield return new WaitForSeconds (interval);
		GetComponent<SpriteRenderer> ().enabled = true;
		yield return new WaitForSeconds (interval);

		// Loops function
		StartCoroutine(Start());
	}

	void Update() {

		// Press enter
		if (Input.GetKeyDown (KeyCode.Return)) {
			SceneManager.LoadScene ("GameScene");
		}


	}
 

	

}
