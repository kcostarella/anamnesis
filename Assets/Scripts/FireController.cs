using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour {
	public AudioSource scarySound;
	private Animator anim;
	private bool fireOut;
	private bool fireOn;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		fireOut = false;
		fireOn = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setFireOut() {
		anim.SetBool ("FireOut", true);

	}

	public void setFireOn() {
		anim.SetBool ("FireOut", false);
		anim.SetBool ("FireOn", true);
	}

	public void setIsFireOut() {
		fireOut = true;
		fireOn = false;
	}

	public bool isFireOut() {
		return fireOut;	
	}

	public void setIsFireOn() {
		fireOn = true;
	}
	
	public bool isFireOn() {
		return fireOn;	
	}

	public void playScarySound() {
		scarySound.Play ();
	}
}

