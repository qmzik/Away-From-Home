using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowEnemy : MonoBehaviour {
    public float speed;

    private GameObject target;
    private Vector3 targetPosition;
	// Use this for initialization
	void Start () {
        target = GameObject.Find("Char");
    }
	
	// Update is called once per frame
	void Update () {
        targetPosition = target.transform.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
	}
}
