using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Score : MonoBehaviour {

    private float timeLeft = 500;
    public int playerScore = 0;
    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
	
    void Start () {
        //Just for testing
        Data_Management.dataManagement.LoadData();
    }

	void Update () {
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + (int)timeLeft);
        playerScoreUI.gameObject.GetComponent<Text>().text = ("Score: " + playerScore);
        if (timeLeft < 0.1f) {
            SceneManager.LoadScene ("GD_Arena_Level_6");
        } 
    }

    void OnTriggerEnter (Collider trig) {
        if (trig.gameObject.name == "End_Level") {
            CountScore();
        }
        if (trig.gameObject.name == "Pickup")
        {
            playerScore += 10;
                    
        }
        if (trig.gameObject.name == "Floppy")
        {
            playerScore += 50;

        }
    }

    void CountScore () {
        Debug.Log("Data says high score is currently" + Data_Management.dataManagement.highScore);
        playerScore = playerScore + (int)(timeLeft * 10);
        Data_Management.dataManagement.highScore = playerScore + (int)(timeLeft * 10);
        Data_Management.dataManagement.SaveData();
        Debug.Log(message: "Now that we have added the score to Data_Management, data says high score is currently" + Data_Management.dataManagement.highScore);
    }
}
