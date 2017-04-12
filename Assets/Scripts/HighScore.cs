using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public Text HighScoreText;


    // Use this for initialization
    void Start ()
    {
        HighScoreText.text = "High Score " + PlayerPrefs.GetInt("HighScore").ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
