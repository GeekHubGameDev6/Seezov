﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public void LoadByIndex(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void SetSelectedLevel(int sceneIndex)
    {
        GameManager.ActiveLevel = sceneIndex;
    }
}
