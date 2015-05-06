using UnityEngine;
using System.Collections;

public class IntroSceneCam : MonoBehaviour {
	GraphManager gm;
	// Use this for initialization
	void Start () {
		gm = GetComponent<GraphManager> ();

		foreach (GameObject w in gm.waypoints) {
			Debug.Log ("I'M A BITCH");
			Waypoint wp = w.GetComponent<Waypoint>();
			wp.setCameraScale (10.0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
