using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piranha : AbstractAI {

	// Use this for initialization
	void Start () {
        AI = gameObject;
        direction = Direction.left;
    }
	
	// Update is called once per frame
	void Update () {
        if (direction == Direction.left)
        {
            MoveLeft();
        }

        if (direction == Direction.right)
        {
            MoveRight();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            FlipDirection();
        }
    }
}
