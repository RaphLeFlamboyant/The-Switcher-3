using UnityEngine;
using System.Collections;
using System.Linq;

public class SpikesPointScript : MonoBehaviour {
	public SpikesBehaviorScript ownerScript;
	public AudioClip deathSound;
	public float jumpForce = 4;

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.layer == LayerMask.NameToLayer ("PlayerFeet") || coll.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			var switchOn = ownerScript.isReversed ? !SpikesBehaviorScript.isSwitched : SpikesBehaviorScript.isSwitched;
			if (switchOn){
				var test = coll.transform.root.GetComponentsInChildren<Rigidbody2D> ().ToList ();
				var rgb = coll.transform.root.GetComponentsInChildren<Rigidbody2D>().First(c => c.gameObject.layer.Equals(LayerMask.NameToLayer("PlatformCollider")));

				//rgb.AddForce (Vector2.up * jumpForce, ForceMode2D.Impulse);
				rgb.velocity = this.transform.root.up * 10;// new Vector2 (rgb.velocity.x, 10);//(Vector2.up * 8, ForceMode2D.Impulse);
			}
			else {
				//Game Over
				Transform tf = coll.transform.root.GetComponentsInChildren<Transform>().First(c => c.gameObject.layer.Equals(LayerMask.NameToLayer("PlatformCollider")));
				tf.position = GameObject.FindGameObjectWithTag ("Spawn").GetComponent<Transform>().position;
			}
		}
	}
	/*
	void OnDrawGizmos()
	{
		Color color;
		color = Color.green;
		// local up
		DrawHelperAtCenter(this.transform.up, color, 2f);

		color= Color.blue;
		// global up
		DrawHelperAtCenter(this.transform.root.up, color, 1f);

		color= Color.red;
		// global up
		DrawHelperAtCenter(Vector3.up, color, 1f);
		/*
		color = Color.blue;
		// local forward
		DrawHelperAtCenter(this.transform.forward, color, 2f);

		color.b -= 0.5f;
		// global forward
		DrawHelperAtCenter(Vector3.forward, color, 1f);

		color = Color.red;
		// local right
		DrawHelperAtCenter(this.transform.right, color, 2f);

		color.r -= 0.5f;
		// global right
	}

	private void DrawHelperAtCenter(
		Vector3 direction, Color color, float scale)
	{
		Gizmos.color = color;
		Vector3 destination = transform.position + direction * scale;
		Gizmos.DrawLine(transform.position, destination);
	}*/
}
