using UnityEngine;
using System.Collections;

public class playerTracker : MonoBehaviour {
	public Transform playerTransform;
	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector3 (playerTransform.position.x, playerTransform.position.y, gameObject.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.position = new Vector3 (playerTransform.position.x, playerTransform.position.y, gameObject.transform.position.z);
	}
}
