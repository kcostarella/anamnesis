using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {
	Animator anim;
	private bool fireOut;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		fireOut = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setFireOut() {
		anim.SetBool ("FireOut", true);
	}

	public void setIsFireOut() {
		fireOut = true;
	}

	public bool isFireOut() {
		return fireOut;	
	}
}

