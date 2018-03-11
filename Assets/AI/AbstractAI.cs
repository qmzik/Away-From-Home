using UnityEngine;

namespace Assets.Scripts
{
    public abstract class AbstractAI : MonoBehaviour
    {
        public float speed;

        protected GameObject AI;

        protected Direction direction;

        protected void MoveRight()
        {
            AI.transform.position += AI.transform.right * speed * Time.deltaTime;
        }

        protected void MoveLeft()
        {
            AI.transform.position -= AI.transform.right * speed * Time.deltaTime;
        }

        protected void FlipDirection()
        {
            if (direction == Direction.right)
            {
                direction = Direction.left;
            }

            if (direction == Direction.left)
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
