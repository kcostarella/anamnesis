using UnityEngine;
using System.Collections;

public class Algorithms : MonoBehaviour {
	static Vector2[] directions;
	// Use this for initialization
	void Awake () {
		directions = new Vector2[8]{Vector2.up, Vector2.right, -Vector2.up, -Vector2.right, Vector2.up + Vector2.right,
			Vector2.up - Vector2.right, -Vector2.up + Vector2.right, -Vector2.up - Vector2.right};
	}
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public static HitPackage GetClosestVector(Vector2 click)
	{
		HitPackage hitPackage = new HitPackage ();
		float bestDist = 99999.0f;
		hitPackage.bestCoordinate = new Vector2 (99999.0f, 99999.0f);
		Collider2D collider = hitPackage.collider;
		foreach (Vector2 direction in directions) {
			int mask = 1 << LayerMask.NameToLayer ("Player");
			mask = ~mask;
			RaycastHit2D hit = Physics2D.Raycast(click, direction,Mathf.Infinity,mask);
			if (hit.collider != null) {
				if (ManhattanDistance(click, hit.point) < bestDist) {
					bestDist = ManhattanDistance(click, hit.point);
					hitPackage.bestCoordinate = hit.point;
					hitPackage.collider = hit.collider;
				}
			} 
		}
		return (hitPackage);
	}
	public class HitPackage
	{
		public Vector2 bestCoordinate{ get; set; }
		public Collider2D collider{ get; set;}
	}

	public static float ManhattanDistance(Vector2 v1, Vector2 v2) {
		return Mathf.Abs(v1.x - v2.x) + Mathf.Abs (v1.y - v2.y);
	}
}
