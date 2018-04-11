using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Movement: MonoBehaviour
    {
        public float Speed;

        public float JumpForce;

        protected GameObject objectOfGame;

        protected Rigidbody2D rb;

        protected Direction direction;

        protected void MoveRight()
        {
            objectOfGame.transform.position += Vector3.right * Speed * Time.deltaTime;
        }

        protected void MoveLeft()
        {
            objectOfGame.transform.position -= Vector3.right * Speed * Time.deltaTime;
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

        protected void Jump()
        {
            rb.AddForce(new Vector2(0, JumpForce));
        }

        protected enum Direction
        {
            right,
            left
        }
    }
}
