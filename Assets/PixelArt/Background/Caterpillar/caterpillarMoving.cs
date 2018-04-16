using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class caterpillarMoving : Movement {

	void Start () {
        objectOfGame = gameObject;
        direction = Direction.left;
	}
	
	void Update () {
        if (direction == Direction.left)
        {
            MoveLeft();
        }

        if(direction == Direction.right)
        {
            MoveRight();
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Wall")
        {
            FlipDirectionX();
        }
    }
}
