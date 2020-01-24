using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuyScript : MonoBehaviour {

	Vector2 homePos;
	public float distToMove;

	// Use this for initialization
	void Start () {
		homePos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.UpArrow) && Input.GetKey(KeyCode.DownArrow)) {
			transform.position = new Vector2(homePos.x, homePos.y + distToMove);
		}
		else {

			float justDistanceToMove = Mathf.Abs(distToMove);

			if (Input.GetKey(KeyCode.UpArrow)) {
				transform.position = new Vector2(homePos.x, homePos.y + justDistanceToMove);
			}
			else if (Input.GetKey(KeyCode.DownArrow)) {
				transform.position = new Vector2(homePos.x, homePos.y - justDistanceToMove);
			}
			else {
				transform.position = homePos;
			}
		}
		
	}
}
