using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour {

	public GameObject firePrefab;
	public GameObject sensorRotation;

	void Update () {
		// Fire1 - Left control
		// Jump - Spacebar
		if (Input.GetButtonDown ("Jump")) {
			Instantiate (firePrefab, transform.position, transform.rotation);
		}

		// 
		if (Input.GetAxisRaw ("Horizontal") > 0.0f) {
			sensorRotation.transform.eulerAngles = new Vector3 (0.0f, 0.0f, 0.0f);
		} else if (Input.GetAxisRaw ("Horizontal") < 0.0f) {
			sensorRotation.transform.eulerAngles = new Vector3 (0.0f, 180.0f, 0.0f);
		}
	}
}
