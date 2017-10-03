using UnityEngine;
using System.Collections;

public class FaderScript : MonoBehaviour {
	public Texture2D fadeOutTexture;
	public float fadeSpeed = 0.2f;

	private int drawDepth = -2;
	public float alpha = -1f;
	private int fadeDir = -1;

	void OnGUI()
	{
		alpha += fadeDir * fadeSpeed * Time.deltaTime;

		//Debug.Log ("Before alpha : " + alpha);
		alpha = Mathf.Clamp01 (alpha);

		//Debug.Log ("Alpha : " + alpha);

		GUI.color = new Color (GUI.color.r, GUI.color.g, GUI.color.b, alpha);
		GUI.depth = drawDepth;
		GUI.DrawTexture (new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture);
	}

	public float BeginFade(int direction)
	{
		fadeDir = direction;
		return 1 / fadeSpeed;
	}

	void OnLevelWasLoaded(){
		BeginFade (-1);
	}
}
