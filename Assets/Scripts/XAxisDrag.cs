using UnityEngine;
using System.Collections;

public class XAxisDrag : MonoBehaviour {
	public float xMax;
	public float xMin;
	public float yValue;
	private Vector3 WorldPosition;
	// Use this for initialization
	void Start () {
	}
	
	void OnMouseDrag() {
		//Vector3 dis = (gameObject.transform.position - player.transform.position);
		//if (dis.magnitude < 5) {
		WorldPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		transform.position = new Vector3 (Mathf.Clamp (WorldPosition.x,xMin,xMax), yValue, gameObject.transform.position.z);
		//}
	}
}
