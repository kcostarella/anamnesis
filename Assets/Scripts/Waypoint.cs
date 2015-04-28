using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoint : MonoBehaviour {

    public Vector3 pos;
    public Dictionary<GameObject, bool> adjs = new Dictionary<GameObject, bool>();
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

        if (adjs.Keys.Count != 0)
        {
            foreach (GameObject point in adjs.Keys)
            {
                Gizmos.DrawLine(pos, point.transform.position);
            }
        }
    }

	public int Compare(Waypoint other) {
		return 1;
	}
}
