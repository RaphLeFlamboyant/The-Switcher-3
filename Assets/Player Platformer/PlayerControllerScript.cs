using UnityEngine;
using System.Linq;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {
	public FeetsScript feets;
	public InfluenceScript influenceZone;
	public float jumpForce = 8;
	public float jumpMaintainForce = 8;
	public float moveForce = 8;
	public float minVelocityX = 0.5f;

	// Use this for initialization
	void Start () {
		//GetComponent<Rigidbody2D> ().freezeRotation = true;

	}
	
	// Update is called once per frame
	void Update () {
		var rgb = GetComponent<Rigidbody2D> ();

		if (Input.GetButtonDown ("Jump")) {
			if (feets.isGrounded) {
				var effect = GetComponent<AudioSource> ();
				effect.Play ();
				rgb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
				feets.isJumping = true;
			}
		}
				
		if (Input.GetButton ("Jump") && feets.isJumping) {
			if (rgb.velocity.y > 0)
				rgb.AddForce(Vector2.up * jumpMaintainForce, ForceMode2D.Force);
		}

		//Transform tf = transform.root.GetComponentsInChildren<Transform>().First(c => c.gameObject.layer.Equals(LayerMask.NameToLayer("PlayerTronche")));
		//var anim = tf.GetComponent<Animator> ();
		if (Input.GetButton ("Horizontal")) {
			{
				if (Input.GetAxis ("Horizontal") > 0)
					rgb.AddForce (Vector2.right * moveForce);
				else
					rgb.AddForce (Vector2.left * moveForce);

				//anim.SetBool ("isWalking", true);
			}
		}
		else {
			if (rgb.velocity.x < minVelocityX && rgb.velocity.x > -minVelocityX){
				rgb.velocity = new Vector2 (0, rgb.velocity.y);
				rgb.angularVelocity = 0;
			}
		}
		//else
			//anim.SetBool ("isWalking", false);

		/*if (Input.GetButtonDown ("Action")) {
			foreach (Collider2D coll in influenceZone.interactableList) {
				coll.GetComponent<InteractableObject> ().SwitchState ();
			}
		}*/


	}
}
