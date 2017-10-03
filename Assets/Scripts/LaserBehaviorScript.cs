using UnityEngine;
using System.Linq;
using System.Collections;

public class LaserBehaviorScript : MonoBehaviour {
	public static bool isSwitched = false;
	private bool wasSwitched = false;

	public void DoSwitchSstate()
	{/*
		isSwitched = !isSwitched;
		wasSwitched = !wasSwitched;

		if (isSwitched)
			SwitchToState2 ();
		else
			SwitchToState1 ();*/
	}

	public void Update()
	{
		/*if (wasSwitched != isSwitched) {
			if (!wasSwitched && isSwitched)
				SwitchToState2 ();
			else if (wasSwitched && !isSwitched)
				SwitchToState1 ();

			wasSwitched = isSwitched;
		}		*/
	}

	private void SwitchToState2()
	{
		var sr = GetComponent<SpriteRenderer> ();
		sr.color = new Color (1, 1, 1, 0.5f);

		GetComponent<Collider2D> ().isTrigger = true;
	}

	private void SwitchToState1()
	{
		var sr = GetComponent<SpriteRenderer> ();
		sr.color = Color.white;

		GetComponent<Collider2D> ().isTrigger = false;
	}


	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.layer == LayerMask.NameToLayer ("Player")) {
			if (LaserBehaviorScript.isSwitched){
			}
			else {
				//Game Over
				Transform tf = coll.transform.root.GetComponentsInChildren<Transform>().First(c => c.gameObject.layer.Equals(LayerMask.NameToLayer("PlatformCollider")));
				tf.position = GameObject.FindGameObjectWithTag ("Spawn").GetComponent<Transform>().position;
			}
		}
	}
}
