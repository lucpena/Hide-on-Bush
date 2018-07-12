using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerAudioSource : MonoBehaviour {

    public AudioClip[] clips;
    public AudioMixerGroup output;
    public Transform player;
    public float minimumMoveTreshold;
    public float moveSec;

    Vector3 previousPosition;
    private bool hasCoroutineStarted = false;

    float minPitch = 0.95f;
    float maxPitch = 1.05f;

    void Update() {

    }

    void Start() {
        player = GetComponent<Transform>();
    }

    public void PlaySound() {
        //Randomize
        int randomClip = Random.Range(0, 4);

        //Create an Audio Source
        AudioSource source = gameObject.AddComponent<AudioSource>();

        //Load clip into the AudioSource
        source.clip = clips[randomClip];

        // Set the output for AudioSource
        source.outputAudioMixerGroup = output;

        //Set random pitch
        //source.pitch = Random.Range(minPitch, maxPitch);

        //Play the clip
        source.Play();

        //Destroy the AudioSource when done playing clip
        Destroy(source, clips[randomClip].length);
    }

    void OnTriggerEnter(Collider col) {
        if (col.tag == "Weapon") {
            print("PLAY SOUND PAIN");
            PlaySound();
        }
    }

    void PlayFootStep() {
        int randomClip = Random.Range(4, 6);
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = clips[randomClip];
        source.outputAudioMixerGroup = output;
        source.pitch = Random.Range(minPitch, maxPitch);
        source.Play();
        Destroy(source, clips[randomClip].length);
        print("PLAY SOUND FOOTSTEP");
    }
}
