using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerMultiplayer : MonoBehaviour {

    private GameObject _ball;

    public GameObject VictoryPanel;
    public Text WinnerText;
    public static int P1Lives;
    public Text P1LivesText;
    public static int P2Lives;
    public Text P2LivesText;
   

    // Use this for initialization
    void Start ()
    {
        Resume();
        SecondPaddle.IsMultiplayer = true;
        P1Lives = 5;
        P2Lives = 5;
    }
	
	// Update is called once per frame
	void Update () {
        // GUI Update
        P1LivesText.text = "Lives " + P1Lives;
        P2LivesText.text = "Lives " + P2Lives;
    }

    public void LaunchBall()
    {
        _ball = GameObject.Find("ballBlue(Clone)");
        _ball.GetComponent<Ball>().LaunchBall();
    }

    public void Restart()
    {
        Resume();
        P1Lives = 5;
        P2Lives = 5;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    void LateUpdate()
    {
        // WIN LOSE CHECK
        if (P2Lives == 0)
        {
            VictoryPanel.SetActive(true);
            WinnerText.text = "Player 1 won";
            Time.timeScale = 0f;
        }
        if (P1Lives == 0)
        {
            VictoryPanel.SetActive(true);
            WinnerText.text = "Player 2 won";
            Time.timeScale = 0f;
        }
    }
}
