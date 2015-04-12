﻿using UnityEngine;
using System.Collections;

public class PathFinding : MonoBehaviour {
	public float speed;
	public Vector2 velocity;

	private float step;
	private Vector2 stepDist;

	private Vector2 mousePosition;
	private GameObject player;
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
		}
	}

	void FixedUpdate () {

		if (moving) {
			player.GetComponent<Rigidbody2D>().MovePosition(stepDist);
		}

		if (new Vector2 (player.transform.position.x, player.transform.position.y) == mousePosition && moving) {
			moving = false;
		}
	}
	
	float ManhattanDistance(Vector2 v1, Vector2 v2) {
		return Mathf.Abs(v1.x - v2.x) + Mathf.Abs (v1.y - v2.y);
	}
}
