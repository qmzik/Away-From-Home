using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Piranha : AbstractAI {
    public GameObject border;
    bool colliding = false;

	// Use this for initialization
	void Start () {
        AI = gameObject;
        direction = Direction.left;
    }
	
	// Update is called once per frame
	void Update () {

        colliding = Physics2D.Linecast(border.transform.position, border.transform.position);

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
            FlipDirection();
        }
    }
}