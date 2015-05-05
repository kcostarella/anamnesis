using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Waypoint : MonoBehaviour {
    
    public Dictionary<GameObject, bool> adjs = new Dictionary<GameObject, bool>();
    private float rad = 0.25f;
	public GameObject eventTrigger;
	public float cameraScale;
	public int layer;

    void Awake()
    {

    }
	// Use this for initialization
	void Start () {
		if (Mathf.Approximately(cameraScale, 0.0f)) {
			cameraScale = 4.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void setCameraScale(float newScale) {
		cameraScale = newScale;
	}

	public void setEventObject(GameObject o) {
		eventTrigger = o;
	}

	public void setLayer(int l) {
		layer = l;
	}

	public float getCameraScale() {
		return cameraScale;
	}

	public int getLayer() {
		return layer;
	}

	public GameObject getEventObject() {
		return eventTrigger;
	}

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
		Vector3 pos = transform.localPosition;
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

    /// <summary>
    /// The Priority to insert this node at.  Must be set BEFORE adding a node to the queue
    /// </summary>
    public double Priority
    {
        get;
        set;
    }

    /// <summary>
    /// <b>Used by the priority queue - do not edit this value.</b>
    /// Represents the order the node was inserted in
    /// </summary>
    public long InsertionIndex { get; set; }

    /// <summary>
    /// <b>Used by the priority queue - do not edit this value.</b>
    /// Represents the current position in the queue
    /// </summary>
    public int QueueIndex { get; set; }

}
