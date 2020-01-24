using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScript : MonoBehaviour {

	public GameObject guyUp;
	public GameObject guyDown;
	public GameObject wallPrefab;
	public GameObject wallsPrefab;
	float timeCounter;
	float nextWall;
	public static int score = 0; 

	// Use this for initialization
	void Start () {
		
		timeCounter = 0;

		// initial time until next wall is made
		nextWall = 1.0f;
	}

	// Update is called once per frame
	void Update () {

		// keep track of time passed since last wall
		timeCounter += Time.deltaTime;

		// make things get faster
		nextWall = nextWall - 0.001f;

		// next wall will get made after "nextWall" seconds
		if (timeCounter > nextWall) {
			MakeWall();
			timeCounter = 0;
		}

		// show values
		//Debug.Log("time:" + Time.timeSinceLevelLoad + ", nextWallIn: " + nextWall);

		if (Input.GetKey(KeyCode.DownArrow)) {
			guyDown.transform.position = new Vector2(-2.4f, -1.6f);
		}
		else {
			guyDown.transform.position = new Vector2(-2.4f, -0.12f);
		}
	}

	void MakeWall () {

		int randWall = Random.Range(0, 4);

		if (randWall == 0) {
			GameObject wall = Instantiate(wallPrefab);
			wall.transform.position = new Vector2(4, -1);

		}
		else if (randWall == 1) {
			GameObject wall = Instantiate(wallPrefab);
			wall.transform.position = new Vector2(4, 0);

		}
		else if (randWall == 2) {
			GameObject wall = Instantiate(wallPrefab);
			wall.transform.position = new Vector2(4, 1);
		}
		else if (randWall == 3) {
			GameObject walls = Instantiate(wallsPrefab);
			walls.transform.position = new Vector2(4, 0);
		}
	}

	public void GameOver() {
		SceneManager.LoadScene("Title");

        StartCoroutine(UpLoadHighScore("kmrosell", score));    
    }

    IEnumerator UpLoadHighScore(string username, int score) {
        //send the score to the server
        string privateCode = "put url link here";
        string webURL = "web url";

        WWW www = new WWW(webURL + privateCode + "/add/" + "kmrosell" + score);
        yield return www;

        if (www.error == null) {
            Debug.Log("Successful");
        }
        else {
            Debug.Log("ERROR");
        }

    }

}

