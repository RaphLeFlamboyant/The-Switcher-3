using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;
using System.Collections;

public class KillingZone : MonoBehaviour {
	public AudioClip deathSound;

	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.layer == LayerMask.NameToLayer ("Player"))
		{
			Transform tf = coll.transform.root.GetComponentsInChildren<Transform>().First(c => c.gameObject.layer.Equals(LayerMask.NameToLayer("PlatformCollider")));
			tf.position = GameObject.FindGameObjectWithTag ("Spawn").GetComponent<Transform>().position;

			AudioSource audioSrc = GetComponent<AudioSource> ();
			audioSrc.clip = deathSound;
			audioSrc.Play();
			//deathSound.Play ();
		}


		if (coll.gameObject.layer == LayerMask.NameToLayer ("Pyupyu"))
		{
			StartCoroutine (DoEndGame ());
		}
	}

	IEnumerator DoEndGame()
	{
		float fadeTime = GameObject.Find ("Game Controller").GetComponent<FaderScript> ().BeginFade(1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene ("Ending");
	}
}
