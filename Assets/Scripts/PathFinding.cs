using UnityEngine;
using System.Collections;

public class PathFinding : MonoBehaviour {
	public float speed;
	public Vector2 velocity;
	public Waypoint waypointObject;

	private float step;
	private Vector2 stepDist;
	private Vector2 mousePosition;
	private GameObject player;
	private bool moving;
	private Vector3 WorldPosition;
	private Vector3 dest;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		moving = false; 
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			WorldPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			WorldPosition = new Vector3(WorldPosition.x,WorldPosition.y, 0.0f);
			GameObject.Instantiate(waypointObject, WorldPosition, Quaternion.identity);


			if (WorldPosition.x > player.transform.position.x) {
				player.transform.eulerAngles = new Vector3 (0.0f,180.0f,0.0f);
			} else {
				player.transform.eulerAngles = new Vector3 (0.0f,0.0f,0.0f);

				}
			mousePosition = new Vector2 (WorldPosition.x, WorldPosition.y);
			moving = true;
		}

		if (moving) {
			step = speed * Time.deltaTime;
			Vector3 stepDist3 = Vector3.MoveTowards(player.transform.position, WorldPosition, step);
			stepDist = new Vector2(stepDist3.x, stepDist3.y);
		}
	}

	void FixedUpdate () {

		if (moving) {
			//player.GetComponent<Rigidbody2D>().MovePosition(stepDist);
			player.transform.position = new Vector3(stepDist.x, stepDist.y, 0.0f);
		}

		if (new Vector2 (player.transform.position.x, player.transform.position.y) == mousePosition && moving) {
			moving = false;
		}
	}
}