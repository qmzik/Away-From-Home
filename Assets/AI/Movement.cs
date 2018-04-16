using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Movement: MonoBehaviour
    {
        public float speed;

        public float jumpForce;

        protected GameObject objectOfGame;

        protected Rigidbody2D rb;

        protected Direction direction;

        protected virtual void MoveRight()
        {
            objectOfGame.transform.position += Vector3.right * speed * Time.deltaTime;
        }

        protected virtual void MoveLeft()
        {
            objectOfGame.transform.position -= Vector3.right * speed * Time.deltaTime;
        }

        protected virtual void MoveUp()
        {
            objectOfGame.transform.position += Vector3.up * speed * Time.deltaTime;
        }

        protected virtual void MoveDown()
        {
            objectOfGame.transform.position += Vector3.down * speed * Time.deltaTime;
        }

        protected virtual void FlipDirectionX()
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

        protected virtual void FlipDirectionY()
        {
            if (direction == Direction.up)
            {
                direction = Direction.down;
            }
            else if (direction == Direction.down)
            {
                direction = Direction.up;
            }

            transform.localScale = new Vector3(transform.localScale.x, -transform.localScale.y, transform.localScale.z);
        }

        protected virtual void Jump()
        {
            rb.AddForce(new Vector2(0, jumpForce));
        }

        protected enum Direction
        {
            right,
            left,
            up,
            down
        }
    }
}
