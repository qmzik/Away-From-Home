using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    public float smoothTime = 0.3F;
    public float topOffset = 0.32f;
    private Vector3 velocity = Vector3.zero;
    void Update()
    {
        Vector3 targetPosition = target.TransformPoint(new Vector3(0, topOffset, -60));
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }
}
