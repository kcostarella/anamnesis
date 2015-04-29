using UnityEngine;
using System.Collections;

public class GraphManager : MonoBehaviour {

    public ArrayList waypoints = new ArrayList();
	// Use this for initialization
	void Start () {
        foreach (Transform waypoint in transform)
        {
            addNode(waypoint.gameObject);
        }

        
	}

    public void addNode(GameObject waypoint)
    {
        GameObject currPoint = waypoint;
        waypoints.Add(currPoint);

        foreach (GameObject point in waypoints)
        {
            if (point != currPoint)
            {
                if (!Physics2D.Linecast(currPoint.transform.position, point.transform.position))
                {
                    Waypoint instNode = currPoint.GetComponent<Waypoint>();
                    Waypoint oldNode = point.GetComponent<Waypoint>();
                    oldNode.adjs.Add(currPoint, true);
                    instNode.adjs.Add(point, true);
                }
            }
        }
    }

    public void removeNode(GameObject waypointObject)
    {
        Waypoint waypoint = waypointObject.GetComponent<Waypoint>();
        bool removed = false;
        int count = 0;
        foreach (GameObject point in waypoint.adjs.Keys)
        {
            Waypoint adj = point.GetComponent<Waypoint>();
            bool removal = adj.adjs.Remove(waypointObject);
            if (count == 0)
            {
                removed = removal;
            }
            else
            {
                removed &= removal;
            }
            
        }
        waypoints.Remove(waypointObject);
        if (removed)
        {
            Destroy(waypointObject);
        }
        
    }
	// Update is called once per frame
	void Update () {
	
	}

    
}
