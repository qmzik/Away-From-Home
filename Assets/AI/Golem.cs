using Assets.Scripts;
using UnityEngine;

public class Golem : Movement {

    bool canIGo = false;

	void Start () {
        objectOfGame = gameObject;
        direction = Direction.right;
	}
	
	void Update () {
		if (canIGo)
        {
            MoveLeft();
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        FlipDirectionX();
        canIGo = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EnemyForAI")
        {
            Destroy(gameObject);
        }
    }
}
