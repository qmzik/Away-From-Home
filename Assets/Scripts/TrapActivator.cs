using UnityEngine;

public class TrapActivator : MonoBehaviour {

    public GameObject info;
    public GameObject trap;
    public float trapActiveTime;
    bool isNearEnough = false;
    bool coollingdown = false;

	// Use this for initialization
	void Start () {
        trap.SetActive(false);
        trap.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (isNearEnough && !coollingdown)
        {
            info.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                CreateAndDestroyTrap();
                Invoke("CooldownEnd", trapActiveTime);
            }
        }
        else
        {
            info.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isNearEnough = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isNearEnough = false;
    }

    void CreateAndDestroyTrap()
    {
        trap.SetActive(true);
        coollingdown = true;
        Invoke("HideTrap", trapActiveTime);
    }

    void HideTrap()
    {
        trap.SetActive(false);
    }

    void CooldownEnd()
    {
        coollingdown = false;
    }
}
