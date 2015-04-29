using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor(typeof(Waypoint))]
public class WaypointEditor : Editor {

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Waypoint currPoint = (Waypoint)target;
        Dictionary<GameObject, bool> currAdjs = currPoint.adjs;

        EditorGUILayout.LabelField("Size", currAdjs.Count.ToString());

        foreach (GameObject point in currAdjs.Keys)
        {
            if (currAdjs[point])
            {
                EditorGUILayout.LabelField("Neighbor", point.name);
            }
        }
    }
}
