using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DebugSettings : MonoBehaviour
{
      ObstacleCollision obstacleCollision;
      BoxCollider boxCollider;

      void Start() 
      {
            obstacleCollision = GameObject.FindGameObjectWithTag("Player").GetComponent<ObstacleCollision>();
            boxCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>();
      }

      void Update()
      {
            if (Input.GetKey(KeyCode.L))
            {
                  // Load the next scene in the build settings
                  obstacleCollision.LoadNextScene();
            }
            if (Input.GetKey(KeyCode.K))
            {
                  // Disable/Enable Collisions
                  if(boxCollider.enabled)
                  {
                        boxCollider.enabled = false;
                        Debug.Log("Collision Box Disabled");
                  }
                  else
                  {
                        boxCollider.enabled = true;
                        Debug.Log("Collision Box Enabled");
                  }
            }
            if (Input.GetKey(KeyCode.J))
            {
                  // Disable/Enable Obstacle Collision
                  if(obstacleCollision.enabled)
                  {
                        obstacleCollision.enabled = false;
                        Debug.Log("Obstacle Collision Disabled");
                  }
                  else
                  {
                        obstacleCollision.enabled = true;
                        Debug.Log("Obstacle Collision Enabled");
                  }
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                  Debug.Log("Qutting Game...");
                  {
                        SceneManager.LoadScene("Navigation Menu");
                  }
            }
      }

}
