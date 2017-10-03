using UnityEngine;
using System.Collections;

public class SpikesBehaviorScript : MonoBehaviour {
	public static bool isSwitched = false;
	private bool wasSwitched = false;
	public bool isReversed = false;

	private Sprite spikes;
	private Sprite bounces;

	void Start(){
		if (isReversed) {
			var sr = GetComponent<SpriteRenderer> ();

			sr.color = new Color (1, 0.78f, 0.82f, 1);
			GetComponent<SpriteRenderer> ().sprite = bounces;
		}
	}

	void Awake ()
	{
		spikes = Resources.Load<Sprite> ("Small/Spikes");
		bounces = Resources.Load<Sprite> ("Small/Bounces");
	}

	public void DoSwitchState()
	{
		isSwitched = !isSwitched;
		wasSwitched = !wasSwitched;

		var effect = GetComponent<AudioSource> ();
		effect.Play ();

		UpdateState ();
	}

	public void Update()
	{
		if (wasSwitched != isSwitched) {
			UpdateState ();
			wasSwitched = isSwitched;
		}		
	}

	private void UpdateState()
	{
		var switchOn = isReversed ? !isSwitched : isSwitched;

		if (switchOn)
			SwitchToState2 ();
		else
			SwitchToState1 ();
	}
		
	private void SwitchToState1()
	{
		var sr = GetComponent<SpriteRenderer> ();
		sr.color = Color.white;
		GetComponent<SpriteRenderer> ().sprite = spikes;
	}

	private void SwitchToState2()
	{
		var sr = GetComponent<SpriteRenderer> ();

		sr.color = new Color (1, 0.78f, 0.82f, 1);
		GetComponent<SpriteRenderer> ().sprite = bounces;
	}
}
