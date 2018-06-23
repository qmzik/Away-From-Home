using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotting : MonoBehaviour {

    public GameObject bullet;
    public float CoolDown;

    private bool canIShoot;
	// Use this for initialization
	void Start () {
        canIShoot = true;
	}
	
	// Update is called once per frame
	void Update () {
        if(canIShoot)
        {
            Shoot();
            Invoke("EndCooldown", CoolDown);
        }
	}

    void Shoot()
    {
        canIShoot = false;
        Instantiate(bullet, transform.position, transform.rotation);
    }

    void EndCooldown()
    {
        canIShoot = true;
    }
}
