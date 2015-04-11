using UnityEngine;
using System.Collections;

public class PathFinding : MonoBehaviour {
	public float speed;
	public Vector2 velocity;

	private float step;
	private Vector2 stepDist;

	private Vector2 bestCoordinate;
	private Vector2 mousePosition;
	private Collider2D hitCollider;
	private GameObject player;
	private Vector2 direction;
	private Algorithms.HitPackage hitPackage;
	private bool moving;
	private Vector3 ScreenPosition;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		moving = false; 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			ScreenPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			ScreenPosition = new Vector3(ScreenPosition.x, ScreenPosition.y, 0.0f);
			mousePosition = new Vector2 (ScreenPosition.x, ScreenPosition.y);
			moving = true;
			print(ScreenPosition);
		}

		if (moving) {
			step = speed * Time.deltaTime;
			Vector3 stepDist3 = Vector3.MoveTowards(player.transform.position, ScreenPosition, step);
			stepDist = new Vector2(stepDist3.x, stepDist3.y);
			//player.transform.position = stepDist3;
		}
	}

	void FixedUpdate () {

		if (moving) {
			print ("Moving");
			player.GetComponent<Rigidbody2D>().MovePosition(stepDist);
		}

		if (new Vector2 (player.transform.position.x, player.transform.position.y) == mousePosition) {
			print ("stopping");
			moving = false;
		}
			
	}



			//hitPackage = Algorithms.GetClosestVector (mousePosition);
			//bestCoordinate = hitPackage.bestCoordinate;

			//hitCollider = hitPackage.collider;
			//if (!Mathf.Approximately (bestCoordinate.x, 99999.0f)) {
			//	player.transform.position = bestCoordinate;
			//	if (hitCollider.gameObject.layer == 9) {
			//			player.transform.localScale = new Vector3 (0.25f, 0.25f, 1.0f);
			//	} else {
			//		player.transform.localScale = new Vector3 (1.0f, 1.0f, 1.0f);
			//	}
			//}


	float ManhattanDistance(Vector2 v1, Vector2 v2) {
		return Mathf.Abs(v1.x - v2.x) + Mathf.Abs (v1.y - v2.y);
	}
}
