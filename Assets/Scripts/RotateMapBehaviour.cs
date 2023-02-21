using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMapBehaviour : MonoBehaviour
{
    [SerializeField] private float rotationTime;
    [SerializeField] private float rotationInterval;

    private float timeSinceLastRotation;
    private float currentRotation;
    private Transform rocketTransform;

    private void Start()
    {
        rocketTransform = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (currentRotation < 90)
        {
            float rotationAmount = 90 * Time.deltaTime / rotationTime;
            transform.RotateAround(rocketTransform.position, Vector3.forward, rotationAmount);
            currentRotation += rotationAmount;
        }
        else
        {
            timeSinceLastRotation += Time.deltaTime;
            if (timeSinceLastRotation >= rotationInterval)
            {
                currentRotation = 0;
                timeSinceLastRotation = 0;
            }
        }
    }
}

