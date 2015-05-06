using UnityEngine;
using System.Collections;

public class ColliderLogic : MonoBehaviour {

	private Animator treeAnim;
	private PolygonCollider2D collider;
	// Use this for initialization
	void Start () {
		treeAnim = GameObject.FindGameObjectWithTag ("ShyTree").GetComponent<Animator> ();
		collider = GetComponent<PolygonCollider2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		collider.enabled = !treeAnim.GetBool ("Locked");
	}
}
