using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MyGameScript : MonoBehaviour {
    public Rigidbody2D player; //the player, usng velocity an physics 
    public GameObject isOnGroundCheck; //checking if it is on the ground
    public Text notify; //just the dusplay text for which key to press
    public Text score; //the score of the player, TEXT
    int jScore; //the score of the player, the int

    bool grounded; //is the player groudned 
    public int jumpSwitch; //the number used in the big switch case below
    float jumpSwitchTimer; //random interval at the start to determine when to invoke the jump key change 

    string mainKey; //check the input to the correct jump key
    //string of all possible jump keys for debugging 
    string[] jumpKeys; //array of known possible jump keys
    bool correctJumpKey; //does the button pressed match the curr jump button

    bool jumpHeld; //jump key held
    //Physics stuffs
    float jumpForce; // the force to use for jumping
    float stJumpForce;
    float maxJumpForce;
    Vector2 counterJF;
    // Use this for initialization
    void Start () {

        jumpForce = 5f;
        jumpSwitchTimer = Random.Range(0.1f, 5f);
        Invoke("JumpSwitcheroo", jumpSwitchTimer);

        Debug.Log("Begin Invoke");
        grounded = false;

        jumpKeys = new string[] {"Q", "A", "Z", "P", "L",
                                 "M", "T", "G", "B", "U",
                                 "I", "J", "E", "D"};

        counterJF = new Vector2(0f, -40f);
        jScore = 0;
    }


    void JumpSwitcheroo() {
        CancelInvoke();
        //everytime this is invoked, notify the player then switch the jump key
        jumpSwitch = Random.Range(0, 13);
        notify.text = "KEY SWITCH";
        float newTim = Random.Range(2f, 15f);
        Invoke("JumpSwitcheroo", newTim);
        //Debug.Log(newTim);

    }
	
	// Update is called once per frame
	void Update () {
        jumpForce = CalcJumpForce(Physics2D.gravity.magnitude, 5.0f);
        
        //player.velocity = new Vector2(5.3f, player.velocity.y);
        //Raycasting from the first lab!
        RaycastHit2D hitInfo = Physics2D.Linecast(player.transform.position, isOnGroundCheck.transform.position);

           if (hitInfo.collider != null) {
               grounded = true;
               Debug.Log (grounded);
            //only be able to jump IF they are on the ground
                switch (jumpSwitch) {
                case 0: 
                    if (Input.GetKeyDown (KeyCode.Q)) {
                        PlayerJump();
                      // player.AddForce (new Vector2 (0, jumpForce));
                        Debug.Log("Q");
                    }
                    Jumpkey("Q");
                    break;
                case 1: 
                    if (Input.GetKeyDown (KeyCode.A)) {
                        PlayerJump();
                        //player.AddForce (new Vector2 (0, jumpForce));
                        Debug.Log("A");
                    }
                    Jumpkey("A");
                    break;
                case 2: 
                    if (Input.GetKeyDown (KeyCode.Z)) {
                        PlayerJump();
                        //player.AddForce (new Vector2 (0, jumpForce));
                        Debug.Log("Z");
                    }
                    Jumpkey("Z");
                    break;
                case 3: 
                    if (Input.GetKeyDown (KeyCode.P)) {
                        PlayerJump();
                        //player.AddForce (new Vector2 (0, jumpForce));
                        Debug.Log("P");
                    }
                    Jumpkey("P");
                    break;
                case 4: 
                    if (Input.GetKeyDown (KeyCode.L)) {
                        PlayerJump();
                        Debug.Log("L");
                    }
                    Jumpkey("L");
                    break;
                case 5: 
                    if (Input.GetKeyDown (KeyCode.M)) {
                        PlayerJump();
                        Debug.Log("M");
                    }
                    Jumpkey("M");
                    break;
                case 6: 
                    if (Input.GetKeyDown (KeyCode.T)) {
                        PlayerJump();
                        Debug.Log("T");
                    }
                    Jumpkey("T");
                    break;
                case 7: 
                    if (Input.GetKeyDown (KeyCode.G)) {
                        PlayerJump();
                        Debug.Log("G");
                    }
                    Jumpkey("G");
                    break;
                case 8: 
                    if (Input.GetKeyDown (KeyCode.B)) {
                        PlayerJump();
                        Debug.Log("B");
                    }
                    Jumpkey("B");
                    break;
                case 9: 
                    if (Input.GetKeyDown (KeyCode.U)) {
                        PlayerJump();
                        Debug.Log("U");
                    }
                    Jumpkey("U");
                    break;
                case 10: 
                    if (Input.GetKeyDown (KeyCode.I)) {
                        PlayerJump();
                        Debug.Log("I");
                    }
                    Jumpkey("I");
                    break;
                case 11: 
                    if (Input.GetKeyDown (KeyCode.J)) {
                        PlayerJump();
                        Debug.Log("J");
                    }
                    Jumpkey("J");
                    break;
                case 12: 
                    if (Input.GetKeyDown (KeyCode.E)) {
                        PlayerJump();
                        Debug.Log("E");
                    }
                    Jumpkey("E");
                    break;
                case 13: 
                    if (Input.GetKeyDown (KeyCode.D)) {
                        PlayerJump();
                        Debug.Log("D");
                    }
                    Jumpkey("D");
                    break;
           }
            jumpHeld = true;
           }
           else {
               grounded = false;
               Debug.Log(grounded);
            
        }
        //Raycasting
        //KeyCheck();
        if (Input.GetKeyDown (KeyCode.Q)) {
            KeyCheck("Q");
        }
        if (Input.GetKeyDown (KeyCode.A)) {
            KeyCheck("A");
        }
        if (Input.GetKeyDown (KeyCode.Z)) {
            KeyCheck("Z");
        }
        if (Input.GetKeyDown (KeyCode.P)) {
            KeyCheck("P");
        }
        if (Input.GetKeyDown (KeyCode.L)) {
            KeyCheck("L");
        }
        if (Input.GetKeyDown (KeyCode.M)) {
            KeyCheck("M");
        }
        if (Input.GetKeyDown (KeyCode.T)) {
            KeyCheck("T");
        }
        if (Input.GetKeyDown (KeyCode.G)) {
            KeyCheck("G");
        }
        if (Input.GetKeyDown (KeyCode.B)) {
            KeyCheck("B");
        }
        if (Input.GetKeyDown (KeyCode.U)) {
            KeyCheck("U");
        }
        if (Input.GetKeyDown (KeyCode.I)) {
            KeyCheck("I");
        }
        if (Input.GetKeyDown (KeyCode.J)) {
            KeyCheck("J");
        }
        if (Input.GetKeyDown (KeyCode.E)) {
            KeyCheck("E");
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            KeyCheck("D");
        }
        else {
            jumpHeld = false;
        }


        //Debug.Log("JSWITCHH "+jumpSwitch);
        //notify.text = "you good...";
    } //end update 
    /***
     *FIXED UPDATE 
     *  take care of the physics for jumping 
     * 
     */
    private void FixedUpdate() {
        if (grounded == false) { //player is jumping 
            if (!jumpHeld && Vector2.Dot(player.velocity, Vector2.up) > 0) {
                player.AddForce( counterJF * player.mass);
            }
        }
        
    }

    void Jumpkey(string letter) {
        
        notify.text = letter;

        mainKey = letter; //this is the current JUMP KEY
        //KeyCheck();
    }

    // Key Detection
    void KeyCheck(string pressedKey) {

        if (pressedKey == mainKey) {
            correctJumpKey = true;
            Debug.Log("Correct!! " + pressedKey + " " + correctJumpKey);
            jScore++;
            score.text = "Score: " + jScore;
            Debug.Log(score);
        }
        else {
            correctJumpKey = false;
            Debug.Log("WRONG " + pressedKey + " " + correctJumpKey);
            //GAME OVER
            GameOver();
        }
    }

    public void GameOver() {
		SceneManager.LoadScene("MyTitle");
        StartCoroutine(UpLoadHighScore(PlayerPrefs.GetString("currentPlayer"), jScore));    
    }

    //http://dreamlo.com/lb/y1d8oGXu3ku0-3NlApdb_wfl7zeyq-4kCfDXQx_zTRog link
    //http://dreamlo.com/lb/5a94d2e839992d09e4ee1882/xml get high scores thing

    IEnumerator UpLoadHighScore(string username, int score) {
        //send the score to the server
        string privateCode = "y1d8oGXu3ku0-3NlApdb_wfl7zeyq-4kCfDXQx_zTRog";
        string webURL = "http://dreamlo.com/lb/";

        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username)+ "/" + score);
        yield return www;

        if (www.error == null || www.error == "") {
            Debug.Log("Successful");
        }
        else {
            Debug.Log("ERROR");
        }

    }

    void PlayerJump() {
        //make the player jump higher depending on how long the button is held,
        //set a limit
        player.AddForce(Vector2.up * jumpForce * player.mass, ForceMode2D.Impulse);
    }

    //Math calculation for jump force
    public static float CalcJumpForce(float gravSt, float height) {
        return Mathf.Sqrt(2 * gravSt * height);
    }



}

