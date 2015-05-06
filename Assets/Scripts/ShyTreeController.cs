using UnityEngine;
using System.Collections;

public class ShyTreeController : MonoBehaviour {

    GameObject player;
    PlayerStatus playerStatus;
    PlayerController playerController;
    Animator anim;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStatus = player.GetComponent<PlayerStatus>();
        playerController = player.GetComponent<PlayerController>();

        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log((gameObject.transform.position - player.transform.position).magnitude);
        if (playerStatus.shyTreeActive)
        {
            bool moving = playerController.getAnimationBoolState("Moving");
           
            if (moving)
            {
                anim.SetBool("Forward", true);
            }
            else
            {
                anim.SetBool("Forward", false);
            }
        }


        if (Physics2D.Linecast(gameObject.transform.position, player.transform.position))
        {
            anim.SetBool("Locked", false);
        }
	}

    void LockDown()
    {
        if (anim.GetBool("Forward"))
        {
            anim.SetBool("Locked", true);
        }
    }

}
