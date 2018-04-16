using UnityEngine;
using Assets.Scripts;

public class MovingObjectY : Movement {

    public float endPosition;

    private float startPosition;
    private float currentPosition;
    private float lowBound;
    private float upBound;

    void Start()
    {
        startPosition = transform.position.y;

        if (startPosition > endPosition)
        {
            direction = Direction.down;
            upBound = startPosition;
            lowBound = endPosition;
        }
        else
        {
            direction = Direction.up;
            upBound = endPosition;
            lowBound = startPosition;
        }

        objectOfGame = gameObject;
        currentPosition = startPosition;
    }

    void FixedUpdate()
    {

        if (direction == Direction.up)
        {
            MoveUp();
            currentPosition += speed * Time.deltaTime;
        }

        if (direction == Direction.down)
        {
            MoveDown();
            currentPosition -= speed * Time.deltaTime;
        }

        if (currentPosition < lowBound || currentPosition > upBound)
        {
            FlipDirectionY();
        }
    }
}
