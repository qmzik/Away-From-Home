using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeroController : MonoBehaviour
{

    public float Walkspeed;
    public float JumpForce;
    //public AudioClip walk, run, jump, gotPoint, hit;

    //private AudioSource audioSource;
    private GameObject player;
    private Rigidbody2D rb;
    private Animator animator;
    private Direction direction = Direction.right;
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
        player = gameObject;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        //audioSource = GetComponent<AudioSource>();
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
                FlipDirection();
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
            Jump();
        }
    }

    void MoveRight()
    {
        player.transform.position += player.transform.right * Walkspeed * Time.deltaTime;
    }

    void MoveLeft()
    {
        player.transform.position -= player.transform.right * Walkspeed * Time.deltaTime;
    }

    void Jump()
    {
        State = CharState.jump;
        if (!isJumping && !isJumpCooldown)
        {
            //audioSource.PlayOneShot(jump);
            isJumping = true;
            isJumpCooldown = true;
            rb.AddForce(new Vector2(0, JumpForce));
            Invoke("JumpingCoolDown", jumpCooldown);
        }
    }
    void FlipDirection()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
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
            rb.AddForce(new Vector2(0, JumpForce * 2));
        }
    }
}

enum Direction
{
    right,
    left
}

public enum CharState
{
    idle,
    run,
    jump
}