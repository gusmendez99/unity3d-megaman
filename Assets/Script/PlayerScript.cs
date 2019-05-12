using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

	public float speed;
	public float impulse;

	public Transform floorVerificator;

	bool isOnFloor;

	SpriteRenderer spriteRender;
	Rigidbody2D rb;

	Animator animator;

	// Use this for initialization
	void Start () {
		spriteRender = GetComponent<SpriteRenderer> ();
		rb = GetComponent<Rigidbody2D> ();

		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		// Movement
		float moveX = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime;
		transform.Translate (moveX, 0.0f, 0.0f);

		// Orientation
		if (moveX > 0) {
			spriteRender.flipX = false;
		} else if (moveX < 0) {
			spriteRender.flipX = true;
		}

		// Verifies collision
		isOnFloor = Physics2D.Linecast(transform.position, floorVerificator.position, 1 << LayerMask.NameToLayer("Floor"));

		// Jump
		if (Input.GetAxisRaw("Vertical") > 0.1 && isOnFloor) {
			rb.velocity = new Vector2 (0.0f, impulse);
		}

		animator.SetFloat ("pHorizontal", Mathf.Abs(moveX));
		animator.SetBool ("onFloor", isOnFloor);
		animator.SetBool ("pFire", Input.GetButton ("Jump"));
	}

	void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "EnemyGuy"){
			yield return new WaitForSeconds(0.2f);
   			Time.timeScale = 0.0f;
			GameObject.Find("EndText").GetComponent<Text>().text = "You won!!!";
			userHasWon = false;

			FinishGame();
		}
        
    }

	void FinishGame(){
		Time.deltaTime
	}



}
