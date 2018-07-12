﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable01 : MonoBehaviour {

    public static int objects = 0;
    public static int objectsHud = 0;
    public GameObject BGMToStop;
    public GameObject TitanObject;
    public GameObject AoTMusicGameObject;
    bool alreadyPlayed = false;

    Light light;
    AudioSource audio;
    MeshRenderer mesh;

    void Awake() {
        objects++;
    }

    void Start() {
        objects = 0;
        objectsHud = 0;
        audio = GetComponent<AudioSource>();
        mesh = GetComponent<MeshRenderer>();
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update() {
        transform.Rotate(0, 2, 0);
    }

    void OnTriggerEnter(Collider col) {

        if (!alreadyPlayed) {
            if (col.tag == "Player") {
               
                objects--;
                objectsHud++;
            }

            BGMToStop.SetActive(false);
            TitanObject.SetActive(true);
            AoTMusicGameObject.SetActive(true);
            light.intensity = 0;
            mesh.enabled = false;
            alreadyPlayed = true;
        }
    }
}
