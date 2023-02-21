using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour
{
    [SerializeField] float levelLoadDelay = 0.5f;
    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip winSound;
    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem winParticles;

    bool isTransitioning = false;

    AudioSource rocketSounds;

    void Start()
    {
        rocketSounds = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other) {
        if(isTransitioning) 
        { 
            return; 
        }
        else
        {
            switch(other.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("Do nothing");
                    break;
                case "Finish":
                    Debug.Log("You Win!");
                    StartLandSequence();
                    break;
                case "Untagged":
                    Debug.Log("You Died!");
                    StartCrashSequence();
                    break;
            }
        }
    }

    private void StartCrashSequence() {
        //TODO add particle effects AND sound effects on crash
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        crashParticles.Play();
        rocketSounds.Stop();
        rocketSounds.PlayOneShot(crashSound);
        Invoke("ReloadScene", levelLoadDelay);
    }

    private void StartLandSequence() {
        //TODO add particle effects AND sound effects on win
        isTransitioning = true;
        GetComponent<Movement>().enabled = false;
        winParticles.Play();
        rocketSounds.Stop();
        rocketSounds.PlayOneShot(winSound);
        Invoke("LoadNextScene", levelLoadDelay);
    }

    public void ReloadScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    public void LoadNextScene() {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Current Scene Index: " + currentSceneIndex);
        if(currentSceneIndex+1==2)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex+1);
        }
    }
}
