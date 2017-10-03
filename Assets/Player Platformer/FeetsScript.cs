using UnityEngine;
using System.Linq;
using System.Collections;

public class FeetsScript : MonoBehaviour {
	public bool isGrounded;
	public bool isJumping;
	private int nbFrames;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		var coll = GetComponent<Collider2D> ();
		var hit = Physics2D.Raycast(new Vector2(coll.bounds.min.x, coll.bounds.min.y - 0.001f), Vector2.down, coll.bounds.size.y / 4)
			|| Physics2D.Raycast(new Vector2(coll.bounds.center.x, coll.bounds.min.y - 0.001f), Vector2.down, coll.bounds.size.y / 4)
			|| Physics2D.Raycast(new Vector2(coll.bounds.max.x, coll.bounds.min.y - 0.001f), Vector2.down, coll.bounds.size.y / 4);
		isGrounded = hit;// && !hit.collider.isTrigger;
	}

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.layer == LayerMask.NameToLayer ("Block") && !coll.isTrigger){
			isJumping = false;
		}
		/*
		isGrounded = numberPlatformsTouch > 0;

		/*Transform tf = transform.root.GetComponentsInChildren<Transform>().First(c => c.gameObject.layer.Equals(LayerMask.NameToLayer("PlayerTronche")));
		var anim = tf.GetComponent<Animator> ();
		if (!isGrounded) {
			anim.SetBool ("isInTheAirs", true);
		}
		else
			anim.SetBool ("isInTheAirs", false);*/
	}
	/*
	void OnTriggerStay2D(Collider2D coll){
		if (coll.gameObject.layer == LayerMask.NameToLayer ("Block") && !coll.isTrigger){
			isGrounded = true;
		}

	}

	void  OnTriggerExit2D(Collider2D coll){
		if (coll.gameObject.layer == LayerMask.NameToLayer ("Block") && !coll.isTrigger) {
			numberPlatformsTouch--;
		}
		
		isGrounded = numberPlatformsTouch > 0;

		//Transform tf = transform.root.GetComponentsInChildren<Transform>().First(c => c.gameObject.layer.Equals(LayerMask.NameToLayer("PlayerTronche")));
		//var anim = tf.GetComponent<Animator> ();
		//if (!isGrounded) {
			//anim.SetBool ("isInTheAirs", true);
		//}
		//else
			//anim.SetBool ("isInTheAirs", false);
	}*/
}
