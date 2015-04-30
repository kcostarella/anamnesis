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
            if (gm != null)
            {
                Selection.activeObject = gm;
                //waypoints = gm.GetComponent<GraphManager>().waypoints;
            }
        }
        Debug.Log("Graphing state: " + graphing);
    }

    [MenuItem("Graphing Tools/Clear Waypoints")]
    private void ClearWaypoints()
    {
        GraphManager manager = (GraphManager)target;

        foreach (GameObject g in manager.waypoints)
        {
            DestroyImmediate(g);
        }
        gm.GetComponent<GraphManager>().waypoints.Clear();
    }

    [MenuItem("Graphing Tools/Connect Graph")]
    private static void ConnectGraph()
    {

    }
    void OnSceneGUI()
    {
        GraphManager manager = (GraphManager)target;
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
                    waypointInstance.name = "Waypoint" + (manager.waypoints.Count + 1);
                    waypointInstance.transform.position = new Vector3(ray.origin.x, ray.origin.y);
                    waypointInstance.transform.parent = gm.transform;

                    manager.waypoints.Add(waypointInstance);

                    foreach (GameObject wp in manager.waypoints)
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

    public override void OnInspectorGUI()
    {
        GraphManager manager = (GraphManager)target;

        EditorGUILayout.LabelField("Size", manager.waypoints.Count.ToString());

        foreach (GameObject point in manager.waypoints)
        {
            EditorGUILayout.LabelField("Point", point.name);
        }
    }

}
