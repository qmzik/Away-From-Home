using Assets.Scripts;
using UnityEngine;

public class MovingPlatform : Movement
{
    public float endPosition;

    private float startPosition;

    private float currentPosition;
    private float lowBound;
    private float upBound;
    void Start()
    {
        startPosition = transform.position.x;

        if (startPosition > endPosition)
        {
            direction = Direction.left;
            upBound = startPosition;
            lowBound = endPosition;
        }
        else
        {
            direction = Direction.right;
            upBound = endPosition;
            lowBound = startPosition;
        }

        objectOfGame = gameObject;
        currentPosition = startPosition;
    }

    void FixedUpdate()
    {

        if (direction == Direction.left)
        {
            objectOfGame.transform.position -= objectOfGame.transform.right * speed * Time.deltaTime;
            currentPosition -= speed * Time.deltaTime;
        }

        if (direction == Direction.right)
        {
            objectOfGame.transform.position += objectOfGame.transform.right * speed * Time.deltaTime;
            currentPosition += speed * Time.deltaTime;
        }

        if (currentPosition < lowBound || currentPosition > upBound)
        {
            FlipDirectionX();
        }
    }

    protected override void FlipDirectionX()
    {
        if (direction == Direction.right)
        {
            direction = Direction.left;
        }
        else if (direction == Direction.left)
        {
            direction = Direction.right;
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
}

