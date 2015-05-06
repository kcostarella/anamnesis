using UnityEngine;
using System.Collections;

public class BoomboxClick : MonoBehaviour {
    
    GameObject player;
    PlayerStatus playerStatus;
    GameObject partyTree;
    AudioSource audio;
    SpriteRenderer woodSprite;
    Animator partyTreeAnim;
    bool woodFadeIn;
    private float startTime;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStatus = player.GetComponent<PlayerStatus>();
        partyTree = GameObject.FindGameObjectWithTag("PartyTree");
        partyTreeAnim = partyTree.GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        woodSprite = GameObject.FindGameObjectWithTag("Wood2").GetComponent<SpriteRenderer>();
        woodFadeIn = false;
	}
	
    void OnMouseDown()
    {
        if ((partyTree.transform.position - player.transform.position).magnitude < 2.0)
        {
            audio.mute = true;
            woodFadeIn = true;
            startTime = Time.time;
            GetComponent<PolygonCollider2D>().enabled = false;
            partyTreeAnim.enabled = false;
        }
    }

    void Update()
    {
        if (woodFadeIn)
        {
            float t = (Time.time - startTime) / 1f;
            if(woodSprite != null)
                woodSprite.color = new Color(1f, 1f, 1f, Mathf.SmoothStep(0f, 1f, t));
        }
    }
}
