using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelEndScript : MonoBehaviour {


	void OnTriggerEnter2D(Collider2D coll) {
		SpikesBehaviorScript.isSwitched = false;
		WallBehaviorScript.isSwitched = false;

		StartCoroutine (DoEndGame ());
	}

	IEnumerator DoEndGame()
	{
		float fadeTime = GameObject.Find ("Game Controller").GetComponent<FaderScript> ().BeginFade(1);
		yield return new WaitForSeconds (fadeTime);
		SceneManager.LoadScene ("Boss");
	}
}
