using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Movement: MonoBehaviour
    {
        public float speed;

        protected GameObject objectOfGame;

        protected Direction direction;

        protected void MoveRight()
        {
            objectOfGame.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        protected void MoveLeft()
        {
            objectOfGame.transform.position -= Vector3.right * speed * Time.deltaTime;
        }

        protected void FlipDirection()
        {
            if (direction == Direction.right)
            {
                direction = Direction.left;
            }
            else if (direction == Direction.left)
            {
                direction = Direction.right;
            }

            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        }

        protected enum Direction
        {
            right,
            left
        }
    }
}
