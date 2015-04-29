using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool getAnimationBoolState(string state) {
		return anim.GetBool (state);
	}

	public void setAnimationBoolState(string state, bool val) {
		anim.SetBool (state, val);
	}
}
