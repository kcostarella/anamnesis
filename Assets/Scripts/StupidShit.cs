using UnityEngine;
using System.Collections;

public class StupidShit : MonoBehaviour {

	// Use this for initialization
	void Awake() {
		gameObject.transform.position = Vector3.zero;

	}
	void Start () {
		gameObject.transform.position = new Vector3 (-6.94f, 2.2f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
	}
}
