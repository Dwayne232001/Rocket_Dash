using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneGravityOverride : MonoBehaviour
{
    [SerializeField] private Vector3 gravity;

    private void Awake()
    {
        Physics.gravity = gravity;
    }
}