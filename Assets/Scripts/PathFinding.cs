using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathFinding : MonoBehaviour {
	public float speed;
	public Vector2 velocity;
	public GameObject waypointObject;
	public Vector3 awakePosition;
	public Vector2 startPosition;
	public GameObject player;

	private float step;
	private Vector2 stepDist;
	private Vector2 mousePosition;
	private bool moving;
	private Vector3 WorldPosition;
	private Vector3 dest;
	private PlayerController playerController;
    private GameObject graphManagerObject;
    private GraphManager graphManager;
	private bool start;


	// Use this for initialization
	void Awake() {
		playerController = player.GetComponent<PlayerController> ();
		graphManagerObject = GameObject.FindGameObjectWithTag("GraphManager");
		graphManager = graphManagerObject.GetComponent<GraphManager>();
	}
	void Start () {

		WorldPosition = new Vector3 (startPosition.x, startPosition.y, 0.0f);
		mousePosition = new Vector2 (WorldPosition.x, WorldPosition.y);
		moving = true;
		start = true;
	}



	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1")) {
			WorldPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			WorldPosition = new Vector3(WorldPosition.x,WorldPosition.y, 0.0f);
            Debug.Log(waypointObject);

            GameObject goal = Instantiate(waypointObject, WorldPosition, Quaternion.identity) as GameObject;
            goal.name = "Goal";
            graphManager.addNode(goal);
            

            GameObject start = Instantiate(waypointObject, (player.transform.position + new Vector3(.14f, -.51f)), Quaternion.identity) as GameObject;
            start.name = "Start";
            graphManager.addNode(start);

            List<Waypoint> path = AStarPath(start.GetComponent<Waypoint>(), goal.GetComponent<Waypoint>());

            if (WorldPosition.x > player.transform.position.x) {
				player.transform.eulerAngles = new Vector3 (0.0f,0.0f,0.0f);
			} else {
                player.transform.eulerAngles = new Vector3 (0.0f,180.0f,0.0f);
			}
			mousePosition = new Vector2 (WorldPosition.x, WorldPosition.y);
			moving = true;

		}

		if (moving) {
			step = speed * Time.deltaTime;
			if (start == true) {
				player.transform.position = awakePosition;
				start = false;
			}
			Vector3 stepDist3 = Vector3.MoveTowards(player.transform.position, WorldPosition, step);
			stepDist = new Vector2(stepDist3.x, stepDist3.y);
		}
	}

	void FixedUpdate () {

		if (moving) {
			//player.GetComponent<Rigidbody2D>().MovePosition(stepDist);
			player.transform.position = new Vector3(stepDist.x, stepDist.y, 0.0f);
			playerController.setAnimationBoolState("Moving",true);
		}

		if (new Vector2 (player.transform.position.x, player.transform.position.y) == mousePosition && moving) {
			moving = false;
			playerController.setAnimationBoolState("Moving",false);
		}
	}

    private double manhattanDistance(Vector3 v1, Vector3 v2)
    {
        return Mathf.Abs(v1.x - v2.x) + Mathf.Abs(v1.y - v2.y);
    }

    List<Waypoint> AStarPath(Waypoint start, Waypoint goal)
    {
        Priority_Queue.HeapPriorityQueue<Waypoint> frontier = new Priority_Queue.HeapPriorityQueue<Waypoint>(graphManager.waypoints.Count + 10);
        frontier.Enqueue(start, 0);
        Dictionary<Waypoint, Waypoint> cameFrom = new Dictionary<Waypoint, Waypoint>();
        Dictionary<Waypoint, double> costSoFar = new Dictionary<Waypoint, double>();
        cameFrom[start] = null;
        costSoFar[start] = 0;

        while (frontier.Count > 0)
        {
            Waypoint curr = frontier.Dequeue();

            if (curr == goal)
            {
                break;
            }

            foreach (GameObject nextObject in curr.adjs.Keys)
            {
                Waypoint next = nextObject.GetComponent<Waypoint>();
                double newCost = costSoFar[curr];

                if (!costSoFar.ContainsKey(next) || newCost < costSoFar[next])
                {
                    costSoFar[next] = newCost;
                    frontier.Enqueue(next, (newCost + manhattanDistance(curr.transform.localPosition, next.transform.localPosition)));
                    cameFrom[next] = curr;
                }
            }
        }

        List<Waypoint> finalPath = new List<Waypoint>();
        Waypoint currPoint = goal;
        finalPath.Insert(0, currPoint);

        while (currPoint != start)
        {
            currPoint = cameFrom[currPoint];
            if (currPoint != null)
            {
                finalPath.Insert(0, currPoint);
            }
        }

        return finalPath;
    }
}
