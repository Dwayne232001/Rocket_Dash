using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OscillationObstacleBehaviour : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    // [SerializeField] [Range(0,1)] float movementFactor;
    float movementFactor;
    [SerializeField] float period = 2f;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period == 0) // Protect against NaN error
        {
            return;
        }
        float cycles = Time.time / period;  //Continually growing over time
        const float tau = Mathf.PI*2; //Constant value of 6.283
        float rawSinWave = Mathf.Sin(cycles*tau); //To go from -1 to 1
        movementFactor = (rawSinWave + 1f) / 2; // recalculated to go from 0 to 1

        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}
