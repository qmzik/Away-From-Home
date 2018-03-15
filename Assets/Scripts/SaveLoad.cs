using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour {

    public static bool IsSaveExist = false;
	public static void SaveGame()
    {
        PlayerPrefs.SetInt("savedLevel", SceneManager.GetActiveScene().buildIndex + 1);
        IsSaveExist = true;
    }

    public static void LoadGame()
    {
        SceneManager.LoadScene(PlayerPrefs.GetInt("savedLevel"));
    }

    public static void GoToNextSceneAndSave()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SaveGame();
    }
}
