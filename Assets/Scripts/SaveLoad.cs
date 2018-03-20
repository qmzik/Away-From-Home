﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour {

    public GameObject ObjectLoader;
    public static bool IsSaveExist = false;

    private void Start()
    {
        if (IsSaveExist)
        {
            ObjectLoader.SetActive(true);
        }
        else
        {
            ObjectLoader.SetActive(false);
        }
    }

    public static void SaveGame()
    {
        PlayerPrefs.SetInt("savedLevel", SceneManager.GetActiveScene().buildIndex + 1);
        IsSaveExist = true;
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("savedLevel"));
    }

    public static void GoToNextSceneAndSave()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SaveGame();
    }
}
