using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMineBehaviour : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    [SerializeField] private float pullForce;
    [SerializeField] private float accelerationMultiplier;

    private Transform playerTransform;

    private void Start()
    {
        playerTransform = GameObject.FindWithTag("Player").transform;
    }

    private void FixedUpdate()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);
        if (distance < maxDistance)
        {
            Vector3 direction = (playerTransform.position - transform.position).normalized;
            float force = pullForce * (1 + accelerationMultiplier * (1 - (distance / maxDistance)));
            GetComponent<Rigidbody>().AddForce(direction * force);
        }
    }
}

