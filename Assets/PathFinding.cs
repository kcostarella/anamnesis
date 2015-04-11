using UnityEngine;
using System.Collections;

public class PathFinding : MonoBehaviour {
	private Vector2 bestCoordinate;
	private Collider2D hitCollider;
	private GameObject player;
	private Algorithms.HitPackage hitPackage;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		player.transform.position = Algorithms.GetClosestVector (player.transform.position).bestCoordinate;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			Vector3 ScreenPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 mousePosition = new Vector2 (ScreenPosition.x, ScreenPosition.y);
			hitPackage = Algorithms.GetClosestVector (mousePosition);
			bestCoordinate = hitPackage.bestCoordinate;
			hitCollider = hitPackage.collider;

			if (!Mathf.Approximately (bestCoordinate.x, 99999.0f)) {
				player.transform.position = bestCoordinate;
				if (hitCollider.gameObject.layer == 9) {
						player.transform.localScale = new Vector3 (0.25f, 0.25f, 1.0f);
				} else {
					player.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
				}
			}
		}
	}

	float ManhattanDistance(Vector2 v1, Vector2 v2) {
		return Mathf.Abs(v1.x - v2.x) + Mathf.Abs (v1.y - v2.y);
	}
}
