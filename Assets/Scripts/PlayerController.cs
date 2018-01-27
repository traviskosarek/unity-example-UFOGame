using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rigidbody2d;
	private int count;

	public float speed;
	public Text countText;
	public Text winText;

	void Start () {
		this.rigidbody2d = GetComponent<Rigidbody2D> ();
		this.count = 0;
		this.SetCountText ();
		this.winText.text = "";
	}

	void FixedUpdate() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector2 movement = new Vector2 (moveHorizontal, moveVertical);
	
		this.rigidbody2d.AddForce (movement * speed);
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.CompareTag("PickUp")) {
			other.gameObject.SetActive (false);
			count++;
			this.SetCountText ();
			if (count >= 13) {
				this.winText.text = "You Win!";
			}
		}
	}

	private void SetCountText(){
		this.countText.text = "Count: " + count.ToString ();
	}
		
}
