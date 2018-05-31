using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    public float BacgroundSize;
    public float ParallaxSpeed;

    Transform cameraTransfrom;
    Transform[] layers;
    float viewZone = 10;
    float lastCameraX;
    float deltaX;
    int leftIndex;
    int rightIndex;

	void Start () {
        cameraTransfrom = Camera.main.transform;
        lastCameraX = cameraTransfrom.position.x;
        layers = new Transform[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = layers.Length - 1;
	}
	
	
	void Update () {
        deltaX = cameraTransfrom.position.x - lastCameraX;
        transform.position += Vector3.right * deltaX * ParallaxSpeed;
        lastCameraX = cameraTransfrom.position.x;
        if (cameraTransfrom.position.x < layers[leftIndex].transform.position.x + viewZone)
        {
            ScrollLeft();
        }

        if (cameraTransfrom.position.x > layers[rightIndex].transform.position.x - viewZone)
        {
            ScrollRight();
        }
    }

    void ScrollLeft()
    {
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - BacgroundSize);
        leftIndex = rightIndex;
        rightIndex--;

        if(rightIndex < 0)
        {
            rightIndex = layers.Length - 1;
        }
    }

    void ScrollRight()
    {
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + BacgroundSize);
        rightIndex = leftIndex;
        leftIndex++;

        if (leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }
}
