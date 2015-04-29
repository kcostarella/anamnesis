using UnityEngine;
using System.Collections;

public class playerTracker : MonoBehaviour {
	public Transform playerTransform;
	public float xMin;
	public float xMax;
	public float yMin;
	public float yMax;
	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector3 (playerTransform.position.x, playerTransform.position.y, gameObject.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
			gameObject.transform.position = new Vector3 (Mathf.Clamp(playerTransform.position.x,xMin, xMax), Mathf.Clamp (playerTransform.position.y,yMin,yMax), gameObject.transform.position.z);
	}
}
