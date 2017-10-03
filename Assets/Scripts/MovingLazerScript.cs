using UnityEngine;
using System.Collections;

public class MovingLazerScript : MonoBehaviour {
	public float timeAR = 3;
	float time = 0;
	public float speedY = 0.5f;
	public float speedX = 0.5f;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody2D>().MovePosition(new Vector2(transform.position.x + speedX * Mathf.Cos (Mathf.PI * (time % timeAR / timeAR)), transform.position.y + speedY * Mathf.Cos (Mathf.PI * (time % timeAR / timeAR))));
		time += Time.deltaTime;
	}
}
