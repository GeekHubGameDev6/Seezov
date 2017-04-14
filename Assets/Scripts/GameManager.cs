using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private GameObject _ball;
    public static int ActiveLevel;
    public GameObject KubePrefab;
    public static int NumberOfBricks;

    public GameObject VictoryPanel;
    public GameObject LosePanel;
    public static int Lives;
    public Text LivesText;
    public static int Score;
    public Text ScoreText;

    // 7 by 7 matrix
    private bool[][] _pattern = new bool[7][];
    Vector3 _upperRightKube = new Vector3(-2.1f,3.2f,0f);
    Vector2 _spaceBetweenCubes = new Vector2(0.7f,0.5f);

    void Start ()
    {
        SecondPaddle.IsMultiplayer = false;
        NumberOfBricks = 0;
        Lives = 3;
        Score = 0;
        LoadLevel();
    }
    
    void Update () {
        // GUI Update
        LivesText.text = "Lives " + Lives;
        ScoreText.text = "Score " + Score;
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

    public void Resume()
    {
        Time.timeScale = 1f;
    }

    void LateUpdate()
    {
        // WIN LOSE CHECK
        if (NumberOfBricks == 0 && !VictoryPanel.activeInHierarchy)
        {
            VictoryPanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (Lives == 0)
        {
            LosePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void LoadLevel()
    {
        // Selecting block pattern
        Resume();

        if (VictoryPanel.activeInHierarchy)
        {
            ActiveLevel++;
            Lives = 3;
        }
        SelectPattern();
        InitializeBlockPattern();
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
                    Instantiate(KubePrefab, kubePosition, Quaternion.identity);
                }
            }
        }
    }

    void SelectPattern()
    {
        switch (ActiveLevel)
        {
            // 1 level pattern
            case 1:
                _pattern[0] = new bool[7] { false, false, false, false, false, false, false };
                _pattern[1] = new bool[7] { false, false, false, false, false, false, false };
                _pattern[2] = new bool[7] { false, true, false, false, false, false, true };
                _pattern[3] = new bool[7] { true, true, true, true, true, true, true };
                _pattern[4] = new bool[7] { false, false, false, false, false, false, true };
                _pattern[5] = new bool[7] { false, false, false, false, false, false, false };
                _pattern[6] = new bool[7] { false, false, false, false, false, false, false };
                break;
            // 2 level pattern
            case 2:
                _pattern[0] = new bool[7] { false, false, false, false, false, false, false };
                _pattern[1] = new bool[7] { false, false, false, false, false, false, false };
                _pattern[2] = new bool[7] { false, true, false, false, false, true, true };
                _pattern[3] = new bool[7] { true, false, false, true, true, false, true };
                _pattern[4] = new bool[7] { false, true, true, false, false, false, true };
                _pattern[5] = new bool[7] { false, false, false, false, false, false, false };
                _pattern[6] = new bool[7] { false, false, false, false, false, false, false };
                break;
            // 3 level pattern
            case 3:
                _pattern[0] = new bool[7] { false, false, false, false, false, false, false };
                _pattern[1] = new bool[7] { false, false, false, false, false, false, false };
                _pattern[2] = new bool[7] { false, true, false, false, false, true, false };
                _pattern[3] = new bool[7] { true, false, false, true, false, false, true };
                _pattern[4] = new bool[7] { false, true, true, false, true, true, false };
                _pattern[5] = new bool[7] { false, false, false, false, false, false, false };
                _pattern[6] = new bool[7] { false, false, false, false, false, false, false };
                break;
        }
    }
}
