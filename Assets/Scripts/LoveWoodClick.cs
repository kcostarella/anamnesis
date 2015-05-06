using UnityEngine;
using System.Collections;

public class LoveWoodClick : MonoBehaviour {
	
	public SpriteRenderer woodSprite;
	bool woodFadeIn;
	private float startTime;
	Animator loveTreeAnim;
	PlayerStatus playerStatus;
	PolygonCollider2D polyCol;
	private bool happened = false;

	// Use this for initialization
	void Start () {
		playerStatus = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerStatus> ();
		polyCol = GetComponent<PolygonCollider2D> ();
		polyCol.enabled = false;
		woodSprite = GetComponent<SpriteRenderer> ();
		woodFadeIn = false;
		loveTreeAnim = GameObject.FindGameObjectWithTag ("LoveTree").GetComponent<Animator> ();
	}

	void Update() {
		if (!happened && loveTreeAnim.GetBool ("Love")) {
			woodFadeIn = true;
			startTime = Time.time;
			polyCol.enabled = true;
			happened = !happened;
		}

		if (woodFadeIn) {
			float t = (Time.time - startTime) / 1f;
			if(woodSprite != null)
				woodSprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(0f, 1f, t));
		}
	}
	
	void OnMouseDown() {
		Destroy(gameObject);
		playerStatus.numWood += 1;
	}

}
