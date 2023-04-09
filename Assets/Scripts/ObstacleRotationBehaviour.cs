using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotationBehaviour : MonoBehaviour
{
    public Vector3 rotationAxis = Vector3.up; // The axis to rotate around
    public float rotationSpeed = 10f; // The speed of rotation in degrees per second

    void Update()
    {
        // Rotate the object around the specified axis at the specified speed
        transform.Rotate(rotationAxis, rotationSpeed * Time.deltaTime);
    }
}
