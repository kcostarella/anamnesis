using UnityEngine;
using System.Collections;

public class EventController : MonoBehaviour {
	GameObject player; 
	PathFinding pathFinding;
	Camera gameCam;
	public FireController fireController;

	public string eventName;
	private bool fireOutEventPlayed;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		pathFinding = GameObject.FindGameObjectWithTag ("Path").GetComponent<PathFinding> ();
		gameCam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
		fireOutEventPlayed = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartEvent(string name) {
		if (name == "FireOut" && !fireOutEventPlayed) { 
			StartCoroutine (FireOut());
			fireOutEventPlayed = true;
		}
	}

	IEnumerator FireOut() {
		pathFinding.setFreeToMove (false);
		while (gameCam.orthographicSize > 4.1f) {
			yield return new WaitForEndOfFrame();
		}
		fireController.setFireOut ();
		while (!fireController.isFireOut()) {
			yield return new WaitForEndOfFrame();
		}
		float stepVelocity = 0.0f;
		pathFinding.setFreeToMove (true);
		pathFinding.setScaleCamArray (1, 8.0f);
	}
}
