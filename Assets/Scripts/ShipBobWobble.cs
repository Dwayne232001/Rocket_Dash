using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipBobWobble : MonoBehaviour
{
    public float bobSpeed = 0.5f; // The speed at which the ship bobs
    public float bobHeight = 0.5f; // The height of the bobbing motion
    public float wobbleSpeed = 1.0f; // The speed at which the ship wobbles
    public float wobbleAmount = 1.0f; // The amount of wobbling motion

    private Vector3 initialPosition; // The initial position of the ship
    private Quaternion initialRotation; // The initial rotation of the ship

    // Start is called before the first frame update
    void Start()
    {
        // Record the initial position and rotation of the ship
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new position of the ship based on the sine of the current time
        float bobOffset = Mathf.Sin(Time.time * bobSpeed) * bobHeight;
        Vector3 newPosition = initialPosition + new Vector3(0.0f, bobOffset, 0.0f);

        // Calculate the new rotation of the ship based on the sine of the current time
        float wobbleOffset = Mathf.Sin(Time.time * wobbleSpeed) * wobbleAmount;
        Quaternion newRotation = initialRotation * Quaternion.Euler(0.0f, 0.0f, wobbleOffset);

        // Move and rotate the ship to its new position and rotation
        transform.position = newPosition;
        transform.rotation = newRotation;
    }
}
