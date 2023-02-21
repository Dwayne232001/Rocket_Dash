using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float mainThrust = 1f;
    [SerializeField] float rotateThrust = 1f;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainEngineParticles;
    [SerializeField] ParticleSystem leftThrustParticles;
    [SerializeField] ParticleSystem rightThrustParticles;
    Rigidbody rocket;
    AudioSource rocketSounds;

    // Start is called before the first frame update
    void Start()
    {
        rocket = GetComponent<Rigidbody>();
        rocketSounds = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotate();
    }

    private void ProcessThrust()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            // Debug.Log("Thrusting");
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    private void ProcessRotate()
    {
        if(Input.GetKey(KeyCode.A))
        {
            // Debug.Log("Moving Left");
            RotateLeft();
        }
        else if(Input.GetKey(KeyCode.D))
        {
            // Debug.Log("Moving Right");
            RotateRight();
        }
        else
        {
            StopRotateEffects();
        }
    }

    private void StartThrusting()
    {
        rocket.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);
        if (!rocketSounds.isPlaying)
        {
            rocketSounds.PlayOneShot(mainEngine);
        }
        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }

    private void StopThrusting()
    {
        rocketSounds.Stop();
        mainEngineParticles.Stop();
    }

    private void RotateLeft()
    {
        ApplyRotation(1f);
        if (!rightThrustParticles.isPlaying)
        {
            rightThrustParticles.Play();
        }
    }

    private void RotateRight()
    {
        ApplyRotation(-1f);
        if (!leftThrustParticles.isPlaying)
        {
            leftThrustParticles.Play();
        }
    }

    private void StopRotateEffects()
    {
        leftThrustParticles.Stop();
        rightThrustParticles.Stop();
    }

    private void ApplyRotation(float xDirectionBipolarBool)
    {
        rocket.freezeRotation = true; // Freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotateThrust * Time.deltaTime * xDirectionBipolarBool);
        rocket.freezeRotation = false; // Unfreezing rotation so the physics system can take over
    }
}
