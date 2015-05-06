using UnityEngine;
using System.Collections;

public class ExitScene : MonoBehaviour {
	public SceneFadeInout fader;
	public Transform playerTransform;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if ((gameObject.transform.position - playerTransform.position).magnitude < 1) {
			fader.FadeToBlack(1);
		}
	}
}
