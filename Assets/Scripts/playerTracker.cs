using UnityEngine;
using System.Collections;

public class playerTracker : MonoBehaviour {
	public Transform playerTransform;
	private const float mapx = 51f;
	private const float mapy = 40.52f;
	private Camera cam;

	// Use this for initialization
	void Start () {
		gameObject.transform.position = new Vector3 (playerTransform.position.x, playerTransform.position.y, gameObject.transform.position.z);
		cam = gameObject.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		float vertExtent = cam.orthographicSize;
		float horzExtent = vertExtent * Screen.width / Screen.height;
		float xMin = horzExtent - mapx / 2.0f;
		float xMax = mapx / 2.0f - horzExtent;
		float yMin = vertExtent - mapy / 2.0f;
		float yMax = mapy / 2.0f - vertExtent;

		gameObject.transform.position = new Vector3 (Mathf.Clamp(playerTransform.position.x,xMin, xMax), 
		                                             Mathf.Clamp (playerTransform.position.y,yMin,yMax), 
		                                             gameObject.transform.position.z);

	}
}
