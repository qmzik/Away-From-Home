using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorAction : MonoBehaviour {

    public string SceneName;
    public GameObject info;
    bool canIGo = false;

	void Start () {
        info.SetActive(false);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        info.SetActive(true);
        canIGo = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        info.SetActive(false);
        canIGo = false;
    }

    void Update () {
		if(Input.GetKeyDown(KeyCode.E) && canIGo)
        {
            SceneManager.LoadScene(SceneName);
        }
	}
}
