using UnityEngine;
using System.Collections;

public class ShyTreeTrigger : MonoBehaviour {

    GameObject player;
    PlayerStatus playerStatus;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStatus = player.GetComponent<PlayerStatus>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dis = (gameObject.transform.position - player.transform.position);
        //Debug.Log(dis.magnitude);

        if ((dis.x < 0 && dis.x > -0.5) && dis.magnitude < 1)
        {
            playerStatus.shyTreeActive = true;
        }

	}
}
