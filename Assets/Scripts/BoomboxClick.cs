using UnityEngine;
using System.Collections;

public class BoomboxClick : MonoBehaviour {
    
    GameObject player;
    GameObject partyTree;
    AudioSource audioSource;
    SpriteRenderer woodSprite;
    Animator partyTreeAnim;
    bool woodFadeIn;
    private float startTime;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        partyTree = GameObject.FindGameObjectWithTag("PartyTree");
        partyTreeAnim = partyTree.GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
        woodSprite = GameObject.FindGameObjectWithTag("Wood2").GetComponent<SpriteRenderer>();
        woodFadeIn = false;
	}
	
    void OnMouseDown()
    {
        if ((partyTree.transform.position - player.transform.position).magnitude < 5.0)
        {
            audioSource.mute = true;
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
