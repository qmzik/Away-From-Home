using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveLoad : MonoBehaviour {

    public GameObject objectLoader;
    public static bool isSaveExist = false;

    private static int savedGame;

    private void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/savedGames.afh"))
        {
            isSaveExist = true;
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/savedGames.afh", FileMode.Open);
            savedGame = (int)bf.Deserialize(file);
            file.Close();
        }

        if (isSaveExist)
        {
            objectLoader.SetActive(true);
        }
        else
        {
            objectLoader.SetActive(false);
        }
    }

    public static void SaveGame()
    {
        savedGame = SceneManager.GetActiveScene().buildIndex + 1;
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/savedGames.afh");
        bf.Serialize(file, savedGame);
        file.Close();
        Debug.Log(Application.persistentDataPath);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(savedGame);
    }

    public static void GoToNextSceneAndSave()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SaveGame();
    }
}
