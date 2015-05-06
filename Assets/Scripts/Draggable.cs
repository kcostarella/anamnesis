using UnityEngine;
using System.Collections;

public class Draggable : MonoBehaviour {
	private Vector3 WorldPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	void OnMouseDrag() {
		WorldPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.localPosition = new Vector3 (WorldPosition.x, WorldPosition.y, gameObject.transform.position.z);
		print ("World Position: " + WorldPosition + " buttBunnyPosition: " + transform.localPosition);
	}
}
