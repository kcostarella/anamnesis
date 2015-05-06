using UnityEngine;
using System.Collections;

public class PartyWoodClick : MonoBehaviour {
    
    GameObject player;
    PlayerStatus playerStatus;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStatus = player.GetComponent<PlayerStatus>();
    }

    void OnMouseDown()
    {
        Destroy(gameObject);
        playerStatus.numWood += 1;
    }
}
