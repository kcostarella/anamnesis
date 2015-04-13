using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(GraphManager))]
public class GraphCreation : Editor {

    private static bool graphing = false;
    private static GameObject gm = null;
    //public static ArrayList waypoints = new ArrayList();
    public static ArrayList waypoints;

    [MenuItem("Graphing Tools/Toggle Graphing %#g")]
    private static void ToggleGraphing()
    {
        Debug.ClearDeveloperConsole();
        graphing = !graphing;
        if (graphing == true)
        {
            if (gm == null)
            gm = GameObject.FindGameObjectWithTag("GraphManager");
            Selection.activeObject = gm;
            waypoints = gm.GetComponent<GraphManager>().waypoints;
        }
        Debug.Log("Graphing state: " + graphing);
    }

    [MenuItem("Graphing Tools/Clear Waypoints")]
    private static void ClearWaypoints()
    {
        foreach (GameObject g in waypoints)
        {
            DestroyImmediate(g);
        }
        waypoints.Clear();
    }

    [MenuItem("Graphing Tools/Connect Graph")]
    private static void ConnectGraph()
    {

    }
    void OnSceneGUI()
    {
        if (graphing)
        {
            if (Event.current.type == EventType.mouseDown)
            {
                Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                RaycastHit hitInfo;

                if (!Physics.Raycast(ray, out hitInfo))
                {
                    GameObject waypoint = Resources.LoadAssetAtPath("Assets/Prefabs/Waypoint.prefab", typeof(GameObject)) as GameObject;
                    GameObject waypointInstance = Instantiate(waypoint) as GameObject;
                    waypointInstance.transform.position = ray.origin;
                    waypointInstance.transform.parent = gm.transform;

                    waypoints.Add(waypointInstance);

                    foreach (GameObject wp in waypoints)
                    {
                        if (wp != waypointInstance)
                        {
                            if (!Physics2D.Linecast(waypointInstance.transform.position, wp.transform.position))
                            {
                                Waypoint instNode = waypointInstance.GetComponent<Waypoint>();
                                Waypoint oldNode = wp.GetComponent<Waypoint>();
                                oldNode.adjs.Add(waypointInstance, true);
                                instNode.adjs.Add(wp, true);
                            }
                        }
                    }
                }
            }
            Selection.activeObject = gm;
        }
    }
}
