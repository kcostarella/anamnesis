using UnityEngine;
using System.Collections;

public class IntroSceneCam : MonoBehaviour {
	GraphManager gm;
	// Use this for initialization
	void Start () {
		gm = GetComponent<GraphManager> ();

		foreach (GameObject w in gm.waypoints) {
			Waypoint wp = w.GetComponent<Waypoint>();
			wp.setCameraScale (6.0f);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
