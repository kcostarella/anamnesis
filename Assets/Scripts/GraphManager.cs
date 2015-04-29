using UnityEngine;
using System.Collections;

public class GraphManager : MonoBehaviour {

    public ArrayList waypoints = new ArrayList();
	// Use this for initialization
	void Start () {
        foreach (Transform waypoint in transform)
        {
            AddNode(waypoint.gameObject);
        }

        
	}

    void AddNode(GameObject waypoint)
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

	// Update is called once per frame
	void Update () {
	
	}

    
}
