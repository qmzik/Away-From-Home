using UnityEngine;

public class TrapActivator : MonoBehaviour {

    public GameObject info;
    public GameObject Trap;
    public float trapActiveTime;
    bool isNearEnough = false;
    bool coolingdown = false;

	// Use this for initialization
	void Start () {
        Trap.SetActive(false);
        Trap.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (isNearEnough && !coolingdown)
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
        Trap.SetActive(true);
        coolingdown = true;
        Invoke("HideTrap", trapActiveTime);
    }

    void HideTrap()
    {
        Trap.SetActive(false);
    }

    void CooldownEnd()
    {
        coolingdown = false;
    }
}
