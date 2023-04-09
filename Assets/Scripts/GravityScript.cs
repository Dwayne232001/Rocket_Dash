using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityScript : MonoBehaviour
{
    public float attractionRadius = 5f; // Radius of the spherical volume
    public float attractionForce = 10f; // Strength of the attraction force

    private GameObject player;
    private Rigidbody playerRb;
    private bool isSpacePressed = false;

    void Start()
    {
        // Find the GameObject with the "Player" tag
        player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            // Get the Rigidbody component of the player
            playerRb = player.GetComponent<Rigidbody>();

            // Check if the player has a Rigidbody component
            if (playerRb == null)
            {
                Debug.LogError("Player GameObject does not have a Rigidbody component!");
            }
        }
        else
        {
            Debug.LogError("No GameObject with 'Player' tag found!");
        }
    }

    void Update()
    {
        // Check if the Space button is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpacePressed = true;
        }
    }

    void FixedUpdate()
    {
        if (playerRb != null && isSpacePressed)
        {
            // Calculate the distance between the object and the player
            float distance = Vector3.Distance(transform.position, player.transform.position);

            // Check if the player is within the attraction radius
            if (distance <= attractionRadius)
            {
                // Calculate the attraction vector
                Vector3 attractionVector = (transform.position - player.transform.position).normalized;

                // Apply the attraction force to the player's Rigidbody
                playerRb.AddForce(attractionVector * attractionForce);
            }
        }
    }
}
