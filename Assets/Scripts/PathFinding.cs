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
	private Vector3 finalDestination;
	private bool moving;
	private Vector3 WorldPosition;
	private Vector3 nextDestination;
	private int pathLength;
	private int currentWaypointCount;
	private List<Waypoint> path;
	private Vector3 dest;
	private PlayerController playerController;
    private GameObject graphManagerObject;
    private GraphManager graphManager;
	private Camera gameCam;
    private PlayerStatus playerStatus;
	private bool start;
	private bool isMoveable;

	private float[] scaleCam;
	public float cameraScaleTime;
	public float scaleVelocity;


	// Use this for initialization
	void Awake() {
		playerController = player.GetComponent<PlayerController> ();
        playerStatus = player.GetComponent<PlayerStatus>();
		graphManagerObject = GameObject.FindGameObjectWithTag("GraphManager");
		graphManager = graphManagerObject.GetComponent<GraphManager>();
		gameCam = GameObject.FindGameObjectWithTag ("MainCamera").GetComponent<Camera> ();
		start = true;
		isMoveable = true;
		scaleCam = new float[2];
		scaleCam [0] = scaleCam [1] = gameCam.orthographicSize;

	}
	void Start () {
		GameObject start = Instantiate (waypointObject, (player.transform.position), Quaternion.identity) as GameObject;
		start.name = "Start";
		graphManager.addNode (start);

		Vector3 startWaypointPosition = GameObject.FindGameObjectWithTag ("StartWaypoint").transform.position;
		GameObject goal = Instantiate (waypointObject, startWaypointPosition, Quaternion.identity) as GameObject;
		goal.name = "Goal";
		graphManager.addNode (goal);

		generatePath (start, goal);
	}



	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("Fire1") && isMoveable) {
			WorldPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			WorldPosition = new Vector3 (WorldPosition.x, WorldPosition.y, 0.0f);

			GameObject goal = Instantiate (waypointObject, WorldPosition, Quaternion.identity) as GameObject;
			goal.name = "Goal";
			graphManager.addNode (goal);
			
			
			GameObject start = Instantiate (waypointObject, (player.transform.position), Quaternion.identity) as GameObject;
			start.name = "Start";
			graphManager.addNode (start);

			generatePath(start,goal);
		}
		if (moving) {
			SetUpMovement ();
			playerController.setAnimationBoolState ("Moving", true);
		} else {
			playerController.setAnimationBoolState ("Moving", false);

		}

		if (scaleCam[0] != scaleCam[1]) {
			ScaleCamera();
		}
	}

	public Vector3 getFinalDestination() {
		return finalDestination;
	}

	public void setFinalDestination(Vector3 dest) {
		finalDestination = dest;
	}

	public void setFreeToMove(bool value) {
		isMoveable = value;
		if (!isMoveable) {
			moving = false;
		}
	}

	public bool getFreeToMove() {
		return isMoveable;
	}

	public void setScaleCamArray(int index, float val) {
		scaleCam [index] = val;
	}
	void ScaleCamera() {
		float newCameraScale = Mathf.SmoothDamp (scaleCam [0], scaleCam [1], ref scaleVelocity, cameraScaleTime);
		gameCam.orthographicSize = scaleCam [0] = newCameraScale;
	}

	void generatePath(GameObject start, GameObject goal) {
		
		try {
			path = AStarPath (start.GetComponent<Waypoint> (), goal.GetComponent<Waypoint> ());
		} catch (KeyNotFoundException e) {
            Debug.Log(e.Message);
			path = new List<Waypoint>();
		}
		
		pathLength = path.Count;
		if (pathLength > 0) {
			moving = true;
			pathLength = path.Count;
			currentWaypointCount = 0;
			nextDestination = new Vector3 (path[currentWaypointCount].transform.position.x, path[currentWaypointCount].transform.position.y, 0.0f);
			Waypoint goalPoint =  path[pathLength - 1];
			finalDestination = new Vector3(goalPoint.transform.position.x, goalPoint.transform.position.y, 0.0f);
			
			double best = (double)Mathf.Infinity;
			Waypoint closestWaypoint = goalPoint;
			foreach (KeyValuePair <GameObject,bool> point in goalPoint.adjs) {
				if (point.Value && point.Key.name != "Start" && point.Key.name != "Goal") {
					double curr = manhattanDistance(point.Key.transform.position, goalPoint.transform.position);
					if (curr < best) {
						best = curr;
						closestWaypoint = point.Key.GetComponent<Waypoint>();
					}
				}
			}
			path[pathLength-1].setCameraScale(closestWaypoint.getCameraScale());
			path[pathLength-1].setLayer (closestWaypoint.getLayer ());
			if (closestWaypoint.getEventObject() != null) {
				path[pathLength-1].setEventObject(closestWaypoint.getEventObject());
			}
		}

	}

	void SetUpMovement() {
		step = speed * Time.deltaTime;
		if (start == true) {
			player.transform.position = awakePosition;
			start = false;
		}

		if (nextDestination.x > player.transform.position.x) {
			player.transform.eulerAngles = new Vector3 (0.0f,0.0f,0.0f);
		} else {
			player.transform.eulerAngles = new Vector3 (0.0f,180.0f,0.0f);
		}

		Vector3 stepDist3 = Vector3.MoveTowards(player.transform.position, nextDestination, step);
		stepDist = new Vector2(stepDist3.x, stepDist3.y);
	}
	
	void FixedUpdate () {

		if (moving) {
			player.transform.position = new Vector3(stepDist.x, stepDist.y, 0.0f);
		}

		if (new Vector2 (player.transform.position.x, player.transform.position.y) == new Vector2 (finalDestination.x, finalDestination.y)) {
			moving = false;
			playerController.setAnimationBoolState("Moving",false);
		} else if (new Vector2 (player.transform.position.x, player.transform.position.y) == new Vector2 (nextDestination.x, nextDestination.y)) {
			if (currentWaypointCount < pathLength && path[currentWaypointCount].getEventObject() != null) {
				EventController thisEvent = path[currentWaypointCount].getEventObject().GetComponent<EventController>();
				thisEvent.StartEvent(thisEvent.eventName);
			}
			currentWaypointCount += 1;
			if (currentWaypointCount < pathLength) {
				nextDestination = new Vector3 (path[currentWaypointCount].transform.position.x, path[currentWaypointCount].transform.position.y, 0.0f);
				player.GetComponent<SpriteRenderer>().sortingOrder = path[currentWaypointCount].getLayer ();
				if (path[currentWaypointCount].getCameraScale() != scaleCam[1]) {
					scaleCam[1] = path[currentWaypointCount].getCameraScale();
				}

			}
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
