using UnityEngine;

public class GetKey : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CollectKeys.keys.Add(gameObject);
            Destroy(gameObject);
        }
    }
}
