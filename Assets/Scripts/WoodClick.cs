using UnityEngine;
using System.Collections;

public class WoodClick : MonoBehaviour {

    GameObject player;
    PlayerStatus playerStatus;
    GameObject shyTree;
    Animator shyTreeAnim;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        shyTree = GameObject.FindGameObjectWithTag("ShyTree");
        shyTreeAnim = shyTree.GetComponent<Animator>();
        playerStatus = player.GetComponent<PlayerStatus>();
    }
	// Use this for initialization
    void OnMouseDown()
    {
        if ((shyTree.transform.position - player.transform.position).magnitude < 2.0)
        {
            if (!shyTreeAnim.GetBool("Locked"))
            {
                Destroy(gameObject);
                playerStatus.numWood += 1;
                //Debug.Log("Wood Collected");
                playerStatus.shyTreeActive = false;
            }
        }
    }
}
