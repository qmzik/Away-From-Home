using UnityEngine;

public class GetKey : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            CollectKeys.keys.Add(gameObject);
            Destroy(gameObject);
        }
    }
}
