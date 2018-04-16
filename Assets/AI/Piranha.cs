using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piranha : Movement {
    public GameObject border;
    bool colliding = false;

	void Start () {
        objectOfGame = gameObject;
        direction = Direction.left;
    }
	
	void Update () {

        colliding = Physics2D.Linecast(border.transform.position, border.transform.position, 1 << 8);

        if (direction == Direction.left)
        {
            MoveLeft();
        }

        if (direction == Direction.right)
        {
            MoveRight();
        }

        if (colliding)
        {
            FlipDirectionX();
        }
    }
}