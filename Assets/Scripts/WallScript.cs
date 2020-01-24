using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallScript : MonoBehaviour {

	public GameObject game;

	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(-8f, 0);
		game = GameObject.Find("Game");
	}

	void Update () {
		
		if (transform.position.x < -3.2f) {
			Destroy(gameObject);
			GameScript.score++;
		}
	}
	
	void OnTriggerEnter2D (Collider2D col) {
		game.GetComponent<GameScript>().GameOver();
	}
}
