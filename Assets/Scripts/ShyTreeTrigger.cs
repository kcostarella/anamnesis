using UnityEngine;
using System.Collections;

public class ShyTreeTrigger : MonoBehaviour {

    GameObject player;
    PlayerStatus playerStatus;
	Animator treeAnim;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStatus = player.GetComponent<PlayerStatus>();
		treeAnim = GameObject.FindGameObjectWithTag ("ShyTree").GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 dis = (gameObject.transform.position - player.transform.position);
        //Debug.Log(dis.magnitude);

        if (dis.magnitude < 1)
        {
            playerStatus.shyTreeActive = true;
			treeAnim.SetBool ("Locked", false);
        }

	}
}
