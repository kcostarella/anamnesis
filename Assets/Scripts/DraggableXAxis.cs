using UnityEngine;
using System.Collections;

public class DraggableXAxis : MonoBehaviour {
	public float xMax;
	public float xMin;
	private Vector3 WorldPosition;
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void OnMouseDrag() {
		//Vector3 dis = (gameObject.transform.position - player.transform.position);
		//if (dis.magnitude < 5) {
			WorldPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			print (WorldPosition);
			transform.position = new Vector3 (Mathf.Clamp (WorldPosition.x,xMin,xMax), gameObject.transform.position.z, gameObject.transform.position.z);
		//}
	}
}
