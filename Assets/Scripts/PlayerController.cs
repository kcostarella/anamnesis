using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Animator anim;
	private AudioSource stepSound;
	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator> ();
		stepSound = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool getAnimationBoolState(string state) {
		return anim.GetBool (state);
	}

	public void setAnimationBoolState(string state, bool val) {
		anim.SetBool (state, val);
		if (!stepSound.isPlaying && val) {
			stepSound.Play ();
		} else if (stepSound.isPlaying && !val) {
			stepSound.Stop();
		}

	}
}
