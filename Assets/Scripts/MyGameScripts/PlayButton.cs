using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {
    public Button play;
    public Text nameInputFieldText;
    // Use this for initialization
    void Start () {
        play = play.GetComponent<Button>();
        play.onClick.AddListener(PlayScene);
	}
    void PlayScene() {
        PlayerPrefs.SetString("currentPlayer", nameInputFieldText.text);
        SceneManager.LoadScene("MyGame", LoadSceneMode.Single);
    }
}
