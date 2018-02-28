using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour
{

    public float Walkspeed;
    public float JumpForce;
    //public AudioClip walk, run, jump, gotPoint, hit;


    //private AudioSource audioSource;
    private GameObject player;
    private Rigidbody2D rb;
    //private Animator animator;
    private Direction direction = Direction.right;
    private bool isJumping = false;
    private float jumpCooldown = 0.5f;
    private bool isJumpCooldown = false;

    /*private CharState State
    {
        get { return (CharState)animator.GetInteger("State"); }
        set { animator.SetInteger("State", (int)value); }
    }*/

    void Start()
    {
        player = gameObject;
        rb = GetComponent<Rigidbody2D>();
        //animator = GetComponent<Animator>();
        //audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
       /* if(isJumping)
        {
            State = CharState.jump;
        }
        else
        {
            State = CharState.idle;
        }*/

        if (Input.GetKey(KeyCode.D))
        {
            if (direction != Direction.right)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

            direction = Direction.right;
           // State = CharState.run;
            MoveRight();
        }

        if (Input.GetKey(KeyCode.A))
        {
            if (direction != Direction.left)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }

            direction = Direction.left;
            //State = CharState.run;
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Walkspeed = 7f;
        }
        else
        {
            Walkspeed = 5f;
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
        //State = CharState.jump;
        if (!isJumping && !isJumpCooldown)
        {
            //audioSource.PlayOneShot(jump);
            isJumping = true;
            isJumpCooldown = true;
            rb.AddForce(new Vector2(0, JumpForce));
            Invoke("CoolDown", jumpCooldown);
        }
    }

    void CoolDown()
    {
        isJumpCooldown = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isJumping = false;
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