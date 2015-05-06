using UnityEngine;
using System.Collections;

public class playerTracker : MonoBehaviour {
	public Transform playerTransform;
	public float mapx;
	public float mapy;

	private PathFinding pathFinding;
	private PlayerStatus playerStatus;
	private Camera cam;
	private Vector3 scaleVelocity;
	private float cameraScaleTime;
	private Vector3 currentDestination;
	private Vector3 newDestination;

	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector3 (playerTransform.position.x, playerTransform.position.y, gameObject.transform.position.z);
		cam = gameObject.GetComponent<Camera> ();
		pathFinding = GameObject.FindGameObjectWithTag ("Path").GetComponent<PathFinding> ();
		playerStatus = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStatus>();
		cameraScaleTime = 0.50f;
		scaleVelocity = new Vector3 (0.0f, 0.0f, 0.0f);
		currentDestination = new Vector3 (Mathf.Infinity, Mathf.Infinity, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
		float vertExtent = cam.orthographicSize;
		float horzExtent = vertExtent * Screen.width / Screen.height;
		float xMin = horzExtent - mapx / 2.0f;
		float xMax = mapx / 2.0f - horzExtent;
		float yMin = vertExtent - mapy / 2.0f;
		float yMax = mapy / 2.0f - vertExtent;
		Vector3 newDestination = pathFinding.getFinalDestination ();
		if (newDestination != currentDestination) {
			currentDestination = newDestination;
		}
		if (playerStatus.shyTreeActive) {
			currentDestination += new Vector3(-3.0f, 0.0f, 0.0f);
		}
		Vector3 step = Vector3.SmoothDamp (gameObject.transform.position, currentDestination, ref scaleVelocity, cameraScaleTime);
		gameObject.transform.position = new Vector3 (Mathf.Clamp (step.x, xMin, xMax), Mathf.Clamp (step.y, yMin, yMax), gameObject.transform.position.z);
	}
}
