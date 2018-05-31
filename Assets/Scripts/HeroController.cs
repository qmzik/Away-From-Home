using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroController : Movement
{
    private GameObject player;
    private Animator animator;
    private bool isJumping = false;
    private float jumpCooldown = 0.5f;
    private bool isJumpCooldown = false;


    private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }

    void Start()
    {
        objectOfGame = gameObject;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        direction = Direction.right;
    }

    void Update()
    {
        if (isJumping)
        {
            State = CharState.jump;
        }
        else
        {
            State = CharState.idle;
        }

        if (Input.GetKey(KeyCode.D))
        {
            if (direction != Direction.right)
            {
                FlipDirectionX();
            }
            direction = Direction.right;

            if (!isJumping)
            {
                State = CharState.run;
            }
                MoveRight();
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (direction != Direction.left)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

            direction = Direction.left;

            if (!isJumping)
            {
                State = CharState.run;
            }
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            State = CharState.jump;
            if (!isJumping && !isJumpCooldown)
            {
                isJumping = true;
                isJumpCooldown = true;
                Jump();
                Invoke("JumpingCoolDown", jumpCooldown);
            }
        }
    }
    
    void JumpingCoolDown()
    {
        isJumpCooldown = false;
    }

    void Die()
    {
        SceneManager.LoadScene("Death");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
        }

        if (collision.gameObject.tag == "Enemy")
        {
            Die();
        }

        if (collision.gameObject.tag == "JumpForce")
        {
            isJumping = true;
            rb.AddForce(new Vector2(0, jumpForce * 2));
        }
    }
}

public enum CharState
{
    idle,
    run,
    jump
}