using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public Text HighScoreText;

    void Start ()
    {
        HighScoreText.text = "High Score " + PlayerPrefs.GetInt("HighScore");
    }
	
}
