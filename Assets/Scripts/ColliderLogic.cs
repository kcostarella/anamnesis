using UnityEngine;
using System.Collections;

public class ColliderLogic : MonoBehaviour {

	private Animator treeAnim;
	private PolygonCollider2D colliderDude;
	// Use this for initialization
	void Start () {
		treeAnim = GameObject.FindGameObjectWithTag ("ShyTree").GetComponent<Animator> ();
		colliderDude = GetComponent<PolygonCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		colliderDude.enabled = !treeAnim.GetBool ("Locked");
	}
}
