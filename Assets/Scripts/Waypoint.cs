using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoint : MonoBehaviour {

    public Vector3 pos;
    public List<Waypoint> adjs;
    private float rad = 0.25f;
    void Awake()
    {
        
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
		pos = transform.localPosition;
        Gizmos.DrawWireSphere(pos, rad);
        foreach(Waypoint point in adjs) {
            Gizmos.DrawLine(pos, point.transform.position);
			if (!point.adjs.Contains(this)) {
				point.adjs.Add(this);
			}
        }
    }
}
