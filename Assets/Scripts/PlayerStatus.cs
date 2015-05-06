using UnityEngine;
using System.Collections;

public class PlayerStatus : MonoBehaviour {

    public bool shyTreeActive;
    public bool moving;
    public int numWood;
	public EventController eventController;
	bool doOnce = false;
    void Awake()
    {
        moving = false;
        shyTreeActive = false;
        numWood = 0;
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!doOnce && numWood == 3) {
			eventController.eventName = "FireOn";
			doOnce = !doOnce;
		}
	}
}
