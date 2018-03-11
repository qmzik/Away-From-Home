using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    public float BacgroundSize;

    Transform cameraTransfrom;
    Transform[] layers;
    float viewZone = 10;
    int leftIndex;
    int rightIndex;
	
	void Start () {
        cameraTransfrom = Camera.main.transform;
        layers = new Transform[transform.childCount];
        for(int i = 0; i < transform.childCount; i++)
        {
            layers[i] = transform.GetChild(i);
        }

        leftIndex = 0;
        rightIndex = layers.Length - 1;
	}
	
	
	void Update () {
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
        int lastRight = rightIndex;
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
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + BacgroundSize);
        rightIndex = leftIndex;
        leftIndex++;

        if (leftIndex == layers.Length)
        {
            leftIndex = 0;
        }
    }
}
