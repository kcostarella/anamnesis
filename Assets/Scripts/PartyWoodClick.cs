using UnityEngine;
using System.Collections;

public class PartyWoodClick : MonoBehaviour {
    
    GameObject player;
    PlayerStatus playerStatus;
	AudioSource gong;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStatus = player.GetComponent<PlayerStatus>();
		gong = GameObject.FindGameObjectWithTag("Gong").GetComponent<AudioSource> ();    }

    void OnMouseDown()
    {
		gong.Play ();
		Destroy(gameObject);
        playerStatus.numWood += 1;
    }
}
