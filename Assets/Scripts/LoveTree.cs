using UnityEngine;
using System.Collections;

public class LoveTree : MonoBehaviour {
	public GameObject lover;
	public float lovePosition;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	

	// Update is called once per frame
	void Update () {
		if (Mathf.Approximately (gameObject.transform.position.x, lovePosition) && Mathf.Approximately (lover.gameObject.transform.position.x, lover.GetComponent<LoveTree> ().lovePosition)) {
			anim.SetBool ("Love",true);
			gameObject.GetComponent<BoxCollider2D>().enabled = false;
		}
	}
}
