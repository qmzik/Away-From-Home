using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{

    public float speed = 20f;
    public float distance;

    private GameObject platform;
    private Direction direction = Direction.left;
    private float currentDistance;
    void Start()
    {
        platform = gameObject;
        currentDistance = distance;
    }

    void Update()
    {

        if (direction == Direction.left)
        {
            platform.transform.position -= platform.transform.right * speed * Time.deltaTime;
            currentDistance--;
        }

        if (direction == Direction.right)
        {
            platform.transform.position += platform.transform.right * speed * Time.deltaTime;
            currentDistance++;
        }

        if (currentDistance == 0)
        {
            direction = Direction.right;
        }

        if (currentDistance == distance)
        {
            direction = Direction.left;
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        coll.transform.parent = transform;
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        coll.transform.parent = null;
    }


    enum Direction
    {
        right,
        left
    }
}

