using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour
{
    public static bool IsMuted;
    public Text AudioText;


    // Use this for initialization
    void Start ()
    {
        IsMuted = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AudioMute()
    {
        IsMuted = !IsMuted;
        GetComponent<AudioSource>().mute = !GetComponent<AudioSource>().mute;
        if (IsMuted)
            AudioText.text = "Audio OFF";
        if (!IsMuted)
            AudioText.text = "Audio ON";
    }
}
