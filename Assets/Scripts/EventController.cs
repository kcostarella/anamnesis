using UnityEngine;
using System.Collections;

public class EventController : MonoBehaviour {
	GameObject player; 
	PathFinding pathFinding;
	Camera gameCam;
	public FireController fireController;
	public AudioSource mainSoundTrack;
	public SceneFadeInout fader;


	public string eventName;
	private bool fireOutEventPlayed;
	private bool stopMainMusic;
	private bool gameOver;
	private float velocity;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
		pathFinding = GameObject.FindGameObjectWithTag ("Path").GetComponent<PathFinding> ();
		gameCam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
		fireOutEventPlayed = false;
		stopMainMusic = false;
		gameOver = false;
		velocity = 0.0f;

	}
	
	// Update is called once per frame
	void Update () {
		if (stopMainMusic) {
			mainSoundTrack.volume = Mathf.SmoothDamp(mainSoundTrack.volume, 0.0f, ref velocity, 1.0f);
		}
	}

	public void StartEvent(string name) {
		if (!fireOutEventPlayed && name == "FireOut" ) { 
			stopMainMusic = true;
			StartCoroutine (FireOut());
			fireOutEventPlayed = true;
		}
		if (name == "FireOn") {
			stopMainMusic = true;
			StartCoroutine (FireOn());
		}
	}

	IEnumerator FireOut() {
		pathFinding.setFreeToMove (false);

		yield return new WaitForEndOfFrame ();
		pathFinding.setFinalDestination (GameObject.FindGameObjectWithTag ("Fire").transform.position);
		yield return new WaitForEndOfFrame ();
		pathFinding.setScaleCamArray (1, 4.0f);
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
		mainSoundTrack.Play ();
		mainSoundTrack.volume = 1.0f;
		stopMainMusic = false;
	}

	IEnumerator FireOn() {
		pathFinding.setFreeToMove (false);
		yield return new WaitForEndOfFrame ();
		pathFinding.setFinalDestination (GameObject.FindGameObjectWithTag ("Fire").transform.position);
		yield return new WaitForEndOfFrame ();
		pathFinding.setScaleCamArray (1, 4.0f);
		while (gameCam.orthographicSize > 4.1f) {
			yield return new WaitForEndOfFrame();
		}
		fireController.setFireOn ();
		while (!fireController.isFireOn()) {
			yield return new WaitForEndOfFrame();
		}
		fader.FadeToBlack (2);


	}

}

