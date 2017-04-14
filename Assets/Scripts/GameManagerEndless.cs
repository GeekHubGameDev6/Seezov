using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerEndless : MonoBehaviour {

    public GameObject[] KubePrefabs;
    private GameObject _ball;
    public static int NumberOfBricks;
    public static bool Launch = false;
    public static bool StartTimer;
    public float Countdown;

    public Text TimeForLevelText;
    public static int Score;
    public Text ScoreText;
    public GameObject EndgamePanel;

    private bool[][] _pattern = new bool[7][];
    Vector3 _upperRightKube = new Vector3(-2.1f, 3.2f, 0f);
    Vector2 _spaceBetweenCubes = new Vector2(0.7f, 0.5f);

    // Use this for initialization
    void Start () {
        SecondPaddle.IsMultiplayer = false;
        Score = 0;
        NumberOfBricks = 0;
        Resume();
        LoadRandomLevel();
    }

    public void LaunchBall()
    {
        _ball = GameObject.Find("ballBlue(Clone)");
        _ball.GetComponent<Ball>().LaunchBall();
    }


    public void Pause()
    {
        Time.timeScale = 0f;
    }

	void Update ()
	{
	    if (StartTimer)
	    {
	        Countdown -= Time.deltaTime;
	    }
        // Restricting timer from 0 to +inf, excluding negative numbers
        Countdown = Mathf.Clamp(Countdown, 0f, Mathf.Infinity);
        // GUI Update
	    TimeForLevelText.text = string.Format("{0:00.00}",Countdown);
        ScoreText.text = "Score " + Score;
        // High Score Update
        if(Score > PlayerPrefs.GetInt("HighScore"))
            PlayerPrefs.SetInt("HighScore", Score);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    void LateUpdate()
    {
        // WIN LOSE CHECK
        if (NumberOfBricks == 0)
        {
            LoadRandomLevel();
            StartTimer = false;
        }
        else if (Countdown <= 0)
        {
            EndgamePanel.SetActive(true);
            Time.timeScale = 0f;
            StartTimer = false;
        }
    }

    public void LoadRandomLevel()
    {
        // Selecting block pattern
        Countdown = 240f;
        SelectRandomPattern();
        InitializeBlockPattern();
    }

    bool RandomBoolean()
    {
        return (Random.Range(0, 2) == 1);
    }

    void SelectRandomPattern()
    {
        _pattern[0] = new bool[7] { RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean() };
        _pattern[1] = new bool[7] { RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean() };
        _pattern[2] = new bool[7] { RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean() };
        _pattern[3] = new bool[7] { RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean() };
        _pattern[4] = new bool[7] { RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean() };
        _pattern[5] = new bool[7] { RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean() };
        _pattern[6] = new bool[7] { RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean(), RandomBoolean() };
    }

    void InitializeBlockPattern()
    {
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (_pattern[i][j])
                {
                    Vector3 kubePosition = new Vector3(_upperRightKube.x + _spaceBetweenCubes.x * i, _upperRightKube.y - _spaceBetweenCubes.y * j, 0);
                    Instantiate(KubePrefabs[Random.Range(0, 5)], kubePosition, Quaternion.identity);
                }
            }
        }
    }

}
