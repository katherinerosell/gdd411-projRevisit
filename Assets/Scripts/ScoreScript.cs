using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

	static public void RegisterScore(int newScore) {

		// set score for last play
		PlayerPrefs.SetInt("Last Score", newScore);

		// if new high
		if (newScore > PlayerPrefs.GetInt("High Score")) {

			// set new high name and score
			PlayerPrefs.SetString("High Name", PlayerPrefs.GetString("Last Name"));
			PlayerPrefs.SetInt("High Score", newScore);
		}
	}
}
