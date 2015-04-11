using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoint : MonoBehaviour {

    public Vector3 pos;
    public List<GameObject> adjs;
    private float rad = 0.25f;
    void Awake()
    {
        pos = transform.localPosition;
    }
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(pos, rad);
        foreach(GameObject point in adjs) {
            Gizmos.DrawLine(pos, point.transform.position);
        }
        
    }
}
