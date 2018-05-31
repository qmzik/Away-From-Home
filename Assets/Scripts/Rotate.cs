using System;
using UnityEngine;

namespace Assets.Scripts
{
    public class Rotate : MonoBehaviour
    {
        public float angelPerUpdate;
        public GameObject rotatingObject;

        void FixedUpdate()
        {
            rotatingObject.transform.Rotate(0, 0, angelPerUpdate);
        }
    }
}
