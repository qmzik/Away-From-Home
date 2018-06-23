using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMoving : Movement {

	// Use this for initialization
	void Start () {
        objectOfGame = gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        MoveDown();
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
