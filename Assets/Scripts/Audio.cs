using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Audio : MonoBehaviour {

    public static bool IsMuted;
    public Text AudioText;

	void Update ()
    {
        // GUI Update
        if (IsMuted)
            AudioText.text = "Audio OFF";
        if (!IsMuted)
            AudioText.text = "Audio ON";
    }

    // Audio toggle
    public void AudioMute()
    {
        IsMuted = !IsMuted;
        AudioListener.pause = IsMuted;
    }
}
