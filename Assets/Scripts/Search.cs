using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Algorithms;


public class Search : MonoBehaviour {
	int count = 0;
	BinaryHeap<Waypoint> fringe;
	HashSet<Waypoint> seen;
	
	
	public Waypoint search(Waypoint startstate)
	{
		fringe = new BinaryHeap<Waypoint>(6, new Comparison<Waypoint>(MinCompare));
		HashSet<Waypoint> seen = new HashSet<Waypoint> ();
		Waypoint currentState;
		Waypoint[] sucessorStates;
		while (fringe.Size > 0) {
			
			currentState = fringe.Pop();
			
			if (GoalTest(currentState)) {
				return currentState;
			}
			
			seen.Add(currentState);
			
			sucessorStates = NextStates (currentState);
			foreach (Waypoint sucessor in sucessorStates){
				if (!seen.Contains(sucessor)) {
					fringe.Insert(sucessor);
				}
			}
			
		}
		return default(Waypoint);
		
	}
	
	
	
	public Waypoint[] NextStates(Waypoint state) 
	{
		return default(Waypoint[]);
	}
	
	public bool GoalTest(Waypoint state1)
	{
		return false;
	}
	
	static int MinCompare(Waypoint i1, Waypoint i2)
	{
		return i1.Compare (i2);
	}
	
	
	static float ManhattanDistance(Vector2 v1, Vector2 v2) {
		return Mathf.Abs(v1.x - v2.x) + Mathf.Abs (v1.y - v2.y);
	}
	
	
	
}